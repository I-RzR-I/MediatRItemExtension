// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-08 21:03
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-16 23:30
// ***********************************************************************
//  <copyright file="MediatRItemInitializeService.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.ComponentModel.Design;
using System.Windows;
using EnvDTE;
using MediatRItemExtension.Enums;
using MediatRItemExtension.Enums.Codes;
using MediatRItemExtension.Extensions.DataType;
using MediatRItemExtension.Helpers;
using MediatRItemExtension.Helpers.Localization;
using MediatRItemExtension.Helpers.LogHelper;
using MediatRItemExtension.Helpers.Operation;
using MediatRItemExtension.Models;
using MediatRItemExtension.View;
using Microsoft;
using Microsoft.Internal.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Settings;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell.Settings;
using IAsyncServiceProvider = Microsoft.VisualStudio.Shell.IAsyncServiceProvider;
using Task = System.Threading.Tasks.Task;

#endregion

namespace MediatRItemExtension.Services
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A service for accessing mediat r item initializes information. This class cannot be
    ///     inherited.
    /// </summary>
    /// =================================================================================================
    internal sealed class MediatRItemInitializeService
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the mediat r settings store service.
        /// </summary>
        /// =================================================================================================
        private readonly MediatRSettingsStoreService _mediatRSettingsStoreService;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     The solution settings store service.
        /// </summary>
        /// =================================================================================================
        private static SolutionSettingsStoreService _solutionSettingsStoreService;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the package.
        /// </summary>
        /// =================================================================================================
        private readonly AsyncPackage _package;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the wait dialog.
        /// </summary>
        /// =================================================================================================
        private readonly IVsThreadedWaitDialog2 _waitDialog;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     The solution item helper.
        /// </summary>
        /// =================================================================================================
        private static SolutionItemHelper _solutionItemHelper;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     The version check result.
        /// </summary>
        /// =================================================================================================
        private VersionCheckResultType _versionCheckResult;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the service provider.
        /// </summary>
        /// <value>
        ///     The service provider.
        /// </value>
        /// =================================================================================================
        private IAsyncServiceProvider AsyncServiceProvider => _package;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="MediatRItemInitializeService" /> class.
        /// </summary>
        /// <param name="package">The package.</param>
        /// <param name="commandService">The command service.</param>
        /// =================================================================================================
        private MediatRItemInitializeService(AsyncPackage package, OleMenuCommandService commandService)
        {
            ThrowHelper.IfNullArgumentNullException(package, nameof(package));
            ThrowHelper.IfNullArgumentNullException(commandService, nameof(commandService));

            _package = package;

            var settingsManager = new ShellSettingsManager(_package);
            var writableSettingsStore = settingsManager.GetWritableSettingsStore(SettingsScope.UserSettings);

            _mediatRSettingsStoreService = new MediatRSettingsStoreService(writableSettingsStore);
            Assumes.Present(_mediatRSettingsStoreService);

            _solutionSettingsStoreService = new SolutionSettingsStoreService(writableSettingsStore);
            Assumes.Present(_solutionSettingsStoreService);

            _waitDialog = _package.GetService<SVsThreadedWaitDialog, IVsThreadedWaitDialog2>();
            Assumes.Present(_waitDialog);
            
            var menuCommandId = new CommandID(InitResources.CommandSet, InitResources.CommandId);
            var menuItem = new MenuCommand(Execute, menuCommandId);
            commandService.AddCommand(menuItem);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes the asynchronous.
        /// </summary>
        /// <param name="package">The package.</param>
        /// <returns>
        ///     A System.Threading.Tasks.Task.
        /// </returns>
        /// =================================================================================================
        public static async Task InitializeAsync(AsyncPackage package)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            var commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            _ = new MediatRItemInitializeService(package, commandService);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Executes.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event information.</param>
        /// =================================================================================================
        private void Execute(object sender, EventArgs e)
        {
            _solutionItemHelper = GetSolutionItem();
            Assumes.Present(_solutionItemHelper);

            if (_solutionItemHelper.IsSolutionSelected)
            {
                ShowMessage(ResourceMessage.ErrorMessagesStore[ErrorCodeType.E0011], MessageBoxImage.Information);
                
                return;
            }

            _ = ThreadHelper.JoinableTaskFactory.RunAsync(
                async () =>
                {
                    _versionCheckResult = await VersionCheckHelper.CheckAvailableVersionAsync(
                        _package, _solutionItemHelper.Solution, _solutionSettingsStoreService);
                });

            _ = ThreadHelper.JoinableTaskFactory.RunAsync(
                async () =>
                {
                    try
                    {
                        await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

                        if (_solutionItemHelper.HasNoSelectedItems)
                        {
                            ShowMessage(ResourceMessage.ReqInfoMessagesStore[ReqInfoCodeType.RF0003], MessageBoxImage.Warning);

                            return;
                        }

                        CreateUserSelectedOperation();
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(ErrorCodeType.E0003, ex);
                        ShowMessage(ex.Message, MessageBoxImage.Error);

                        EndWaitDialog();
                    }
                }
            );
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Creates user selected operation.
        /// </summary>
        ///
        /// =================================================================================================
        private void CreateUserSelectedOperation()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var storedSettings = _mediatRSettingsStoreService.GetAllSettingsByProject(_solutionItemHelper.SelectedProject);
            var messageSettingsWindow = new MediatRItemExtensionWindow(storedSettings, _versionCheckResult, _solutionItemHelper);
            var windowResult = WindowHelper.ShowModal(messageSettingsWindow);

            if (windowResult.IsSuccessExecution())
            {
                _waitDialog.StartWaitDialog(
                    "Add MediatR implementation",
                    "Please wait...",
                    "Adding required file is in process. Wait a moment...",
                    0,
                    "MediatR implementation...",
                    0,
                    false,
                    true
                );

                var itemCreation = messageSettingsWindow.GetCreateOperationData();
                BuildUserOperationHelper.CreateDefinedOperations(_solutionItemHelper, itemCreation);

                _mediatRSettingsStoreService.SaveUserSettings(_solutionItemHelper.SelectedProject, new UserProjectSettings
                {
                    IsOneFolder = itemCreation.IsOneFolder,
                    IsOneFile = itemCreation.IsOneFile,
                    IsOperationHandlerInOneFile = itemCreation.IsOperationHandlerInOneFile,
                    CreateValidatorClass = itemCreation.CreateValidatorClass,
                    CreateFolder = itemCreation.CreateFolder,
                    CreateHandlerClass = itemCreation.CreateHandlerClass,
                    CreateOperationClass = itemCreation.CreateOperationClass,
                    OperationProcessing = itemCreation.OperationProcessing.ToString(),
                    IsAutoImportUsingReferences = itemCreation.IsAutoImportUsingReferences
                });

                _waitDialog.EndWaitDialog();
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Ends wait dialog.
        /// </summary>
        /// =================================================================================================
        private void EndWaitDialog()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            _waitDialog.HasCanceled(out var dialogCanceled);

            if (dialogCanceled.IsFalse())
                _waitDialog.EndWaitDialog();
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Shows the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="messageBoxImage">The message box image.</param>
        /// =================================================================================================
        private static void ShowMessage(string message, MessageBoxImage messageBoxImage)
        {
            MessageBox.Show(message, messageBoxImage.ToString(), MessageBoxButton.OK, messageBoxImage);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets solution item.
        /// </summary>
        /// <returns>
        ///     The solution item.
        /// </returns>
        /// =================================================================================================
        private SolutionItemHelper GetSolutionItem()
        {
            try
            {
                DTE localDte = null;
                ThreadHelper.JoinableTaskFactory.Run(
                    async () =>
                    {
                        await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

                        localDte = await AsyncServiceProvider.GetServiceAsync(typeof(DTE)) as DTE;
                        Assumes.Present(localDte);

                        await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
                    });

                return new SolutionItemHelper(localDte);
            }
            catch (Exception e)
            {
                LoggerFile.Log(e);

                return null;
            }
        }
    }
}