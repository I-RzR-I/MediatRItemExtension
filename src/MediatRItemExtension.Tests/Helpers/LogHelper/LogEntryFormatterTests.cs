// ***********************************************************************
//  Assembly          : MediatRItemExtension.MediatRItemExtension.Tests
//  Author            : RzR
//  Created           : 15-06-2026 23:06
// 
//  Last Modified By : RzR
//  Last Modified On : 16-06-2026 19:54
//  ***********************************************************************
//  <copyright file="LogEntryFormatterTests.cs" company="RzR SOFT & TECH">
//      Copyright (c) RzR. All rights reserved.
//  </copyright>
//  <contact>
//      https://iamrzr.dev/contact
//  </contact>
//  <summary></summary>
//  ***********************************************************************

#region U S I N G

using System;
using MediatRItemExtension.Helpers.LogHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace MediatRItemExtension.Tests.Helpers.LogHelper
{
    [TestClass]
    public class LogEntryFormatterTests
    {
        private static readonly string Prefix = LogEntryFormatter.ContinuationPrefix;

        [TestMethod]
        public void NormalizeForLogBlock_SingleLineValue_ReturnedUnchanged()
        {
            // Arrange
            const string input = "SimpleMessage";

            // Act
            var result = LogEntryFormatter.NormalizeForLogBlock(input);

            // Assert
            Assert.AreEqual("SimpleMessage", result);
        }

        [TestMethod]
        public void NormalizeForLogBlock_TwoLinesCrLf_SecondLinePrefixed()
        {
            // Arrange
            const string input = "Line1\r\nLine2";

            // Act
            var result = LogEntryFormatter.NormalizeForLogBlock(input);

            // Assert
            Assert.AreEqual("Line1\r\n" + Prefix + "Line2", result);
        }

        [TestMethod]
        public void NormalizeForLogBlock_TwoLinesLf_SecondLinePrefixed()
        {
            // Arrange
            const string input = "Line1\nLine2";

            // Act
            var result = LogEntryFormatter.NormalizeForLogBlock(input);

            // Assert
            Assert.AreEqual("Line1\r\n" + Prefix + "Line2", result);
        }

        [TestMethod]
        public void NormalizeForLogBlock_TwoLinesCr_SecondLinePrefixed()
        {
            // Arrange
            const string input = "Line1\rLine2";

            // Act
            var result = LogEntryFormatter.NormalizeForLogBlock(input);

            // Assert
            Assert.AreEqual("Line1\r\n" + Prefix + "Line2", result);
        }

        [TestMethod]
        public void NormalizeForLogBlock_TrailingNewline_NoDanglingEmptyPrefixedLine()
        {
            // Arrange — a trailing \r\n must not produce a final empty prefixed line
            const string input = "Line1\r\n";

            // Act
            var result = LogEntryFormatter.NormalizeForLogBlock(input);

            // Assert
            Assert.AreEqual("Line1", result);
        }

        [TestMethod]
        public void NormalizeForLogBlock_MultipleTrailingNewlines_NoDanglingLines()
        {
            // Arrange
            const string input = "Line1\r\n\r\n\n";

            // Act
            var result = LogEntryFormatter.NormalizeForLogBlock(input);

            // Assert — TrimEnd strips the trailing \r and \n chars, leaving only the non-empty content
            // "Line1\r\n\r\n\n".TrimEnd('\r','\n') == "Line1"
            Assert.AreEqual("Line1", result);
        }

        [TestMethod]
        public void NormalizeForLogBlock_NullInput_ReturnsEmptyString()
        {
            // Act
#pragma warning disable CS8625 // null literal intentionally passed to test the null-guard in NormalizeForLogBlock
            var result = LogEntryFormatter.NormalizeForLogBlock(null);
#pragma warning restore CS8625

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void NormalizeForLogBlock_MultilineExceptionToString_EveryContinuationLinePrefixed()
        {
            // Arrange — simulate a multiline exception ToString()
            var innerEx = new InvalidOperationException("inner problem");
            var ex = new ArgumentException("outer problem", innerEx);
            var exText = ex.ToString();
            var lines = exText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            // Act
            var result = LogEntryFormatter.NormalizeForLogBlock(ex);

            // Assert — every line after the first should begin with the continuation prefix
            var resultLines = result.Split(new[] { "\r\n" }, StringSplitOptions.None);
            Assert.AreEqual(lines.Length, resultLines.Length,
                "Normalized line count should match original (after trailing trim).");
            for (var i = 1; i < resultLines.Length; i++)
                StringAssert.StartsWith(resultLines[i], Prefix,
                    $"Continuation line {i} should start with the prefix.");
        }

        [TestMethod]
        public void ContinuationPrefix_HasExpectedValue()
        {
            // The prefix is "//\t" followed by exactly 12 spaces, matching the value-column
            // width of the widest label ("Message:    ") in the log template.
            Assert.AreEqual("//\t            ", LogEntryFormatter.ContinuationPrefix);
        }

        [TestMethod]
        public void Format_ReturnedStringContainsHeaderAndFooterDelimiters()
        {
            // Arrange
            var date = new DateTime(2026, 1, 15, 10, 30, 0);
            const string packageId = "MyPackage";
            const string code = "ERR001";
            const string message = "Something went wrong";

            // Act
            var result = LogEntryFormatter.Format(date, packageId, code, message);

            // Assert
            StringAssert.Contains(result, "//--------------------------------------------------//");
            Assert.IsTrue(result.IndexOf("//--------------------------------------------------//",
                              StringComparison.Ordinal)
                          != result.LastIndexOf("//--------------------------------------------------//",
                              StringComparison.Ordinal),
                "Both the opening and closing delimiter lines must be present.");
        }

        [TestMethod]
        public void Format_ReturnedStringContainsAllFieldValues()
        {
            // Arrange
            var date = new DateTime(2026, 1, 15, 10, 30, 0);
            const string packageId = "TestPackage";
            const string code = "CODE42";
            const string message = "Test message";

            // Act
            var result = LogEntryFormatter.Format(date, packageId, code, message);

            // Assert
            StringAssert.Contains(result, "TestPackage");
            StringAssert.Contains(result, "CODE42");
            StringAssert.Contains(result, "Test message");
        }

        [TestMethod]
        public void Format_MultilineMessage_WrappedLinesStartWithContinuationPrefix()
        {
            // Arrange
            var date = new DateTime(2026, 1, 15, 10, 30, 0);
            const string packageId = "Pkg";
            const string code = "C01";
            const string message = "First line\r\nSecond line\r\nThird line";
            var prefix = LogEntryFormatter.ContinuationPrefix;

            // Act
            var result = LogEntryFormatter.Format(date, packageId, code, message);

            // Assert — the second and third lines of the message must be prefixed inside the block
            StringAssert.Contains(result, prefix + "Second line");
            StringAssert.Contains(result, prefix + "Third line");
        }

        [TestMethod]
        public void Format_ExceptionOverload_ContainsExceptionTypeInBlock()
        {
            // Arrange — simulate the Exception overload: pass exception.ToString() as the message
            var date = new DateTime(2026, 6, 15, 0, 0, 0);
            const string packageId = "Pkg";
            const string code = "EXCEPTION";
            var ex = new InvalidOperationException("boom");
            var message = ex.ToString();

            // Act
            var result = LogEntryFormatter.Format(date, packageId, code, message);

            // Assert
            StringAssert.Contains(result, "EXCEPTION");
            StringAssert.Contains(result, "InvalidOperationException");
        }
    }
}