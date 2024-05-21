// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-08 21:05
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-10 20:40
// ***********************************************************************
//  <copyright file="MediatRSettingsStoreService.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using EnvDTE;
using MediatRItemExtension.Helpers;
using MediatRItemExtension.Models;
using Microsoft.VisualStudio.Settings;
using Microsoft.VisualStudio.Shell;

#endregion

namespace MediatRItemExtension.Services
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A service for accessing mediat r settings stores information. This class cannot be
    ///     inherited.
    /// </summary>
    /// =================================================================================================
    internal sealed class MediatRSettingsStoreService
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the store.
        /// </summary>
        /// =================================================================================================
        private readonly WritableSettingsStore _store;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="MediatRSettingsStoreService" /> class.
        /// </summary>
        /// <param name="store">The store.</param>
        /// =================================================================================================
        internal MediatRSettingsStoreService(WritableSettingsStore store)
        {
            ThrowHelper.IfNullArgumentNullException(store, nameof(store));
            _store = store;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets default file name by project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>
        ///     The default file name by project.
        /// </returns>
        /// =================================================================================================
        internal string GetDefaultFileNameByProject(Project project)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var collectionPath = GetOrCreateCollectionByProject(project);

            return _store.GetString(collectionPath, InitResources.KeyStore.FolderFileName,
                InitResources.DefaultClassName);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets boolean by project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">(Optional) True to default value.</param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        /// =================================================================================================
        internal bool GetBooleanByProject(Project project, string key, bool defaultValue = false)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var collectionPath = GetOrCreateCollectionByProject(project);

            return _store.GetBoolean(collectionPath, key, defaultValue);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets string by project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">(Optional)</param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        /// =================================================================================================
        internal string GetStringByProject(Project project, string key, string defaultValue = "")
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var collectionPath = GetOrCreateCollectionByProject(project);

            return _store.GetString(collectionPath, key, defaultValue);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Sets boolean by project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">True to value.</param>
        /// =================================================================================================
        internal void SetBooleanByProject(Project project, string key, bool value)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var collectionPath = GetOrCreateCollectionByProject(project);

            _store.SetBoolean(collectionPath, key, value);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Sets string by project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">String to value.</param>
        /// =================================================================================================
        internal void SetStringByProject(Project project, string key, string value)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var collectionPath = GetOrCreateCollectionByProject(project);

            _store.SetString(collectionPath, key, value);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets all settings by project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>
        ///     all settings by project.
        /// </returns>
        /// =================================================================================================
        internal UserProjectSettings GetAllSettingsByProject(Project project)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            return new UserProjectSettings
            {
                DefaultFolderProjectName = GetDefaultFileNameByProject(project),
                OperationProcessing = GetStringByProject(project, InitResources.KeyStore.OperationProcessing),

                CreateFolder = GetBooleanByProject(project, InitResources.KeyStore.CreateFolder),
                CreateOperationClass = GetBooleanByProject(project, InitResources.KeyStore.CreateOperationFile),
                CreateHandlerClass = GetBooleanByProject(project, InitResources.KeyStore.CreateHandlerFile),
                CreateValidatorClass = GetBooleanByProject(project, InitResources.KeyStore.CreateValidationFile),

                IsOneFile = GetBooleanByProject(project, InitResources.KeyStore.IsOneFile),
                IsOneFolder = GetBooleanByProject(project, InitResources.KeyStore.IsOneFolder),
                IsOperationHandlerInOneFile = GetBooleanByProject(project, InitResources.KeyStore.IsOperationHandlerInOneFile),
                IsAutoImportUsingReferences = GetBooleanByProject(project, InitResources.KeyStore.IsAutoImportUsingReferences)
            };
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Saves a user settings.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="model">The model.</param>
        /// =================================================================================================
        internal void SaveUserSettings(Project project, UserProjectSettings model)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            SetBooleanByProject(project, InitResources.KeyStore.CreateFolder, model.CreateFolder);
            SetBooleanByProject(project, InitResources.KeyStore.CreateOperationFile, model.CreateOperationClass);
            SetBooleanByProject(project, InitResources.KeyStore.CreateHandlerFile, model.CreateHandlerClass);
            SetBooleanByProject(project, InitResources.KeyStore.CreateValidationFile, model.CreateValidatorClass);
            SetBooleanByProject(project, InitResources.KeyStore.IsOneFile, model.IsOneFile);
            SetBooleanByProject(project, InitResources.KeyStore.IsOneFolder, model.IsOneFolder);
            SetBooleanByProject(project, InitResources.KeyStore.IsOperationHandlerInOneFile, model.IsOperationHandlerInOneFile);
            SetBooleanByProject(project, InitResources.KeyStore.IsAutoImportUsingReferences, model.IsAutoImportUsingReferences);

            SetStringByProject(project, InitResources.KeyStore.OperationProcessing, model.OperationProcessing);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or create collection by project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>
        ///     The or create collection by project.
        /// </returns>
        /// =================================================================================================
        private string GetOrCreateCollectionByProject(Project project)
        {
            ThrowHelper.IfNullArgumentNullException(project, nameof(project));

            ThreadHelper.ThrowIfNotOnUIThread();

            var safeProjUniqueName = project.UniqueName.Replace('\\', '_');
            var collectionPath = GetFullProjectPath(safeProjUniqueName);

            _store.CreateCollection(collectionPath);

            return collectionPath;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets full project path.
        /// </summary>
        /// <param name="safeProjectName">Name of the safe project.</param>
        /// <returns>
        ///     The full project path.
        /// </returns>
        /// =================================================================================================
        private static string GetFullProjectPath(string safeProjectName)
        {
            return $"{InitResources.DefaultCollectionKey}\\{safeProjectName}";
        }
    }
}