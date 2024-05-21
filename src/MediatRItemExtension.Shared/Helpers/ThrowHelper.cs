// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-08 21:00
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-14 23:41
// ***********************************************************************
//  <copyright file="ThrowHelper.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using MediatRItemExtension.Extensions.DataType;

#endregion

namespace MediatRItemExtension.Helpers
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A throw helper.
    /// </summary>
    /// =================================================================================================
    internal static class ThrowHelper
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     If null argument null exception.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are null.
        /// </exception>
        /// <param name="sourceObject">Source object.</param>
        /// <param name="message">The message.</param>
        /// =================================================================================================
        internal static void IfNullArgumentNullException(object sourceObject, string message)
        {
            if (sourceObject.IsNull())
                throw new ArgumentNullException(message);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Argument null exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// =================================================================================================
        internal static void ArgumentNullException(string message)
        {
            throw new ArgumentNullException(message);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Argument exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// =================================================================================================
        internal static void ArgumentException(string message)
        {
            throw new ArgumentException(message);
        }
    }
}