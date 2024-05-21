// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-08 18:14
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-08 18:14
// ***********************************************************************
//  <copyright file="IntExtensions.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

namespace MediatRItemExtension.Extensions.DataType
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     An int extensions.
    /// </summary>
    /// =================================================================================================
    internal static class IntExtensions
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     An int extension method that query if 'sourceExecCode' is success execution.
        /// </summary>
        /// <param name="sourceExecCode">The sourceExecCode to act on.</param>
        /// <returns>
        ///     True if success execution, false if not.
        /// </returns>
        /// =================================================================================================
        public static bool IsSuccessExecution(this int sourceExecCode) => sourceExecCode == 1;
    }
}