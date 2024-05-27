// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-14 17:23
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-14 23:48
// ***********************************************************************
//  <copyright file="BindValidatorHelper.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using EnvDTE;
using EnvDTE80;
using MediatRItemExtension.Enums.Codes;
using MediatRItemExtension.Extensions.DataType;
using MediatRItemExtension.Extensions.Env;
using MediatRItemExtension.Models;
using Microsoft.VisualStudio.Shell;

#endregion

namespace MediatRItemExtension.Helpers.Operation
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A bind validator helper.
    /// </summary>
    /// =================================================================================================
    internal static class BindValidatorHelper
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Creates request validator (AbstractValidator class).
        /// </summary>
        /// <param name="folderProjectItems">The folder project items.</param>
        /// <param name="model">The model.</param>
        /// <param name="defaultClassTemplate">The default class template.</param>
        /// =================================================================================================
        internal static void CreateRequestValidator(ProjectItems folderProjectItems, CreateOperation model,
            string defaultClassTemplate)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                var validationProjectItem =
                    folderProjectItems.AddFromTemplate(defaultClassTemplate, $"{model.ValidatorName}.cs");

                if (model.IsAutoImportUsingReferences.IsTrue())
                    (validationProjectItem.FileCodeModel as FileCodeModel2).AddUsingIfNotExist(InitResources
                        .DefaultUsing
                        .DefaultValidator);

                var codeClass = validationProjectItem.FindCodeClassByName(model.ValidatorName);
                codeClass.Access = vsCMAccess.vsCMAccessPublic;

                codeClass.AddClassInheritance(model.AbstractValidator);

                codeClass.AddDefaultConstructor();
            }
            catch (Exception ex)
            {
                Logger.Log(ErrorCodeType.E0004, ex);
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Adds a validator implementation to file to 'model'.
        /// </summary>
        /// <param name="codeClass">The code class.</param>
        /// <param name="model">The model.</param>
        /// =================================================================================================
        internal static void AddValidatorImplementationToFile(CodeClass codeClass, CreateOperation model)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                var validatorCodeClass = codeClass.Namespace.AddClass(
                    model.ValidatorName,
                    -1,
                    Access: vsCMAccess.vsCMAccessPublic);

                validatorCodeClass.AddClassInheritance(model.AbstractValidator);

                validatorCodeClass.AddDefaultConstructor();

                if (model.IsAutoImportUsingReferences.IsTrue())
                    (codeClass.ProjectItem.FileCodeModel as FileCodeModel2).AddUsingIfNotExist(InitResources.DefaultUsing
                        .DefaultValidator);
            }
            catch (Exception ex)
            {
                Logger.Log(ErrorCodeType.E0005, ex);
            }
        }
    }
}