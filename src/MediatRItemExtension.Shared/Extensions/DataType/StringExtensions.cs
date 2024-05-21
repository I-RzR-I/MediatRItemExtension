// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-17 18:13
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-18 08:40
// ***********************************************************************
//  <copyright file="StringExtensions.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.IO;
using System.Windows.Media.Imaging;

#endregion

namespace MediatRItemExtension.Extensions.DataType
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A string extensions.
    /// </summary>
    /// =================================================================================================
    internal static class StringExtensions
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A string extension method that query if 'source' is missing.
        /// </summary>
        /// <param name="source">The source to act on.</param>
        /// <returns>
        ///     True if missing, false if not.
        /// </returns>
        /// =================================================================================================
        internal static bool IsMissing(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A string extension method that query if 'source' is present.
        /// </summary>
        /// <param name="source">The source to act on.</param>
        /// <returns>
        ///     True if present, false if not.
        /// </returns>
        /// =================================================================================================
        internal static bool IsPresent(this string source)
        {
            return !string.IsNullOrWhiteSpace(source);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A string extension method that queries if a null or is empty.
        /// </summary>
        /// <param name="str">The str to act on.</param>
        /// <returns>
        ///     True if the null or is empty, false if not.
        /// </returns>
        /// =================================================================================================
        internal static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A string extension method that converts a base64Img to a bitmap image.
        /// </summary>
        /// <param name="base64Img">The base64Img to act on.</param>
        /// <returns>
        ///     Base64Img as a BitmapImage.
        /// </returns>
        /// =================================================================================================
        internal static BitmapImage ToBitmapImage(this string base64Img)
        {
            var binaryData = Convert.FromBase64String(base64Img);

            var imageBitmap = new BitmapImage();
            imageBitmap.BeginInit();
            imageBitmap.StreamSource = new MemoryStream(binaryData);
            imageBitmap.EndInit();

            return imageBitmap;
        }
    }
}