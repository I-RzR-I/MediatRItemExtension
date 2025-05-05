// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-17 18:13
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-27 19:10
// ***********************************************************************
//  <copyright file="ResourceMessage.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System.Collections.Generic;
using MediatRItemExtension.Enums.Codes;

#endregion

namespace MediatRItemExtension.Helpers.Localization
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
        ///     (Immutable) the messages store.
        ///     RF -> Required field
        /// </summary>
        /// =================================================================================================
        internal static readonly Dictionary<ReqInfoCodeType, string> ReqInfoMessagesStore =
            new Dictionary<ReqInfoCodeType, string>
            {
                { ReqInfoCodeType.RF0001, "File/folder name type can't be empty." },
                { ReqInfoCodeType.RF0002, "Response type can't be empty." },
                { ReqInfoCodeType.RF0003, "Project or folder is not selected, please select one of them." },
                { ReqInfoCodeType.RF0004, "File/folder name is not valid." },
                { ReqInfoCodeType.RF0005, "File/folder name already exist." }
            };

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the messages store.
        ///     E -> Error messages
        /// </summary>
        /// =================================================================================================
        internal static readonly Dictionary<ErrorCodeType, string> ErrorMessagesStore =
            new Dictionary<ErrorCodeType, string>
            {
                { ErrorCodeType.E0001, "General error occurred on program execution. Error: {0}" },
                { ErrorCodeType.E0002, "General error occurred on create user defined operations. Error: {0}" },
                { ErrorCodeType.E0003, "General error occurred on initialize main frame. Error: {0}" },
                { ErrorCodeType.E0004, "General error occurred on generate validation class. Error: {0}" },
                { ErrorCodeType.E0005, "General error occurred on generate one file validation class. Error: {0}" },
                { ErrorCodeType.E0006, "General error occurred on add handler implementation. Error: {0}" },
                { ErrorCodeType.E0007, "General error occurred on adjust request handler info. Error: {0}" },
                { ErrorCodeType.E0008, "General error occurred on add handler implementation in one file. Error: {0}" },
                { ErrorCodeType.E0009, "General error occurred on add handler implementation in new file. Error: {0}" },
                { ErrorCodeType.E0010, "General error occurred on create request operation. Error: {0}" },
                { ErrorCodeType.E0011, "A solution selection is not permitted. Allowed item is project or project items." },
                { ErrorCodeType.E0012, "Maximum path length exceeded" },
                { ErrorCodeType.E0013, "The operation/handler or validation class full path length is exceeded (>= 248 chars) and may cause problems. Would you like to continue?" }
            };
    }
}