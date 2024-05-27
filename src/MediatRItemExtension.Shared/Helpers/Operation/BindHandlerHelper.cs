// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-14 17:20
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-14 23:48
// ***********************************************************************
//  <copyright file="BindHandlerHelper.cs" company="">
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
using MediatRItemExtension.Models;
using Microsoft.VisualStudio.Shell;

#endregion

namespace MediatRItemExtension.Helpers.Operation
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A bind handler helper.
    /// </summary>
    /// =================================================================================================
    internal static class BindHandlerHelper
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Creates request handler in new file.
        /// </summary>
        /// <param name="folderProjectItems">The folder project items.</param>
        /// <param name="model">The model.</param>
        /// <param name="defaultClassTemplate">The default class template.</param>
        /// =================================================================================================
        internal static void CreateRequestHandlerInNewFile(ProjectItems folderProjectItems, CreateOperation model,
            string defaultClassTemplate)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                var handlerProjectItem =
                    folderProjectItems.AddFromTemplate(defaultClassTemplate, $"{model.HandlerName}.cs");
                var handlerCodeClass = handlerProjectItem.FindCodeClassByName(model.HandlerName);
                handlerCodeClass.Access = vsCMAccess.vsCMAccessPublic;

                AdjustRequestHandler(handlerCodeClass, model);
            }
            catch (Exception ex)
            {
                Logger.Log(ErrorCodeType.E0008, ex);
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Adds a handler implementation to file to 'model'.
        /// </summary>
        /// <param name="codeClass">The code class.</param>
        /// <param name="model">The model.</param>
        /// =================================================================================================
        internal static void AddHandlerImplementationToFile(CodeClass codeClass, CreateOperation model)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                var handlerCodeClass = codeClass.Namespace.AddClass(
                    model.HandlerName,
                    -1,
                    Access: vsCMAccess.vsCMAccessPublic);

                AdjustRequestHandler(handlerCodeClass, model);
            }
            catch (Exception ex)
            {
                Logger.Log(ErrorCodeType.E0008, ex);
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Handler, called when the adjust request.
        /// </summary>
        /// <param name="codeClass">The code class.</param>
        /// <param name="model">The model.</param>
        /// =================================================================================================
        private static void AdjustRequestHandler(CodeClass codeClass, CreateOperation model)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                var fileCodeModel = codeClass.Namespace.Parent as FileCodeModel2;

                if (model.IsAutoImportUsingReferences.IsTrue())
                    fileCodeModel.AddUsingIfNotExist(model.OperationProcessing == ProcessType.Sync
                        ? InitResources.DefaultUsing.DefaultSyncHandler
                        : InitResources.DefaultUsing.DefaultAsyncHandler);

                codeClass.AddClassInheritance(model.HandlerInterface);

                codeClass.AddDefaultConstructor();

                AddHandlerImplementation(codeClass, model);
            }
            catch (Exception ex)
            {
                Logger.Log(ErrorCodeType.E0007, ex);
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Adds a handler function to request handler to 'model'.
        /// </summary>
        /// <param name="codeClass">The code class.</param>
        /// <param name="model">The model.</param>
        /// =================================================================================================
        private static void AddHandlerImplementation(CodeClass codeClass, CreateOperation model)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                var handler = codeClass.AddFunction(
                    "Handle",
                    vsCMFunction.vsCMFunctionFunction,
                    model.HandlerHandleReturnValueName,
                    -1);

                handler.AddParameter("request", model.OperationName, -1);
                if (model.OperationProcessing == ProcessType.Async)
                    handler.AddParameter("cancellationToken", "CancellationToken", -1);

                handler.StartPoint.CreateEditPoint().ReplaceText(0, model.HandlerAccessor,
                    (int)vsEPReplaceTextOptions.vsEPReplaceTextAutoformat);
                handler.GetStartPoint(vsCMPart.vsCMPartBody).CreateEditPoint()
                    .Insert(model.RequestHandlerIndent + "throw new NotImplementedException();");
            }
            catch (Exception ex)
            {
                Logger.Log(ErrorCodeType.E0006, ex);
            }
        }
    }
}