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
using System.ComponentModel;
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
        
        /// <summary>
        ///     Get description of enum property if exist
        /// </summary>
        /// <param name="value">Enum</param>
        /// <param name="returnEmpty">In case when 'Description' not found, then return empty string</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetDescription(this Enum value, bool returnEmpty = false)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo.IsNull()) return null;

            var attribute = (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));

            return attribute.IsNotNull() ? attribute.Description : (returnEmpty.IsTrue() ? "" : value.ToString());
        }
    }
}