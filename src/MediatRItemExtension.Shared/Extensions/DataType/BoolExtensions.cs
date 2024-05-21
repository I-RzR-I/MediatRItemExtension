// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-08 15:25
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-08 15:25
// ***********************************************************************
//  <copyright file="BoolExtensions.cs" company="">
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
    ///     An extensions.
    /// </summary>
    /// =================================================================================================
    internal static class BoolExtensions
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A bool? extension method that query if 'source' is true.
        /// </summary>
        /// <param name="source">The source to act on.</param>
        /// <returns>
        ///     True if true, false if not.
        /// </returns>
        /// =================================================================================================
        public static bool IsTrue(this bool source)
            => source.IsNotNull() && source.Equals(true);

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A bool? extension method that query if 'source' is true.
        /// </summary>
        /// <param name="source">The source to act on.</param>
        /// <returns>
        ///     True if true, false if not.
        /// </returns>
        /// =================================================================================================
        public static bool IsTrue(this bool? source)
            => source.IsNotNull() && source.Equals(true);

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A bool? extension method that query if 'source' is false.
        /// </summary>
        /// <param name="source">The source to act on.</param>
        /// <returns>
        ///     True if false, false if not.
        /// </returns>
        /// =================================================================================================
        public static bool IsFalse(this bool source)
            => source.IsNull() || source.Equals(false);

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A bool? extension method that query if 'source' is false.
        /// </summary>
        /// <param name="source">The source to act on.</param>
        /// <returns>
        ///     True if false, false if not.
        /// </returns>
        /// =================================================================================================
        public static bool IsFalse(this bool? source)
            => source.IsNull() || source.Equals(false);
    }
}