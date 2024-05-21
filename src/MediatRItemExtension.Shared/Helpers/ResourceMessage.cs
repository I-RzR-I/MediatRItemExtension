// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-08 18:10
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-08 18:10
// ***********************************************************************
//  <copyright file="ResourceMessage.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

namespace MediatRItemExtension.Helpers
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A resource message.
    /// </summary>
    /// =================================================================================================
    internal static class ResourceMessage
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the folder file name not empty.
        /// </summary>
        /// =================================================================================================
        internal const string FolderFileNameNotEmpty = "File/folder name type can't be empty.";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the response type name not empty.
        /// </summary>
        /// =================================================================================================
        internal const string ResponseTypeNameNotEmpty = "Response type can't be empty.";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the folder project not selected.
        /// </summary>
        /// =================================================================================================
        internal const string FolderProjectNotSelected = "Project or folder is not selected, please select one of them.";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the folder file name invalid.
        /// </summary>
        /// =================================================================================================
        internal const string FolderFileNameInvalid = "File/folder name is not valid.";
    }
}