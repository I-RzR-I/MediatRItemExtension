// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-14 18:02
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-14 23:49
// ***********************************************************************
//  <copyright file="BuildUserOperationHelper.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using EnvDTE;
using MediatRItemExtension.Enums.Codes;
using MediatRItemExtension.Extensions.DataType;
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
    internal static class BuildUserOperationHelper
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Creates defined operations.
        /// </summary>
        /// <param name="slnItemHelper">The selection item helper.</param>
        /// <param name="model">The model.</param>
        /// =================================================================================================
        internal static void CreateDefinedOperations(SolutionItemHelper slnItemHelper, CreateOperation model)
        {
            try
            {
                CodeClass classCode = null;
                ThreadHelper.ThrowIfNotOnUIThread();

                var folderProjectItems = GetCurrentSelectedOrCreateNewFolder(slnItemHelper, model);

                if (model.CreateOperationClass.IsTrue())
                    classCode = BuildOperationHelper.CreateRequestOperation(folderProjectItems, model,
                        slnItemHelper.DefaultClassTemplate);

                var handler = BindHandlerHelper.Instance;
                var validator = BindValidatorHelper.Instance;

                if (model.IsOneFile.IsTrue()) // Create operation | handler | validator in one file
                {
                    if (model.CreateHandlerClass.IsTrue() && classCode.IsNotNull())
                        handler.AddHandlerImplementationToFile(classCode, model);

                    if (model.CreateValidatorClass.IsTrue() && classCode.IsNotNull())
                        validator.AddValidatorImplementationToFile(classCode, model);
                }
                else if (model.IsOperationHandlerInOneFile.IsTrue()) // Create operation | handler in one file
                {
                    if (model.CreateHandlerClass.IsTrue() && classCode.IsNotNull())
                        handler.AddHandlerImplementationToFile(classCode, model);

                    if (model.CreateValidatorClass.IsTrue())
                        validator.CreateRequestValidator(folderProjectItems, model,
                            slnItemHelper.DefaultClassTemplate);
                }
                else
                {
                    if (model.CreateHandlerClass.IsTrue())
                        handler.CreateRequestHandlerInNewFile(folderProjectItems, model,
                            slnItemHelper.DefaultClassTemplate);

                    if (model.CreateValidatorClass.IsTrue())
                        validator.CreateRequestValidator(folderProjectItems, model,
                            slnItemHelper.DefaultClassTemplate);
                }

                slnItemHelper.SelectedProject.Save();
            }
            catch (Exception e)
            {
                Logger.Log(ErrorCodeType.E0002, e, true);
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets current selected or create new folder.
        /// </summary>
        /// <param name="slnItemHelper">The selection item helper.</param>
        /// <param name="model">The model.</param>
        /// <returns>
        ///     The current selected or create new folder.
        /// </returns>
        /// =================================================================================================
        private static ProjectItems GetCurrentSelectedOrCreateNewFolder(SolutionItemHelper slnItemHelper,
            CreateOperation model)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            if (model.CreateFolder.IsFalse() && model.IsOneFolder.IsFalse())
                return slnItemHelper.SelectedItemProjectItems;

            var folderItem = slnItemHelper.SelectedItemProjectItems.AddFolder(model.FolderFileName);

            return folderItem.ProjectItems;
        }
    }
}