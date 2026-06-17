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

                sw.WriteLine(LogEntryFormatter.Format(DateTime.Now, packageId, code, message));

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

                sw.WriteLine(LogEntryFormatter.Format(DateTime.Now, packageId, "EXCEPTION", exception?.ToString()));

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
            if (manifestInfo == null)
            {
                System.Diagnostics.Debug.Write(exception);
                return;
            }

            lock (Lock)
            {
                var pathFile = manifestInfo.LocalPath + Path.DirectorySeparatorChar + manifestInfo.DisplayName + ".log";

                var sw = File.Exists(pathFile).IsFalse() 
                    ? new StreamWriter(pathFile) 
                    : File.AppendText(pathFile);

                sw.WriteLine(LogEntryFormatter.Format(DateTime.Now, manifestInfo.PackageId, "EXCEPTION", exception?.ToString()));

                sw.Flush();
                sw.Close();
            }
        }

    }
}