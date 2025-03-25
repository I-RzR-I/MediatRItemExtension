// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2025-03-25 22:00
// 
//  Last Modified By : RzR
//  Last Modified On : 2025-03-25 22:03
// ***********************************************************************
//  <copyright file="VersionCheckResult.cs" company="RzR SOFT & TECH">
//   Copyright © RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.Collections.Generic;

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

#endregion

namespace MediatRItemExtension.Models
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Encapsulates the result of a version check.
    /// </summary>
    /// =================================================================================================
    internal class VersionCheckResult
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the results.
        /// </summary>
        /// <value>
        ///     The results.
        /// </value>
        /// =================================================================================================
        public IEnumerable<VersionResult> Results { get; set; }
    }

    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Encapsulates the result of a version.
    /// </summary>
    /// =================================================================================================
    internal class VersionResult
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the extensions.
        /// </summary>
        /// <value>
        ///     The extensions.
        /// </value>
        /// =================================================================================================
        public List<PublishedExtension> Extensions { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the paging token.
        /// </summary>
        /// <value>
        ///     The paging token.
        /// </value>
        /// =================================================================================================
        public string PagingToken { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the result metadata.
        /// </summary>
        /// <value>
        ///     The result metadata.
        /// </value>
        /// =================================================================================================
        public IEnumerable<ExtensionFilterResultMetadata> ResultMetadata { get; set; }
    }

    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A published extension.
    /// </summary>
    /// =================================================================================================
    internal class PublishedExtension
    {
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
        ///     Gets or sets the name of the extension.
        /// </summary>
        /// <value>
        ///     The name of the extension.
        /// </value>
        /// =================================================================================================
        public string ExtensionName { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the Date/Time of the last updated.
        /// </summary>
        /// <value>
        ///     The last updated.
        /// </value>
        /// =================================================================================================
        public DateTime LastUpdated { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the published date.
        /// </summary>
        /// <value>
        ///     The published date.
        /// </value>
        /// =================================================================================================
        public DateTime PublishedDate { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the release date.
        /// </summary>
        /// <value>
        ///     The release date.
        /// </value>
        /// =================================================================================================
        public DateTime ReleaseDate { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the versions.
        /// </summary>
        /// <value>
        ///     The versions.
        /// </value>
        /// =================================================================================================
        public List<ExtensionVersion> Versions { get; set; }
    }

    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     An extension version.
    /// </summary>
    /// =================================================================================================
    internal class ExtensionVersion
    {
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
        ///     Gets or sets the Date/Time of the last updated.
        /// </summary>
        /// <value>
        ///     The last updated.
        /// </value>
        /// =================================================================================================
        public DateTime LastUpdated { get; set; }
    }

    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     An extension filter result metadata.
    /// </summary>
    /// =================================================================================================
    internal class ExtensionFilterResultMetadata
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the type of the metadata.
        /// </summary>
        /// <value>
        ///     The type of the metadata.
        /// </value>
        /// =================================================================================================
        public string MetadataType { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the metadata items.
        /// </summary>
        /// <value>
        ///     The metadata items.
        /// </value>
        /// =================================================================================================
        public List<MetadataItem> MetadataItems { get; set; }
    }

    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A metadata item.
    /// </summary>
    /// =================================================================================================
    internal class MetadataItem
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the number of. 
        /// </summary>
        /// <value>
        ///     The count.
        /// </value>
        /// =================================================================================================
        public int Count { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        /// =================================================================================================
        public string Name { get; set; }
    }
}