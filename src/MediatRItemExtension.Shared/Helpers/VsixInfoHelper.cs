// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2025-03-02 17:51
// 
//  Last Modified By : RzR
//  Last Modified On : 2025-03-02 18:00
// ***********************************************************************
//  <copyright file="VsixInfoHelper.cs" company="RzR SOFT & TECH">
//   Copyright © RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using MediatRItemExtension.Extensions.DataType;
using MediatRItemExtension.Models;

// ReSharper disable IdentifierTypo

#endregion

namespace MediatRItemExtension.Helpers
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A vsix information helper.
    /// </summary>
    /// =================================================================================================
    internal class VsixInfoHelper
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the instance.
        /// </summary>
        /// =================================================================================================
        public static readonly VsixInfoHelper Instance = new VsixInfoHelper();

        /// Cached result from the first successful manifest parse; null until loaded.
        private VsixInfo _cachedManifest;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the manifest. Returns a cached instance after the first successful load.
        ///     Returns null on any failure so callers must null-check the result.
        /// </summary>
        /// <returns>
        ///     The manifest, or null if the manifest could not be loaded.
        /// </returns>
        /// =================================================================================================
        public VsixInfo GetManifest()
        {
            if (_cachedManifest.IsNotNull())
                return _cachedManifest;

            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var assemblyUri = new UriBuilder(assembly.CodeBase);
                var assemblyPath = Uri.UnescapeDataString(assemblyUri.Path);
                var assemblyDirectory = Path.GetDirectoryName(assemblyPath);

                _cachedManifest = GetVsixInfo(assemblyDirectory, "extension.vsixmanifest");

                return _cachedManifest;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);

                return null;
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets vsix information from the manifest file at the given directory.
        ///     Returns null if any required node or attribute is missing or malformed.
        /// </summary>
        /// <param name="currentDirectory">Pathname of the current directory.</param>
        /// <param name="manifestName">Name of the manifest.</param>
        /// <returns>
        ///     The vsix information, or null if the manifest cannot be parsed.
        /// </returns>
        /// =================================================================================================
        private VsixInfo GetVsixInfo(string currentDirectory, string manifestName)
        {
            var manifest = Path.Combine(currentDirectory, manifestName);
            var doc = new XmlDocument();
            doc.Load(manifest);

            if (doc.DocumentElement.IsNull() || doc.DocumentElement!.Name != "PackageManifest") 
                return null;

            var metaData = doc.DocumentElement.ChildNodes.Cast<XmlElement>().FirstOrDefault(x => x.Name == "Metadata");
            if (metaData.IsNull()) 
                return null;

            var identity = metaData!.ChildNodes.Cast<XmlElement>().FirstOrDefault(x => x.Name == "Identity");
            if (identity.IsNull()) 
                return null;

            var displayName = metaData.ChildNodes.Cast<XmlElement>().FirstOrDefault(x => x.Name == "DisplayName");
            if (displayName.IsNull()) 
                return null;

            var moreInfo = metaData.ChildNodes.Cast<XmlElement>().FirstOrDefault(x => x.Name == "MoreInfo");
            if (moreInfo.IsNull())
                return null;

            var rawId = identity!.GetAttribute("Id");
            if (string.IsNullOrEmpty(rawId)) 
                return null;

            var idParts = rawId.Split('.');
            if (idParts.Length < 2) 
                return null;

            if (!Guid.TryParse(idParts[1], out var parsedGuid)) 
                return null;

            return new VsixInfo
            {
                Id = parsedGuid,
                PackageId = rawId,
                Version = identity.GetAttribute("Version"),
                LocalPath = currentDirectory,
                DisplayName = displayName!.InnerText,
                MoreInfoUrl = moreInfo!.InnerText
            };
        }
    }
}