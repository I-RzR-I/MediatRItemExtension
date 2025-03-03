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

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the manifest.
        /// </summary>
        /// <returns>
        ///     The manifest.
        /// </returns>
        /// =================================================================================================
        public VsixInfo GetManifest()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyUri = new UriBuilder(assembly.CodeBase);
            var assemblyPath = Uri.UnescapeDataString(assemblyUri.Path);
            var assemblyDirectory = Path.GetDirectoryName(assemblyPath);

            return GetVsixInfo(assemblyDirectory, "extension.vsixmanifest");
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets vsix information.
        /// </summary>
        /// <param name="currentDirectory">Pathname of the current directory.</param>
        /// <param name="manifestName">Name of the manifest.</param>
        /// <returns>
        ///     The vsix information.
        /// </returns>
        /// =================================================================================================
        private VsixInfo GetVsixInfo(string currentDirectory, string manifestName)
        {
            var manifest = Path.Combine(currentDirectory, manifestName);
            var doc = new XmlDocument();
            doc.Load(manifest);

            if (doc.DocumentElement.IsNull() || doc.DocumentElement!.Name != "PackageManifest") return null;

            var metaData = doc.DocumentElement.ChildNodes.Cast<XmlElement>().First(x => x.Name == "Metadata");
            var identity = metaData.ChildNodes.Cast<XmlElement>().First(x => x.Name == "Identity");
            var displayName = metaData.ChildNodes.Cast<XmlElement>().First(x => x.Name == "DisplayName");

            return new VsixInfo
            {
                Id = Guid.Parse(identity.GetAttribute("Id").Split('.')[1]),
                PackageId = identity.GetAttribute("Id"),
                Version = identity.GetAttribute("Version"),
                LocalPath = currentDirectory,
                DisplayName = displayName.InnerText
            };
        }
    }
}