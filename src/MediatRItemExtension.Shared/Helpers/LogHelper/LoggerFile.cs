// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2025-03-02 18:20
// 
//  Last Modified By : RzR
//  Last Modified On : 2025-03-03 07:47
// ***********************************************************************
//  <copyright file="LoggerFile.cs" company="RzR SOFT & TECH">
//   Copyright © RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.IO;
using MediatRItemExtension.Extensions.DataType;

#endregion

namespace MediatRItemExtension.Helpers.LogHelper
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A logger file.
    /// </summary>
    /// =================================================================================================
    internal static class LoggerFile
    {
        private const string Template = @"
//--------------------------------------------------//
//
//	Date:       {0}
//	PackageId:  {1}
//	ErrorCode:  {2}
//	Message:    {3}
//
//--------------------------------------------------//
";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the continuation log data prefix.
        /// </summary>
        /// =================================================================================================
        private const string ContinuationPrefix = "//\t            ";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the lock.
        /// </summary>
        /// =================================================================================================
        private static readonly object Lock = new();

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Logs the message to the given file.
        /// </summary>
        /// <param name="path">Full path of the file.</param>
        /// <param name="fileName">Filename of the file.</param>
        /// <param name="packageId">Identifier for the package.</param>
        /// <param name="code">The code.</param>
        /// <param name="message">The message.</param>
        /// =================================================================================================
        public static void Log(string path, string fileName, string packageId, string code, string message)
        {
            lock (Lock)
            {
                var pathFile = path + Path.DirectorySeparatorChar + fileName + ".log";

                var sw = File.Exists(pathFile).IsFalse()
                    ? new StreamWriter(pathFile)
                    : File.AppendText(pathFile);

                sw.WriteLine(
                    Template, 
                    DateTime.Now,
                    NormalizeForLogBlock(packageId),
                    NormalizeForLogBlock(code),
                    NormalizeForLogBlock(message));

                sw.Flush();
                sw.Close();
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Logs the message to the given file.
        /// </summary>
        /// <param name="path">Full path of the file.</param>
        /// <param name="fileName">Filename of the file.</param>
        /// <param name="packageId">Identifier for the package.</param>
        /// <param name="exception">The exception.</param>
        /// =================================================================================================
        public static void Log(string path, string fileName, string packageId, Exception exception)
        {
            lock (Lock)
            {
                var pathFile = path + Path.DirectorySeparatorChar + fileName + ".log";

                var sw = File.Exists(pathFile).IsFalse()
                    ? new StreamWriter(pathFile)
                    : File.AppendText(pathFile);

                sw.WriteLine(
                    Template, 
                    DateTime.Now,
                    NormalizeForLogBlock(packageId), 
                    "EXCEPTION", 
                    NormalizeForLogBlock(exception));

                sw.Flush();
                sw.Close();
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Logs the message to the given file.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// =================================================================================================
        public static void Log(Exception exception)
        {
            var manifestInfo = VsixInfoHelper.Instance.GetManifest();
            lock (Lock)
            {
                var pathFile = manifestInfo.LocalPath + Path.DirectorySeparatorChar + manifestInfo.DisplayName + ".log";

                var sw = File.Exists(pathFile).IsFalse() 
                    ? new StreamWriter(pathFile) 
                    : File.AppendText(pathFile);

                sw.WriteLine(
                    Template,
                    DateTime.Now, 
                    NormalizeForLogBlock(manifestInfo.PackageId), 
                    "EXCEPTION", 
                    NormalizeForLogBlock(exception));

                sw.Flush();
                sw.Close();
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Normalizes a log-field value so that every continuation line of a multiline value is
        ///     prefixed with <see cref="ContinuationPrefix"/>, keeping all lines inside the comment block.
        ///     Trailing blank lines produced by a trailing newline in <paramref name="value"/> are removed.
        /// </summary>
        /// <param name="value">The raw field value; may contain \r\n, \n, or \r line endings.</param>
        /// <returns>A single string safe to embed as one field in <see cref="Template"/>.</returns>
        /// =================================================================================================
        private static string NormalizeForLogBlock(object value)
        {
            var text = (value?.ToString() ?? string.Empty).TrimEnd('\r', '\n');

            return string.Join("\r\n" + ContinuationPrefix,
                text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None));
        }
    }
}