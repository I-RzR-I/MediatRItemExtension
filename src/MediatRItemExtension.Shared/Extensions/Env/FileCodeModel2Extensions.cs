// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-14 17:57
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-14 19:22
// ***********************************************************************
//  <copyright file="FileCodeModel2Extensions.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System.Collections.Generic;
using System.Linq;
using EnvDTE80;
using MediatRItemExtension.Helpers;

#endregion

namespace MediatRItemExtension.Extensions.Env
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A file code model 2 extensions.
    /// </summary>
    /// =================================================================================================
    internal static class FileCodeModel2Extensions
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A FileCodeModel2 extension method that adds an using if not exist to
        ///     'usingReferences'.
        /// </summary>
        /// <param name="fileCodeModel">The fileCodeModel to act on.</param>
        /// <param name="usingReferences">The using references.</param>
        /// <returns>
        ///     A FileCodeModel2.
        /// </returns>
        /// =================================================================================================
        internal static FileCodeModel2 AddUsingIfNotExist(this FileCodeModel2 fileCodeModel,
            IEnumerable<string> usingReferences)
        {
            ThrowHelper.IfNullArgumentNullException(fileCodeModel, nameof(fileCodeModel));

            var currentImports = fileCodeModel.CodeElements
                .OfType<CodeImport>()
                .Select(x => x.Namespace)
                .ToList();

            foreach (var import in usingReferences)
                if (currentImports.All(x => x != import))
                    fileCodeModel.AddImport(import, 0);

            return fileCodeModel;
        }
    }
}