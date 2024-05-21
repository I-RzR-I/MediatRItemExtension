// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-14 16:11
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-16 23:33
// ***********************************************************************
//  <copyright file="EnumExtensions.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MediatRItemExtension.Models;

#endregion

namespace MediatRItemExtension.Extensions.DataType
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     An enum extensions.
    /// </summary>
    /// =================================================================================================
    internal static class EnumExtensions
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Enumerates to name values in this collection.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <returns>
        ///     This object as an IEnumerable&lt;ObjectNameValue&lt;T&gt;&gt;
        /// </returns>
        /// =================================================================================================
        internal static IEnumerable<ObjectNameValue<T>> ToNameValues<T>() where T : Enum
        {
            return typeof(T)
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .Select(x => new ObjectNameValue<T>
                {
                    Name = x.Name,
                    Value = (T)x.GetValue(null)
                });
        }
    }
}