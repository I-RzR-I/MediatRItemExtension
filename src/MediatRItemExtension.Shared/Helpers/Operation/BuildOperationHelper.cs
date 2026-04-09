// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-14 17:25
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-14 19:43
// ***********************************************************************
//  <copyright file="BuildOperationHelper.cs" company="">
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
using MediatRItemExtension.Enums;
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
    ///     A build operation helper.
    /// </summary>
    /// =================================================================================================
    internal static class BuildOperationHelper
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Creates request operation (Query/Command/Notification/Stream class).
        /// </summary>
        /// <param name="projectItems">The project items.</param>
        /// <param name="model">The model.</param>
        /// <param name="classTemplate">The class template.</param>
        /// <returns>
        ///     The new request operation.
        /// </returns>
        /// =================================================================================================
        internal static CodeClass CreateRequestOperation(ProjectItems projectItems, CreateOperation model,
            string classTemplate)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                var requestProjectItem = projectItems.AddFromTemplate(classTemplate, $"{model.OperationName}.cs");

                if (model.IsAutoImportUsingReferences.IsTrue())
                    (requestProjectItem.FileCodeModel as FileCodeModel2).AddUsingIfNotExist(InitResources.DefaultUsing
                        .DefaultOperation);

                var codeClass = requestProjectItem.FindCodeClassByName(model.OperationName);
                codeClass.Access = vsCMAccess.vsCMAccessPublic;

                codeClass.AddClassInheritance(model.RequestInterface);

                if (model.OperationBlueprint == OperationBlueprintType.Record)
                {
                    // Convert 'class' keyword to 'record' in the declaration line
                    var editPoint = codeClass.StartPoint.CreateEditPoint();
                    editPoint.StartOfLine();

                    var lineEnd = editPoint.CreateEditPoint();
                    lineEnd.EndOfLine();

                    var declarationLine = editPoint.GetText(lineEnd);
                    editPoint.ReplaceText(lineEnd, declarationLine.ReplaceExact("class ", "record "), 0);
                }

                return codeClass;
            }
            catch (Exception e)
            {
                Logger.Log(ErrorCodeType.E0010, e);

                return null;
            }
        }
    }
}