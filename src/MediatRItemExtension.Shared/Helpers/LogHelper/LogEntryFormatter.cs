// ***********************************************************************
//  Assembly          : MediatRItemExtension.MediatRItemExtension.Tests
//  Author            : RzR
//  Created           : 15-06-2026 22:06
// 
//  Last Modified By : RzR
//  Last Modified On : 15-06-2026 22:56
//  ***********************************************************************
//  <copyright file="LogEntryFormatter.cs" company="RzR SOFT & TECH">
//      Copyright (c) RzR. All rights reserved.
//  </copyright>
//  <contact>
//      https://iamrzr.dev/contact
//  </contact>
//  <summary></summary>
//  ***********************************************************************

#region U S I N G

using System;

#endregion

namespace MediatRItemExtension.Helpers.LogHelper
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Pure, dependency-free formatting for log entries written by <see cref="LoggerFile" />.
    ///     Contains only System references so it can be linked into isolated test projects.
    /// </summary>
    /// =================================================================================================
    internal static class LogEntryFormatter
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
        ///     (Immutable) the continuation log data prefix. Must match the value-column indent used by
        ///     the labels in <see cref="Template" /> (e.g. "//\tMessage:    ") so that wrapped lines stay
        ///     aligned. If a label in <see cref="Template" /> is widened, update this constant to match.
        /// </summary>
        /// =================================================================================================
        internal const string ContinuationPrefix = "//\t            ";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Formats a log entry block using the standard template.
        /// </summary>
        /// <param name="date">The timestamp to embed in the Date field.</param>
        /// <param name="packageId">The package identifier string.</param>
        /// <param name="code">The error or info code string.</param>
        /// <param name="message">The message text; may be multiline.</param>
        /// <returns>The fully formatted log block string, including leading and trailing newlines.</returns>
        /// =================================================================================================
        internal static string Format(DateTime date, string packageId, string code, string message)
        {
            return string.Format(
                Template,
                date,
                NormalizeForLogBlock(packageId),
                NormalizeForLogBlock(code),
                NormalizeForLogBlock(message));
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Normalizes a log-field value so that every continuation line of a multiline value is
        ///     prefixed with <see cref="ContinuationPrefix" />, keeping all lines inside the comment block.
        ///     Trailing blank lines produced by a trailing newline in <paramref name="value" /> are removed.
        /// </summary>
        /// <param name="value">The raw field value; may contain \r\n, \n, or \r line endings.</param>
        /// <returns>A single string safe to embed as one field in <see cref="Template" />.</returns>
        /// =================================================================================================
        internal static string NormalizeForLogBlock(object value)
        {
            var text = (value?.ToString() ?? string.Empty).TrimEnd('\r', '\n');

            return string.Join("\r\n" + ContinuationPrefix,
                text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None));
        }
    }
}