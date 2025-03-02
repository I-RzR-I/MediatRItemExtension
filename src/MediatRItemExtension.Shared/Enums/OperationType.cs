// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-08 12:34
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-08 12:34
// ***********************************************************************
//  <copyright file="OperationType.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

namespace MediatRItemExtension.Enums
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Values that represent operation types.
    /// </summary>
    /// =================================================================================================
    public enum OperationType
    {
        /// <summary>
        ///     An enum constant representing the query option.
        /// </summary>
        Query,

        /// <summary>
        ///     An enum constant representing the command option.
        /// </summary>
        Command,
        
        /// <summary>
        ///     An enum constant representing the notification option.
        /// </summary>
        Notification
    }
}