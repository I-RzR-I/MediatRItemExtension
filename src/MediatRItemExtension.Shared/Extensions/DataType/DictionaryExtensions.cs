// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-28 15:53
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-28 17:13
// ***********************************************************************
//  <copyright file="DictionaryExtensions.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System.Collections.Generic;

#endregion

namespace MediatRItemExtension.Extensions.DataType
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A dictionary extensions.
    /// </summary>
    /// =================================================================================================
    internal static class DictionaryExtensions
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     An IDictionary&lt;TKey,TValue&gt; extension method that adds an or update to
        ///     'keyValue'.
        /// </summary>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="source">The source to act on.</param>
        /// <param name="keyValue">The key value.</param>
        /// <returns>
        ///     An IDictionary&lt;TKey,TValue&gt;
        /// </returns>
        /// =================================================================================================
        internal static IDictionary<TKey, TValue> AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> source,
            KeyValuePair<TKey, TValue> keyValue)
        {
            if (source.ContainsKey(keyValue.Key))
                source[keyValue.Key] = keyValue.Value;
            else
                source.Add(keyValue);

            return source;
        }
    }
}