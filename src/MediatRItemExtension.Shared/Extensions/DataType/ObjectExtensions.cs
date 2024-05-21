// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-08 13:51
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-08 13:51
// ***********************************************************************
//  <copyright file="ObjectExtensions.cs" company="">
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
    ///     An object extensions.
    /// </summary>
    /// =================================================================================================
    internal static class ObjectExtensions
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     An object extension method that query if 'obj' is null.
        /// </summary>
        /// <param name="obj">The obj to act on.</param>
        /// <returns>
        ///     True if null, false if not.
        /// </returns>
        /// =================================================================================================
        internal static bool IsNull(this object obj)
            => obj == null;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     An object extension method that query if 'obj' is not null.
        /// </summary>
        /// <param name="obj">The obj to act on.</param>
        /// <returns>
        ///     True if not null, false if not.
        /// </returns>
        /// =================================================================================================
        internal static bool IsNotNull(this object obj)
            => obj != null;
    }
}