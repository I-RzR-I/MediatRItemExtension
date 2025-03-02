// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-14 16:11
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-14 19:23
// ***********************************************************************
//  <copyright file="ProjectItemsExtensions.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using EnvDTE;
using MediatRItemExtension.Helpers;
using Microsoft.VisualStudio.Shell;

#endregion

namespace MediatRItemExtension.Extensions.Env
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A project items extensions.
    /// </summary>
    /// =================================================================================================
    internal static class ProjectItemsExtensions
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A ProjectItem extension method that searches for the first code class by name.
        /// </summary>
        /// <param name="projectItem">The projectItem to act on.</param>
        /// <param name="className">Name of the class.</param>
        /// <returns>
        ///     The found code class by name.
        /// </returns>
        /// =================================================================================================
        internal static CodeClass FindCodeClassByName(this ProjectItem projectItem, string className)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            ThrowHelper.IfNullArgumentNullException(projectItem, nameof(projectItem));
            ThrowHelper.IfNullArgumentNullException(className, nameof(className));

            foreach (var codeElement in projectItem.FileCodeModel.CodeElements)
            {
                if (!(codeElement is CodeNamespace codeNamespace)) continue;

                foreach (var child in codeNamespace.Children)
                    if (child is CodeClass codeClass && codeClass.Name == className)
                        return codeClass;
            }

            return null;
        }
    }
}