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

using EnvDTE;
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
            CodeClass classCode = null;
            ThreadHelper.ThrowIfNotOnUIThread();

            var folderProjectItems = GetCurrentSelectedOrCreateNewFolder(slnItemHelper, model);

            if (model.CreateOperationClass.IsTrue())
                classCode = BuildOperationHelper.CreateRequestOperation(folderProjectItems, model,
                    slnItemHelper.DefaultClassTemplate);

            if (model.IsOneFile.IsTrue()) // Create operation | handler | validator in one file
            {
                if (model.CreateHandlerClass.IsTrue() && classCode.IsNotNull())
                    BindHandlerHelper.AddHandlerImplementationToFile(classCode, model);

                if (model.CreateValidatorClass.IsTrue() && classCode.IsNotNull())
                    BindValidatorHelper.AddValidatorImplementationToFile(classCode, model);
            }
            else if (model.IsOperationHandlerInOneFile.IsTrue()) // Create operation | handler in one file
            {
                if (model.CreateHandlerClass.IsTrue() && classCode.IsNotNull())
                    BindHandlerHelper.AddHandlerImplementationToFile(classCode, model);

                if (model.CreateValidatorClass.IsTrue())
                    BindValidatorHelper.CreateRequestValidator(folderProjectItems, model,
                        slnItemHelper.DefaultClassTemplate);
            }
            else
            {
                if (model.CreateHandlerClass.IsTrue())
                    BindHandlerHelper.CreateRequestHandlerInNewFile(folderProjectItems, model,
                        slnItemHelper.DefaultClassTemplate);

                if (model.CreateValidatorClass.IsTrue())
                    BindValidatorHelper.CreateRequestValidator(folderProjectItems, model,
                        slnItemHelper.DefaultClassTemplate);
            }

            slnItemHelper.SelectedProject.Save();
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