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
using System.Text.RegularExpressions;
using System.Windows;
using MediatRItemExtension.Enums;
using MediatRItemExtension.Enums.Codes;
using MediatRItemExtension.Extensions.DataType;
using MediatRItemExtension.Helpers;
using MediatRItemExtension.Models;
using Microsoft.VisualStudio.PlatformUI;
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
        private bool _isOneFile;
        private bool _isOneFolder;
        private bool _isOperationHandlerInOneFile;
        private ObjectNameValue<OperationType> _selectedOperation;
        private ObjectNameValue<ProcessType> _selectedProcessOperation;
        private string _txTFolderFileName;
        private string _txTResponseTypeName;
        private string _txtOperationInheritance;
        private bool _isWithHandler;
        private bool _isWithValidator;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="MediatRItemExtensionWindow" /> class.
        /// </summary>
        /// <param name="projectSettings">The project settings.</param>
        /// =================================================================================================
        public MediatRItemExtensionWindow(UserProjectSettings projectSettings)
        {
            InitializeComponent();

            InitDefaultArraysValue();
            InitDefaultValues(projectSettings);

            Loaded += (sender, args) =>
            {
                Title = "MediatR Items Creation";
                Icon = InitResources.Base64Ico.ToBitmapImage();
            };

            DataContext = this;
        }

        public ObjectNameValue<OperationType>[] Operations { get; set; }

        public ObjectNameValue<ProcessType>[] ProcessOperations { get; set; }

        public string TxTFolderFileName
        {
            get => _txTFolderFileName;
            set
            {
                _txTFolderFileName = value;
                OnPropertyChanged(nameof(TxTFolderFileName));
                OnPropertyChanged(nameof(TxTResponseTypeName));
                OnPropertyChanged(nameof(IsFormValid));
            }
        }

        public string TxTResponseTypeName
        {
            get => _txTResponseTypeName;
            set
            {
                _txTResponseTypeName = value;
                OnPropertyChanged(nameof(TxTResponseTypeName));
                OnPropertyChanged(nameof(TxTFolderFileName));
                OnPropertyChanged(nameof(IsFormValid));
            }
        }

        public string TxTOperationInheritance
        {
            get => _txtOperationInheritance;
            set
            {
                _txtOperationInheritance = value;
                OnPropertyChanged(nameof(TxTOperationInheritance));
            }
        }

        public ObjectNameValue<OperationType> SelectedOperation
        {
            get => _selectedOperation;
            set
            {
                _selectedOperation = value;
                OnPropertyChanged(nameof(SelectedOperation));
            }
        }

        public ObjectNameValue<ProcessType> SelectedProcessOperation
        {
            get => _selectedProcessOperation;
            set
            {
                _selectedProcessOperation = value;
                OnPropertyChanged(nameof(SelectedProcessOperation));
            }
        }

        public bool IsWithFolder { get; set; }

        public bool IsWithOperation { get; set; }

        public bool IsWithHandler
        {
            get => _isWithHandler;
            set
            {
                if (value == _isWithHandler) return;
                _isWithHandler = value;
                IsEnabledHandlerWithLocalizationImport = value.IsTrue();
                IsHandlerWithLocalizationImport = false;

                OnPropertyChanged(nameof(IsHandlerWithLocalizationImport));
                OnPropertyChanged(nameof(IsEnabledHandlerWithLocalizationImport));
                OnPropertyChanged(nameof(IsWithHandler));
            }
        }

        public bool IsWithValidator
        {
            get => _isWithValidator;
            set
            {
                if (value == _isWithValidator) return;
                _isWithValidator = value;
                IsEnabledValidatorWithLocalizationImport = value.IsTrue();
                IsValidatorWithLocalizationImport = false;

                OnPropertyChanged(nameof(IsValidatorWithLocalizationImport));
                OnPropertyChanged(nameof(IsEnabledValidatorWithLocalizationImport));
                OnPropertyChanged(nameof(IsWithValidator));
            }
        }

        public bool IsOneFile
        {
            get => _isOneFile;
            set
            {
                _isOneFile = value;
                if (_isOneFile.IsTrue())
                {
                    IsOperationHandlerInOneFile = false;

                    OnPropertyChanged(nameof(IsOperationHandlerInOneFile));
                }
            }
        }

        public bool IsAutoImportUsing { get; set; }

        public bool IsValidatorWithLocalizationImport { get; set; }

        public bool IsEnabledValidatorWithLocalizationImport { get; set; }

        public bool IsHandlerWithLocalizationImport { get; set; }

        public bool IsEnabledHandlerWithLocalizationImport { get; set; }

        public bool IsOneFolder
        {
            get => _isOneFolder;
            set
            {
                _isOneFolder = value;
                if (_isOneFolder.IsTrue())
                {
                    IsWithFolder = true;
                    OnPropertyChanged(nameof(IsWithFolder));
                }
            }
        }

        public bool IsOperationHandlerInOneFile
        {
            get => _isOperationHandlerInOneFile;
            set
            {
                _isOperationHandlerInOneFile = value;
                if (_isOperationHandlerInOneFile.IsTrue())
                {
                    IsOneFile = false;

                    OnPropertyChanged(nameof(IsOneFile));
                    OnPropertyChanged(nameof(IsOperationHandlerInOneFile));
                }
            }
        }

        public bool IsFormValid => TxTFolderFileName.IsPresent() && TxTResponseTypeName.IsPresent()
                                                                 && Regex.Match(TxTFolderFileName ?? "",
                                                                         @"^[a-zA-Z0-9\\_]+$", RegexOptions.IgnoreCase)
                                                                     .Success.IsTrue();

        /// <inheritdoc />
        public string this[string columnName]
        {
            get
            {
                var error = string.Empty;
                switch (columnName)
                {
                    case nameof(TxTFolderFileName):
                        if (TxTFolderFileName.IsMissing())
                            error = ResourceMessage.ReqInfoMessagesStore[ReqInfoCodeType.RF0001];
                        break;
                    case nameof(TxTResponseTypeName):
                        if (TxTResponseTypeName.IsMissing())
                            error = ResourceMessage.ReqInfoMessagesStore[ReqInfoCodeType.RF0002];
                        break;
                }

                OnPropertyChanged(nameof(IsFormValid));

                return error;
            }
        }

        /// <inheritdoc/>
        public string Error { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Occurs when Property Changed.
        /// </summary>
        ///
        /// ### <inheritdoc/>
        /// =================================================================================================
        public event PropertyChangedEventHandler PropertyChanged;

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
                OperationInheritance = TxTOperationInheritance
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
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Executes the 'property changed' action.
        /// </summary>
        /// <param name="property">(Optional) The property.</param>
        /// =================================================================================================
        private void OnPropertyChanged(string property = "")
        {
            if (PropertyChanged.IsNotNull())
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
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
    }
}