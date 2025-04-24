// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2025-04-24 14:42
// 
//  Last Modified By : RzR
//  Last Modified On : 2025-04-24 14:42
// ***********************************************************************
//  <copyright file="MediatRItemExtensionWindowProps.cs" company="RzR SOFT & TECH">
//   Copyright © RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System.ComponentModel;
using System.Text.RegularExpressions;
using MediatRItemExtension.Enums;
using MediatRItemExtension.Enums.Codes;
using MediatRItemExtension.Extensions.DataType;
using MediatRItemExtension.Helpers.Localization;
using MediatRItemExtension.Models;
using Microsoft.VisualStudio.Shell;

// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

#endregion

namespace MediatRItemExtension.View
{
    public partial class MediatRItemExtensionWindow
    {
        #region PRIVATE FIELDS

        private bool _isOneFile;
        private bool _isOneFolder;
        private bool _isOperationHandlerInOneFile;
        private ObjectNameValue<OperationType> _selectedOperation;
        private ObjectNameValue<ProcessType> _selectedProcessOperation;
        private string _txTFolderFileName;
        private string _txTResponseTypeName;
        private string _txtOperationInheritance;
        private string _txtHandlerInheritance;
        private bool _isWithHandler;
        private bool _isWithValidator;
        private bool _isWithOperation;

        #endregion

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

        public string TxTHandlerInheritance
        {
            get => _txtHandlerInheritance;
            set
            {
                _txtHandlerInheritance = value;
                OnPropertyChanged(nameof(TxTHandlerInheritance));
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

        public bool IsWithOperation
        {
            get => _isWithOperation;
            set
            {
                if (value == _isWithOperation) return;
                _isWithOperation = value;

                if (value.IsFalse())
                    TxTOperationInheritance = string.Empty;

                IsEnabledTxTOperationInheritance = value.IsTrue();

                OnPropertyChanged(nameof(IsEnabledTxTOperationInheritance));
                OnPropertyChanged(nameof(IsWithOperation));
            }
        }

        public bool IsWithHandler
        {
            get => _isWithHandler;
            set
            {
                if (value == _isWithHandler) return;
                _isWithHandler = value;

                if (value.IsFalse())
                    TxTHandlerInheritance = string.Empty;

                IsEnabledHandlerWithLocalizationImport = value.IsTrue();
                IsEnabledTxTHandlerInheritance = value.IsTrue();

                IsHandlerWithLocalizationImport = false;

                OnPropertyChanged(nameof(IsHandlerWithLocalizationImport));
                OnPropertyChanged(nameof(IsEnabledTxTHandlerInheritance));
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

        public bool IsEnabledTxTHandlerInheritance { get; set; }

        public bool IsEnabledTxTOperationInheritance { get; set; }

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

        public bool IsFormValid
        {
            get
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                var isValid = TxTFolderFileName.IsPresent()
                    && TxTResponseTypeName.IsPresent()
                    && Regex.Match(TxTFolderFileName ?? "", @"^[a-zA-Z0-9\\_]+$", RegexOptions.IgnoreCase).Success.IsTrue();

                var existFolder = _solutionItemHelper.AlreadyExistItem(TxTFolderFileName);

                return isValid.IsTrue() && existFolder.IsFalse();
            }
        }

        /// <inheritdoc />
        public string this[string columnName]
        {
            get
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                var error = string.Empty;
                switch (columnName)
                {
                    case nameof(TxTFolderFileName):
                        if (TxTFolderFileName.IsMissing())
                            error = ResourceMessage.ReqInfoMessagesStore[ReqInfoCodeType.RF0001];
                        if (_solutionItemHelper.AlreadyExistItem(TxTFolderFileName).IsTrue())
                            error = ResourceMessage.ReqInfoMessagesStore[ReqInfoCodeType.RF0005];
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
        /// =================================================================================================
        public event PropertyChangedEventHandler PropertyChanged;


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
    }
}