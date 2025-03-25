// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-08 14:59
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-14 23:43
// ***********************************************************************
//  <copyright file="InitResources.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.Collections.Generic;
using MediatRItemExtension.Extensions.DataType;

// ReSharper disable ClassNeverInstantiated.Global

#endregion

namespace MediatRItemExtension.Helpers
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     An initialize resources.
    /// </summary>
    /// =================================================================================================
    internal static class InitResources
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) identifier for the package.
        /// </summary>
        /// =================================================================================================
        internal const string GeneralPackageId = "00000000-0000-E000-AAAA-000000000000";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) identifier for the package v 2019.
        /// </summary>
        /// =================================================================================================
        private const string PackageIdV2K19 = "00000000-0000-E000-AAAA-000000002019";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the package identifier v 2022.
        /// </summary>
        /// =================================================================================================
        private const string PackageIdV2K22 = "00000000-0000-E000-AAAA-000000002022";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) identifier for the product v 2019.
        /// </summary>
        /// =================================================================================================
        internal const string ProductIdV2K19 = "MediatRItemExtension." + PackageIdV2K19;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the product identifier v 2022.
        /// </summary>
        /// =================================================================================================
        internal const string ProductIdV2K22 = "MediatRItemExtension." + PackageIdV2K22;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the short key.
        /// </summary>
        /// =================================================================================================
        internal const string ShortKey = "SHIFT+INSERT+M";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) identifier for the command.
        /// </summary>
        /// =================================================================================================
        internal const int CommandId = 0x0100;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the default class name.
        /// </summary>
        /// =================================================================================================
        internal const string DefaultClassName = "Class";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the default collection key.
        /// </summary>
        /// =================================================================================================
        internal const string DefaultCollectionKey = "MediatR";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the VSIX version.
        /// </summary>
        /// =================================================================================================
        internal const string Version = "2.1.1.0";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) set the command belongs to.
        /// </summary>
        /// =================================================================================================
        internal static readonly Guid CommandSet = new Guid("00000000-0000-EC0D-AAAA-000000000001");

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) name of the product.
        /// </summary>
        /// =================================================================================================
        internal const string ProductName = "MediatRItemExtension";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the description.
        /// </summary>
        /// =================================================================================================
        internal const string Description = "MediatR extension allow create easlly way command/query, handler, and validator";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the author.
        /// </summary>
        /// =================================================================================================
        internal const string Author = "RzR";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the base 64 icon.
        /// </summary>
        /// =================================================================================================
        internal const string Base64Ico = "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";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A key store.
        /// </summary>
        /// =================================================================================================
        internal static class ProjectKeyStore
        {
            /// -------------------------------------------------------------------------------------------------
            /// <summary>
            ///     (Immutable) filename of the folder file.
            /// </summary>
            /// =================================================================================================
            internal static readonly string FolderFileName = StringExtensions.BuildKeyStore(ProductName, DefaultCollectionKey, "folder_file_name");

            /// -------------------------------------------------------------------------------------------------
            /// <summary>
            ///     (Immutable) pathname of the create folder.
            /// </summary>
            /// =================================================================================================
            internal static readonly string CreateFolder = StringExtensions.BuildKeyStore(ProductName, DefaultCollectionKey, "create_folder");

            /// -------------------------------------------------------------------------------------------------
            /// <summary>
            ///     (Immutable) the create validation file.
            /// </summary>
            /// =================================================================================================
            internal static readonly string CreateValidationFile = StringExtensions.BuildKeyStore(ProductName, DefaultCollectionKey, "create_validator");

            /// -------------------------------------------------------------------------------------------------
            /// <summary>
            ///     (Immutable) the create operation file.
            /// </summary>
            /// =================================================================================================
            internal static readonly string CreateOperationFile = StringExtensions.BuildKeyStore(ProductName, DefaultCollectionKey, "create_operation");

            /// -------------------------------------------------------------------------------------------------
            /// <summary>
            ///     (Immutable) the create handler file.
            /// </summary>
            /// =================================================================================================
            internal static readonly string CreateHandlerFile = StringExtensions.BuildKeyStore(ProductName, DefaultCollectionKey, "create_handler");

            /// -------------------------------------------------------------------------------------------------
            /// <summary>
            ///     (Immutable) the is one file.
            /// </summary>
            /// =================================================================================================
            internal static readonly string IsOneFile = StringExtensions.BuildKeyStore(ProductName, DefaultCollectionKey, "one_file");

            /// -------------------------------------------------------------------------------------------------
            /// <summary>
            ///     (Immutable) pathname of the is one folder.
            /// </summary>
            /// =================================================================================================
            internal static readonly string IsOneFolder = StringExtensions.BuildKeyStore(ProductName, DefaultCollectionKey, "one_folder");

            /// -------------------------------------------------------------------------------------------------
            /// <summary>
            ///     (Immutable) the is operation handler in one file.
            /// </summary>
            /// =================================================================================================
            internal static readonly string IsOperationHandlerInOneFile = StringExtensions.BuildKeyStore(ProductName, DefaultCollectionKey, "one_file_operation_handler");

            /// -------------------------------------------------------------------------------------------------
            /// <summary>
            ///     (Immutable) the is automatic import using references.
            /// </summary>
            /// =================================================================================================
            internal static readonly string IsAutoImportUsingReferences = StringExtensions.BuildKeyStore(ProductName, DefaultCollectionKey, "auto_import_using_references");

            /// -------------------------------------------------------------------------------------------------
            /// <summary>
            ///     (Immutable) the operation processing.
            /// </summary>
            /// =================================================================================================
            internal static readonly string OperationProcessing = StringExtensions.BuildKeyStore(ProductName, DefaultCollectionKey, "process_operation");
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A solution key store.
        /// </summary>
        /// =================================================================================================
        internal static class SolutionKeyStore
        {
            /// -------------------------------------------------------------------------------------------------
            /// <summary>
            ///     (Immutable) the last version check date.
            /// </summary>
            /// =================================================================================================
            internal static readonly string LastVersionCheckDate = StringExtensions.BuildKeyStore(ProductName, DefaultCollectionKey, "version_check_last_date");

            /// -------------------------------------------------------------------------------------------------
            /// <summary>
            ///     (Immutable) the version check status.
            /// </summary>
            /// =================================================================================================
            internal static readonly string VersionCheckStatus = StringExtensions.BuildKeyStore(ProductName, DefaultCollectionKey, "version_check_status");
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A default using.
        /// </summary>
        /// =================================================================================================
        internal static class DefaultUsing
        {
            /// -------------------------------------------------------------------------------------------------
            /// <summary>
            ///     (Immutable) the default validator.
            /// </summary>
            /// =================================================================================================
            internal static readonly IEnumerable<string> DefaultValidator = new List<string>(1) { "FluentValidation" };

            /// -------------------------------------------------------------------------------------------------
            /// <summary>
            ///     (Immutable) the default synchronize handler.
            /// </summary>
            /// =================================================================================================
            internal static readonly IEnumerable<string> DefaultSyncHandler = new List<string>(1) { "MediatR" };

            /// -------------------------------------------------------------------------------------------------
            /// <summary>
            ///     (Immutable) the default asynchronous handler.
            /// </summary>
            /// =================================================================================================
            internal static readonly IEnumerable<string> DefaultAsyncHandler = new List<string>(3)
            {
                "MediatR",
                "System.Threading",
                "System.Threading.Tasks"
            };

            /// -------------------------------------------------------------------------------------------------
            /// <summary>
            ///     (Immutable) the default operation.
            /// </summary>
            /// =================================================================================================
            internal static readonly IEnumerable<string> DefaultOperation = new List<string>(1) { "MediatR" };

            /// -------------------------------------------------------------------------------------------------
            /// <summary>
            ///     (Immutable) the default localization.
            /// </summary>
            /// =================================================================================================
            internal static readonly IEnumerable<string> DefaultLocalization = new List<string>(1) { "Microsoft.Extensions.Localization" };
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     The class parameters.
        /// </summary>
        /// =================================================================================================
        internal static class ClassParams
        {
            /// -------------------------------------------------------------------------------------------------
            /// <summary>
            ///     The localization.
            /// </summary>
            /// =================================================================================================
            internal static KeyValuePair<string, string> Localization = new("IStringLocalizer", "stringLocalizer");
        }
    }
}