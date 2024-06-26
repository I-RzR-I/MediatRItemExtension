﻿// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-08 21:25
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-16 23:31
// ***********************************************************************
//  <copyright file="SolutionItemHelper.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using EnvDTE;
using EnvDTE90;
using MediatRItemExtension.Extensions.DataType;
using Microsoft.VisualStudio.Shell;
// ReSharper disable SuspiciousTypeConversion.Global

#endregion

namespace MediatRItemExtension.Helpers
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A solution item helper. This class cannot be inherited.
    /// </summary>
    /// =================================================================================================
    internal sealed class SolutionItemHelper
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the DTE.
        /// </summary>
        /// =================================================================================================
        private readonly DTE _dte;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     The default class template.
        /// </summary>
        /// =================================================================================================
        private string _defaultClassTemplate;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     The first selected item.
        /// </summary>
        /// =================================================================================================
        private SelectedItem _firstSelectedItem;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     The selected item project items.
        /// </summary>
        /// =================================================================================================
        private ProjectItems _selectedItemProjectItems;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     The selected project.
        /// </summary>
        /// =================================================================================================
        private Project _selectedProject;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="SolutionItemHelper" /> class.
        /// </summary>
        /// <param name="dte">The DTE.</param>
        /// =================================================================================================
        internal SolutionItemHelper(DTE dte)
        {
            ThrowHelper.IfNullArgumentNullException(dte, nameof(dte));

            _dte = dte;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets a value indicating whether this object has no selected items.
        /// </summary>
        /// <value>
        ///     True if this object has no selected items, false if not.
        /// </value>
        /// =================================================================================================
        internal bool HasNoSelectedItems
        {
            get
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                return _dte.SelectedItems?.Count == 0;
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the solution.
        /// </summary>
        /// <value>
        ///     The solution.
        /// </value>
        /// =================================================================================================
        internal Solution3 Solution
        {
            get
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                return _dte.Solution as Solution3;
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the first selected item.
        /// </summary>
        /// <value>
        ///     The first selected item.
        /// </value>
        /// =================================================================================================
        internal SelectedItem FirstSelectedItem
        {
            get
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                if (_firstSelectedItem.IsNull())
                    _firstSelectedItem = HasNoSelectedItems ? null : _dte.SelectedItems?.Item(1);

                return _firstSelectedItem;
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the selected project.
        /// </summary>
        /// <value>
        ///     The selected project.
        /// </value>
        /// =================================================================================================
        internal Project SelectedProject
        {
            get
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                if (_selectedProject.IsNull())
                    _selectedProject = FirstSelectedItem.Project.IsNotNull()
                        ? FirstSelectedItem.Project
                        : FirstSelectedItem?.ProjectItem?.ContainingProject;

                return _selectedProject;
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the default class template.
        /// </summary>
        /// <value>
        ///     The default class template.
        /// </value>
        /// =================================================================================================
        internal string DefaultClassTemplate
        {
            get
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                if (_defaultClassTemplate.IsNull())
                    _defaultClassTemplate = Solution.GetProjectItemTemplate("Class", "CSharp");

                return _defaultClassTemplate;
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the selected item project items.
        /// </summary>
        /// <value>
        ///     The selected item project items.
        /// </value>
        /// =================================================================================================
        internal ProjectItems SelectedItemProjectItems
        {
            get
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                if (_selectedItemProjectItems.IsNull())
                    _selectedItemProjectItems =
                        FirstSelectedItem?.ProjectItem?.ProjectItems ?? SelectedProject?.ProjectItems;

                return _selectedItemProjectItems;
            }
        }
    }
}