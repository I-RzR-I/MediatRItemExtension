// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2025-03-02 17:52
// 
//  Last Modified By : RzR
//  Last Modified On : 2025-03-03 07:46
// ***********************************************************************
//  <copyright file="VsixInfo.cs" company="RzR SOFT & TECH">
//   Copyright © RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;

// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable IdentifierTypo

#endregion

namespace MediatRItemExtension.Models
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Information about the vsix.
    /// </summary>
    /// =================================================================================================
    internal class VsixInfo
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        /// =================================================================================================
        public Guid Id { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the identifier of the package.
        /// </summary>
        /// <value>
        ///     The identifier of the package.
        /// </value>
        /// =================================================================================================
        public string PackageId { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the version.
        /// </summary>
        /// <value>
        ///     The version.
        /// </value>
        /// =================================================================================================
        public string Version { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the name of the display.
        /// </summary>
        /// <value>
        ///     The name of the display.
        /// </value>
        /// =================================================================================================
        public string DisplayName { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the full pathname of the local file.
        /// </summary>
        /// <value>
        ///     The full pathname of the local file.
        /// </value>
        /// =================================================================================================
        public string LocalPath { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the more info tag with URL.
        /// </summary>
        /// <value>
        ///     The repository URL.
        /// </value>
        /// =================================================================================================
        public string MoreInfoUrl { get; set; }
    }
}