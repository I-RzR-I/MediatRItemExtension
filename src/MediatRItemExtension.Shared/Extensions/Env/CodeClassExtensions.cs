// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-14 16:11
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-14 19:22
// ***********************************************************************
//  <copyright file="CodeClassExtensions.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System.Collections.Generic;
using EnvDTE;
using MediatRItemExtension.Extensions.DataType;
using MediatRItemExtension.Helpers;
using Microsoft.VisualStudio.Shell;

#endregion

namespace MediatRItemExtension.Extensions.Env
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A code class extensions.
    /// </summary>
    /// =================================================================================================
    internal static class CodeClassExtensions
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     The CodeClass extension method that adds the class inheritance to 'insertValue'.
        /// </summary>
        /// <param name="codeClass">The codeClass to act on.</param>
        /// <param name="insertValue">The insert value.</param>
        /// <returns>
        ///     The CodeClass.
        /// </returns>
        /// =================================================================================================
        internal static CodeClass AddClassInheritance(this CodeClass codeClass, string insertValue)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            ThrowHelper.IfNullArgumentNullException(codeClass, nameof(codeClass));

            var editPoint = codeClass.StartPoint.CreateEditPoint();
            editPoint.EndOfLine();
            editPoint.Insert(insertValue);

            return codeClass;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     The CodeClass extension method that adds a default constructor.
        /// </summary>
        /// <param name="codeClass">The codeClass to act on.</param>
        /// <returns>
        ///     The CodeClass.
        /// </returns>
        /// =================================================================================================
        internal static CodeClass AddDefaultConstructor(this CodeClass codeClass)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            ThrowHelper.IfNullArgumentNullException(codeClass, nameof(codeClass));

            codeClass.AddFunction(
                Name: codeClass.Name,
                Kind: vsCMFunction.vsCMFunctionConstructor,
                Type: vsCMTypeRef.vsCMTypeRefVoid,
                Position: 0,
                Access: vsCMAccess.vsCMAccessPublic);

            return codeClass;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     The CodeClass extension method that adds a default constructor.
        /// </summary>
        /// <param name="codeClass">The codeClass to act on.</param>
        /// <param name="ctorParams">Constructor parameters</param>
        /// <returns>
        ///     The CodeClass.
        /// </returns>
        /// =================================================================================================
        internal static CodeClass AddDefaultConstructor(this CodeClass codeClass, IDictionary<string, string> ctorParams)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            ThrowHelper.IfNullArgumentNullException(codeClass, nameof(codeClass));

            var codeFunction = codeClass.AddFunction(
                Name: codeClass.Name,
                Kind: vsCMFunction.vsCMFunctionConstructor,
                Type: vsCMTypeRef.vsCMTypeRefVoid,
                Position: 0,
                Access: vsCMAccess.vsCMAccessPublic);

            if (ctorParams.IsNotNull() && ctorParams.Count > 0)
            {
                foreach (var item in ctorParams)
                {
                    codeFunction.AddParameter(item.Value, item.Key, -1);
                }
            }

            return codeClass;
        }
    }
}