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
using MediatRItemExtension.Extensions.DataType;
using MediatRItemExtension.Helpers;
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

            _waitDialog = _package.GetService<SVsThreadedWaitDialog, IVsThreadedWaitDialog2>();
            Assumes.Present(_waitDialog);

            var menuCommandId = new CommandID(InitResources.CommandSet, InitResources.CommandId);
            var menuItem = new MenuCommand(Execute, menuCommandId);
            commandService.AddCommand(menuItem);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the service provider.
        /// </summary>
        /// <value>
        ///     The service provider.
        /// </value>
        /// =================================================================================================
        private IAsyncServiceProvider ServiceProvider => _package;

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
            _ = ThreadHelper.JoinableTaskFactory.RunAsync(
                async () =>
                {
                    try
                    {
                        await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
                        var dte = await ServiceProvider.GetServiceAsync(typeof(DTE)) as DTE;
                        Assumes.Present(dte);
                        var slnItem = new SolutionItemHelper(dte);

                        if (slnItem.HasNoSelectedItems)
                        {
                            ShowMessage(ResourceMessage.FolderProjectNotSelected, MessageBoxImage.Warning);

                            return;
                        }

                        CreateUserSelectedOperation(slnItem);
                    }
                    catch (Exception ex)
                    {
                        EndWaitDialog();
                        ShowMessage(ex.Message, MessageBoxImage.Error);
                    }
                }
            );
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Creates user selected operation.
        /// </summary>
        /// <param name="slnItem">The selection item.</param>
        /// =================================================================================================
        private void CreateUserSelectedOperation(SolutionItemHelper slnItem)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var storedSettings = _mediatRSettingsStoreService.GetAllSettingsByProject(slnItem.SelectedProject);
            var messageSettingsWindow = new MediatRItemExtensionWindow(storedSettings);
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
                BuildUserOperationHelper.CreateDefinedOperations(slnItem, itemCreation);

                _mediatRSettingsStoreService.SaveUserSettings(slnItem.SelectedProject, new UserProjectSettings
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
    }
}