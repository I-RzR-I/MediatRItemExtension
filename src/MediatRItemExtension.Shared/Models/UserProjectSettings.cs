// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-11 01:50
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-14 08:23
// ***********************************************************************
//  <copyright file="UserProjectSettings.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

namespace MediatRItemExtension.Models
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A user project settings.
    /// </summary>
    /// =================================================================================================
    public class UserProjectSettings
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the default folder project name.
        /// </summary>
        /// <value>
        ///     The default folder project name.
        /// </value>
        /// =================================================================================================
        public string DefaultFolderProjectName { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the operation processing.
        /// </summary>
        /// <value>
        ///     The operation processing.
        /// </value>
        /// =================================================================================================
        internal string OperationProcessing { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets a value indicating whether the create folder.
        /// </summary>
        /// <value>
        ///     True if create folder, false if not.
        /// </value>
        /// =================================================================================================
        internal bool CreateFolder { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets a value indicating whether the create operation class.
        /// </summary>
        /// <value>
        ///     True if create operation class, false if not.
        /// </value>
        /// =================================================================================================
        internal bool CreateOperationClass { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets a value indicating whether the create handler class.
        /// </summary>
        /// <value>
        ///     True if create handler class, false if not.
        /// </value>
        /// =================================================================================================
        internal bool CreateHandlerClass { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets a value indicating whether the create validator class.
        /// </summary>
        /// <value>
        ///     True if create validator class, false if not.
        /// </value>
        /// =================================================================================================
        internal bool CreateValidatorClass { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets a value indicating whether this object is one file.
        /// </summary>
        /// <value>
        ///     True if this object is one file, false if not.
        /// </value>
        /// =================================================================================================
        internal bool IsOneFile { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets a value indicating whether this object is one folder.
        /// </summary>
        /// <value>
        ///     True if this object is one folder, false if not.
        /// </value>
        /// =================================================================================================
        internal bool IsOneFolder { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets a value indicating whether this object is operation handler in one file.
        /// </summary>
        /// <value>
        ///     True if this object is operation handler in one file, false if not.
        /// </value>
        /// =================================================================================================
        internal bool IsOperationHandlerInOneFile { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets a value indicating whether this object is automatic import using
        ///     references.
        /// </summary>
        /// <value>
        ///     True if this object is automatic import using references, false if not.
        /// </value>
        /// =================================================================================================
        internal bool IsAutoImportUsingReferences { get; set; }
    }
}