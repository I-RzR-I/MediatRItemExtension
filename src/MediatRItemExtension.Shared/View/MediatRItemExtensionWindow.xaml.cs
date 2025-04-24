// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-17 18:14
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-18 08:44
// ***********************************************************************
//  <copyright file="MediatRItemExtensionWindow.xaml.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System.ComponentModel;
using System.Linq;
using System.Windows;
using MediatRItemExtension.Enums;
using MediatRItemExtension.Extensions.DataType;
using MediatRItemExtension.Helpers;
using MediatRItemExtension.Helpers.Window.Controls;
using MediatRItemExtension.Models;
using Microsoft.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Shell;

// ReSharper disable RedundantExtendsListEntry
// ReSharper disable UnusedParameter.Local
// ReSharper disable UnusedAutoPropertyAccessor.Global

#endregion

namespace MediatRItemExtension.View
{
    /// <summary>
    ///     Interaction logic for MediatRItemExtensionWindow.xaml
    /// </summary>
    public partial class MediatRItemExtensionWindow : DialogWindow, INotifyPropertyChanged, IDataErrorInfo
    {
        /// <summary>
        ///     Solution selected item helper
        /// </summary>
        private readonly SolutionItemHelper _solutionItemHelper;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="MediatRItemExtensionWindow" /> class.
        /// </summary>
        /// <param name="projectSettings">The project settings.</param>
        /// <param name="versionCheckResult">The version check result.</param>
        /// <param name="solutionItemHelper">Solution selection helper</param>
        /// =================================================================================================
        public MediatRItemExtensionWindow(
            UserProjectSettings projectSettings, 
            VersionCheckResultType versionCheckResult, 
            SolutionItemHelper solutionItemHelper)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            _solutionItemHelper = solutionItemHelper;

            InitializeComponent();
            InitDefaultArraysValue();
            InitDefaultValues(projectSettings);

            var vsix = VsixInfoHelper.Instance.GetManifest();
            Loaded += (sender, args) => { InitFieldsInfo(vsix, versionCheckResult); };
            
            DataContext = this;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets create operation data.
        /// </summary>
        /// <returns>
        ///     The create operation data.
        /// </returns>
        /// =================================================================================================
        internal CreateOperation GetCreateOperationData()
        {
            return new CreateOperation
            {
                FolderFileName = _txTFolderFileName,
                ResponseTypeName = _txTResponseTypeName,

                Operation = SelectedOperation.Value,
                OperationProcessing = SelectedProcessOperation.Value,

                CreateFolder = IsWithFolder,
                CreateOperationClass = IsWithOperation,
                CreateHandlerClass = IsWithHandler,
                CreateValidatorClass = IsWithValidator,
                IsOneFile = IsOneFile,
                IsAutoImportUsingReferences = IsAutoImportUsing,
                IsOneFolder = IsOneFolder,
                IsOperationHandlerInOneFile = IsOperationHandlerInOneFile,
                IsHandlerWithLocalizationImport = IsHandlerWithLocalizationImport,
                IsValidatorWithLocalizationImport = IsValidatorWithLocalizationImport,
                OperationInheritance = TxTOperationInheritance,
                HandlerInheritance = TxTHandlerInheritance
            };
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Event handler. Called by Ok for click events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Routed event information.</param>
        /// =================================================================================================
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Event handler. Called by Cancel for click events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Routed event information.</param>
        /// =================================================================================================
        private void Cancel_Click(object sender, RoutedEventArgs e) => Close();

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes the default arrays value.
        /// </summary>
        /// =================================================================================================
        private void InitDefaultArraysValue()
        {
            Operations = EnumExtensions.ToNameValues<OperationType>().ToArray();
            ProcessOperations = EnumExtensions.ToNameValues<ProcessType>().ToArray();
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes the default values.
        /// </summary>
        /// <param name="projectSettings">(Optional) The project settings.</param>
        /// =================================================================================================
        private void InitDefaultValues(UserProjectSettings projectSettings = null)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            TxTCurrentSelectedPath.Text = _solutionItemHelper.SelectedPath;
         
            TxTFolderFileName = string.Empty;
            TxTResponseTypeName = string.Empty;

            if (projectSettings.IsNotNull())
            {
                SelectedOperation = Operations.First(x => x.Value == OperationType.Query);
                var opProcess = ProcessOperations.FirstOrDefault(x => x.Name ==
                                                                      ((projectSettings?.OperationProcessing ?? "")
                                                                          .IsNullOrEmpty()
                                                                              ? ProcessType.Async.ToString()
                                                                              : projectSettings?.OperationProcessing));
                SelectedProcessOperation = opProcess.IsNull()
                    ? ProcessOperations.First(x => x.Value == ProcessType.Async)
                    : opProcess;
                IsOneFolder = projectSettings!.IsOneFolder;
                IsOneFile = projectSettings.IsOneFile;
                IsOperationHandlerInOneFile = projectSettings.IsOperationHandlerInOneFile;

                IsWithFolder = projectSettings.CreateFolder;
                IsWithOperation = projectSettings.CreateOperationClass;
                IsWithHandler = projectSettings.CreateHandlerClass;
                IsWithValidator = projectSettings.CreateValidatorClass;
                IsAutoImportUsing = projectSettings.IsAutoImportUsingReferences;
            }
            else
            {
                SelectedOperation = Operations.First(x => x.Value == OperationType.Query);
                SelectedProcessOperation = ProcessOperations.First(x => x.Value == ProcessType.Async);
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes the fields information.
        /// </summary>
        /// <param name="vsix">The vsix manifest info.</param>
        /// <param name="versionCheckResult">The version check result.</param>
        /// =================================================================================================
        private void InitFieldsInfo(VsixInfo vsix, VersionCheckResultType versionCheckResult)
        {
            Title = "MediatR Items Creation";
            Icon = InitResources.Base64Ico.ToBitmapImage();

            TextBoxContentHelper.SetTxtBlockTextValue(ref TxtBlockVersion, $"v{vsix.Version}");
            TextBoxContentHelper.SetTxtBlockAuthorWithLink(ref TxtBlockAuthor, InitResources.Author, vsix.MoreInfoUrl);
            TextBoxContentHelper.SetTxtBlockValidationStatus(ref TxtBlockVersionStatus, versionCheckResult);
        }
    }
}