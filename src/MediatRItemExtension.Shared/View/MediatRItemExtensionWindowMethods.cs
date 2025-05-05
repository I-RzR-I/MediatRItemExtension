// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2025-05-04 20:09
// 
//  Last Modified By : RzR
//  Last Modified On : 2025-05-04 22:25
// ***********************************************************************
//  <copyright file="MediatRItemExtensionWindowMethods.cs" company="RzR SOFT & TECH">
//   Copyright © RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System.Linq;
using System.Windows;
using MediatRItemExtension.Enums;
using MediatRItemExtension.Enums.Codes;
using MediatRItemExtension.Extensions.DataType;
using MediatRItemExtension.Helpers;
using MediatRItemExtension.Helpers.Localization;
using MediatRItemExtension.Helpers.Window.Controls;
using MediatRItemExtension.Models;
using Microsoft.VisualStudio.Shell;

#endregion

namespace MediatRItemExtension.View
{
    /// <inheritdoc cref="MediatRItemExtensionWindow"/>
    public partial class MediatRItemExtensionWindow
    {
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

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Check if result path length exceed allowed limit.
        /// </summary>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        /// =================================================================================================
        private bool CheckExecResultPath()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var path = _solutionItemHelper.SelectedOriginFullPath;
            var tmpInitValues = GetCreateOperationData();
            if (path.IsMissing()) return true;

            var generalPathLength = path.Length + tmpInitValues.FolderFileName.Length;
            var requestPathLength = generalPathLength + tmpInitValues.OperationName.Length;
            var handlerPathLength = generalPathLength + tmpInitValues.HandlerName.Length;
            var validatorPathLength = generalPathLength + tmpInitValues.ValidatorName.Length;
            if (requestPathLength >= 248
                || (tmpInitValues.IsOneFolder.IsTrue() && handlerPathLength >= 248)
                || (tmpInitValues.IsOneFolder.IsTrue() && validatorPathLength >= 248))
                if (MessageBox.Show(
                        ResourceMessage.ErrorMessagesStore[ErrorCodeType.E0013],
                        ResourceMessage.ErrorMessagesStore[ErrorCodeType.E0012],
                        MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                    return false;

            return true;
        }
    }
}