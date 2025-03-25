// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2025-03-24 15:20
// 
//  Last Modified By : RzR
//  Last Modified On : 2025-03-25 22:09
// ***********************************************************************
//  <copyright file="SolutionSettingsStoreService.cs" company="RzR SOFT & TECH">
//   Copyright © RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.Globalization;
using EnvDTE90;
using MediatRItemExtension.Enums;
using MediatRItemExtension.Extensions.DataType;
using MediatRItemExtension.Helpers;
using MediatRItemExtension.Helpers.LogHelper;
using Microsoft.VisualStudio.Settings;
using Microsoft.VisualStudio.Shell;

#endregion

namespace MediatRItemExtension.Services
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A service for accessing solution settings stores information. This class cannot be
    ///     inherited.
    /// </summary>
    /// =================================================================================================
    internal sealed class SolutionSettingsStoreService
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
        internal SolutionSettingsStoreService(WritableSettingsStore store)
        {
            ThrowHelper.IfNullArgumentNullException(store, nameof(store));

            _store = store;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the last version check date.
        /// </summary>
        /// <param name="solution3">The third solution.</param>
        /// <returns>
        ///     The last version check date.
        /// </returns>
        /// =================================================================================================
        internal DateTime? GetLastVersionCheckDate(Solution3 solution3)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                var collectionPath = GetOrCreateCollectionByProject(solution3);

                var savedValue = _store.GetString(collectionPath, InitResources.SolutionKeyStore.LastVersionCheckDate);
                if (savedValue.IsNullOrEmpty())
                    return null;
                return DateTime.ParseExact(savedValue, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                LoggerFile.Log(e);

                return null;
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Sets last version check date.
        /// </summary>
        /// <param name="solution3">The third solution.</param>
        /// <param name="value">The value Date/Time.</param>
        /// =================================================================================================
        internal void SetLastVersionCheckDate(Solution3 solution3, DateTime value)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var collectionPath = GetOrCreateCollectionByProject(solution3);

            _store.SetString(collectionPath, InitResources.SolutionKeyStore.LastVersionCheckDate,
                value.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the last version check result.
        /// </summary>
        /// <param name="solution3">The third solution.</param>
        /// <returns>
        ///     The last version check result.
        /// </returns>
        /// =================================================================================================
        internal VersionCheckResultType GetLastVersionCheckResult(Solution3 solution3)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                var collectionPath = GetOrCreateCollectionByProject(solution3);

                var savedValue = _store.GetInt32(collectionPath, InitResources.SolutionKeyStore.VersionCheckStatus);

                return (VersionCheckResultType)savedValue;
            }
            catch (Exception e)
            {
                LoggerFile.Log(e);

                return VersionCheckResultType.ErrorCheck;
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Sets last version check result.
        /// </summary>
        /// <param name="solution3">The third solution.</param>
        /// <param name="value">The value.</param>
        /// =================================================================================================
        internal void SetLastVersionCheckResult(Solution3 solution3, VersionCheckResultType value)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var collectionPath = GetOrCreateCollectionByProject(solution3);

            _store.SetInt32(collectionPath, InitResources.SolutionKeyStore.VersionCheckStatus, (int)value);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or create collection by solution.
        /// </summary>
        /// <param name="solution3">The solution.</param>
        /// <returns>
        ///     The or create collection by project.
        /// </returns>
        /// =================================================================================================
        private string GetOrCreateCollectionByProject(Solution3 solution3)
        {
            ThrowHelper.IfNullArgumentNullException(solution3, nameof(solution3));

            ThreadHelper.ThrowIfNotOnUIThread();

            var safeProjUniqueName = solution3.FullName.Replace('\\', '_');
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