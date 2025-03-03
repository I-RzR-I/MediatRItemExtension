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

namespace MediatRItemExtension.Helpers
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

                var sw = File.Exists(pathFile).IsFalse() ? new StreamWriter(pathFile) : File.AppendText(pathFile);
                sw.WriteLine(Template, DateTime.Now, packageId, code, message);
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

                var sw = File.Exists(pathFile).IsFalse() ? new StreamWriter(pathFile) : File.AppendText(pathFile);
                sw.WriteLine(Template, DateTime.Now, packageId, "EXCEPTION", exception);
                sw.Flush();
                sw.Close();
            }
        }
    }
}