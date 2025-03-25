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
using System.Collections.Generic;
using EnvDTE;
using EnvDTE80;
using MediatRItemExtension.Enums.Codes;
using MediatRItemExtension.Extensions.DataType;
using MediatRItemExtension.Extensions.Env;
using MediatRItemExtension.Helpers.LogHelper;
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
    internal class BindValidatorHelper
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) options for controlling the constructor.
        /// </summary>
        /// =================================================================================================
        private static IDictionary<string, string> _constructorValidatorParams;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the instance.
        /// </summary>
        /// <value>
        ///     The instance.
        /// </value>
        /// =================================================================================================
        internal static BindValidatorHelper Instance => new BindValidatorHelper();

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Prevents a default instance of the <see cref="BindValidatorHelper"/> class from being
        ///     created.
        /// </summary>
        /// =================================================================================================
        private BindValidatorHelper() => _constructorValidatorParams = new Dictionary<string, string>();

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Creates request validator (AbstractValidator class).
        /// </summary>
        /// <param name="folderProjectItems">The folder project items.</param>
        /// <param name="model">The model.</param>
        /// <param name="defaultClassTemplate">The default class template.</param>
        /// =================================================================================================
        internal void CreateRequestValidator(ProjectItems folderProjectItems, CreateOperation model,
            string defaultClassTemplate)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                var validationProjectItem =
                    folderProjectItems.AddFromTemplate(defaultClassTemplate, $"{model.ValidatorName}.cs");

                if (model.IsAutoImportUsingReferences.IsTrue())
                    (validationProjectItem.FileCodeModel as FileCodeModel2).AddUsingIfNotExist(InitResources.DefaultUsing.DefaultValidator);

                if (model.IsValidatorWithLocalizationImport.IsTrue())
                {
                    _constructorValidatorParams.AddOrUpdate(InitResources.ClassParams.Localization);
                    (validationProjectItem.FileCodeModel as FileCodeModel2).AddUsingIfNotExist(InitResources.DefaultUsing.DefaultLocalization);
                }

                var codeClass = validationProjectItem.FindCodeClassByName(model.ValidatorName);
                codeClass.Access = vsCMAccess.vsCMAccessPublic;

                codeClass.AddClassInheritance(model.AbstractValidator);

                codeClass.AddDefaultConstructor(_constructorValidatorParams);
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
        internal void AddValidatorImplementationToFile(CodeClass codeClass, CreateOperation model)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                var validatorCodeClass = codeClass.Namespace.AddClass(
                    model.ValidatorName,
                    -1,
                    Access: vsCMAccess.vsCMAccessPublic);

                validatorCodeClass.AddClassInheritance(model.AbstractValidator);

                if (model.IsAutoImportUsingReferences.IsTrue())
                    (codeClass.ProjectItem.FileCodeModel as FileCodeModel2).AddUsingIfNotExist(InitResources.DefaultUsing.DefaultValidator);

                if (model.IsValidatorWithLocalizationImport.IsTrue())
                {
                    _constructorValidatorParams.AddOrUpdate(InitResources.ClassParams.Localization);
                    (codeClass.ProjectItem.FileCodeModel as FileCodeModel2).AddUsingIfNotExist(InitResources.DefaultUsing.DefaultLocalization);
                }

                validatorCodeClass.AddDefaultConstructor(_constructorValidatorParams);
            }
            catch (Exception ex)
            {
                Logger.Log(ErrorCodeType.E0005, ex);
            }
        }
    }
}