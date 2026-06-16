// ***********************************************************************
//  Assembly          : MediatRItemExtension.MediatRItemExtensionV2K19
//  Author            : RzR
//  Created           : 16-06-2026 20:06
// 
//  Last Modified By : RzR
//  Last Modified On : 16-06-2026 20:50
//  ***********************************************************************
//  <copyright file="GeneratedFileInfo.cs" company="RzR SOFT & TECH">
//      Copyright (c) RzR. All rights reserved.
//  </copyright>
//  <contact>
//      https://iamrzr.dev/contact
//  </contact>
//  <summary></summary>
//  ***********************************************************************

#region U S I N G

using MediatRItemExtension.Enums.Codes;

#endregion

namespace MediatRItemExtension.Models
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Describes a file that the extension will generate. Used for pre-generation
    ///     existence/collision validation in the no-folder case.
    /// </summary>
    /// =================================================================================================
    internal sealed class GeneratedFileInfo
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="GeneratedFileInfo" /> class.
        /// </summary>
        /// <param name="code">The request-info code identifying the artifact kind.</param>
        /// <param name="fileName">The file name (including extension) that would be created.</param>
        /// <param name="typeName">The type name (without extension), used in the validation message.</param>
        /// =================================================================================================
        internal GeneratedFileInfo(ReqInfoCodeType code, string fileName, string typeName)
        {
            Code = code;
            FileName = fileName;
            TypeName = typeName;
        }

        /// <summary>Gets the request-info code identifying the artifact kind (operation/handler/validator).</summary>
        internal ReqInfoCodeType Code { get; }

        /// <summary>Gets the file name (including extension) that would be created.</summary>
        internal string FileName { get; }

        /// <summary>Gets the type name (without extension), used in the validation message.</summary>
        internal string TypeName { get; }
    }
}