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
using System.Windows;
using MediatRItemExtension.Enums;
using MediatRItemExtension.Extensions.DataType;
using MediatRItemExtension.Helpers;
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
        ///     Event handler. Called by Ok for click events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Routed event information.</param>
        /// =================================================================================================
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            if (CheckExecResultPath().IsFalse()) return;

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
    }
}