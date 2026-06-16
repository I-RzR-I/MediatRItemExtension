// ***********************************************************************
//  Assembly          : MediatRItemExtension.MediatRItemExtension.Tests
//  Author            : RzR
//  Created           : 15-06-2026 22:06
// 
//  Last Modified By : RzR
//  Last Modified On : 16-06-2026 19:51
//  ***********************************************************************
//  <copyright file="StringExtensionsTests.cs" company="RzR SOFT & TECH">
//      Copyright (c) RzR. All rights reserved.
//  </copyright>
//  <contact>
//      https://iamrzr.dev/contact
//  </contact>
//  <summary></summary>
//  ***********************************************************************

#region U S I N G

using MediatRItemExtension.Extensions.DataType;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace MediatRItemExtension.Tests.Extensions.DataType
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void IsMissing_NullString_ReturnsTrue()
        {
            // Arrange
            string source = null;

            // Act
            var result = source.IsMissing();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsMissing_EmptyString_ReturnsTrue()
        {
            // Arrange
            var source = string.Empty;

            // Act
            var result = source.IsMissing();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsMissing_WhitespaceOnlyString_ReturnsTrue()
        {
            // Arrange
            var source = "   ";

            // Act
            var result = source.IsMissing();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsMissing_TabAndNewlineOnlyString_ReturnsTrue()
        {
            // Arrange
            var source = "\t\n";

            // Act
            var result = source.IsMissing();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsMissing_NonEmptyString_ReturnsFalse()
        {
            // Arrange
            var source = "hello";

            // Act
            var result = source.IsMissing();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsMissing_SingleCharString_ReturnsFalse()
        {
            // Arrange
            var source = "x";

            // Act
            var result = source.IsMissing();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsPresent_NullString_ReturnsFalse()
        {
            // Arrange
            string source = null;

            // Act
            var result = source.IsPresent();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsPresent_EmptyString_ReturnsFalse()
        {
            // Arrange
            var source = string.Empty;

            // Act
            var result = source.IsPresent();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsPresent_WhitespaceOnlyString_ReturnsFalse()
        {
            // Arrange
            var source = "   ";

            // Act
            var result = source.IsPresent();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsPresent_NonEmptyString_ReturnsTrue()
        {
            // Arrange
            var source = "hello";

            // Act
            var result = source.IsPresent();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPresent_StringWithLeadingAndTrailingSpacesAroundContent_ReturnsTrue()
        {
            // Arrange
            var source = "  a  ";

            // Act
            var result = source.IsPresent();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsMissingAndIsPresent_AreComplementary_ForSameInput()
        {
            // Arrange
            var source = "test";

            // Act & Assert
            Assert.AreNotEqual(source.IsMissing(), source.IsPresent());
        }

        [TestMethod]
        public void IsNullOrEmpty_NullString_ReturnsTrue()
        {
            // Arrange
            string str = null;

            // Act
            var result = str.IsNullOrEmpty();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNullOrEmpty_EmptyString_ReturnsTrue()
        {
            // Arrange
            var str = string.Empty;

            // Act
            var result = str.IsNullOrEmpty();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNullOrEmpty_WhitespaceString_ReturnsFalse()
        {
            // Arrange
            // IsNullOrEmpty differs from IsMissing: whitespace is NOT empty.
            var str = "   ";

            // Act
            var result = str.IsNullOrEmpty();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNullOrEmpty_NonEmptyString_ReturnsFalse()
        {
            // Arrange
            var str = "hello";

            // Act
            var result = str.IsNullOrEmpty();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BuildKeyStore_MultipleKeys_JoinsWithUnderscore()
        {
            // Arrange / Act
            var result = StringExtensions.BuildKeyStore("alpha", "beta", "gamma");

            // Assert
            Assert.AreEqual("alpha_beta_gamma", result);
        }

        [TestMethod]
        public void BuildKeyStore_SingleKey_ReturnsThatKey()
        {
            // Arrange / Act
            var result = StringExtensions.BuildKeyStore("solo");

            // Assert
            Assert.AreEqual("solo", result);
        }

        [TestMethod]
        public void BuildKeyStore_NoKeys_ReturnsEmptyString()
        {
            // Arrange / Act
            var result = StringExtensions.BuildKeyStore();

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void BuildKeyStore_TwoKeys_ProducesOneUnderscore()
        {
            // Arrange / Act
            var result = StringExtensions.BuildKeyStore("A", "B");

            // Assert
            Assert.AreEqual("A_B", result);
        }

        [TestMethod]
        public void BuildKeyStore_KeysContainingUnderscores_DoesNotMergeOrCollapse()
        {
            // Arrange
            // Existing underscores in keys are preserved as-is; the separator
            // underscore is still inserted between keys.
            var result = StringExtensions.BuildKeyStore("a_b", "c");

            // Assert
            Assert.AreEqual("a_b_c", result);
        }

        [TestMethod]
        public void SubstringAt_SearchTextFound_ReturnsSubstringFromFirstOccurrence()
        {
            // Arrange
            var source = "Hello.World.Namespace";
            var searchText = ".World";

            // Act
            var result = source.SubstringAt(searchText);

            // Assert
            Assert.AreEqual(".World.Namespace", result);
        }

        [TestMethod]
        public void SubstringAt_SearchTextAtStart_ReturnsWholeString()
        {
            // Arrange
            var source = "StartMiddleEnd";
            var searchText = "Start";

            // Act
            var result = source.SubstringAt(searchText);

            // Assert
            Assert.AreEqual("StartMiddleEnd", result);
        }

        [TestMethod]
        public void SubstringAt_SearchTextAtEnd_ReturnsSearchText()
        {
            // Arrange
            var source = "PrefixEnd";
            var searchText = "End";

            // Act
            var result = source.SubstringAt(searchText);

            // Assert
            Assert.AreEqual("End", result);
        }

        [TestMethod]
        public void SubstringAt_SearchTextNotFound_ReturnsOriginalSource()
        {
            // Arrange
            var source = "Hello World";
            var searchText = "Missing";

            // Act
            var result = source.SubstringAt(searchText);

            // Assert
            Assert.AreEqual("Hello World", result);
        }

        [TestMethod]
        public void SubstringAt_NullSource_ReturnsEmptyString()
        {
            // Arrange
            string source = null;

            // Act
            var result = source.SubstringAt("text");

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void SubstringAt_EmptySource_ReturnsEmptyString()
        {
            // Arrange
            var source = string.Empty;

            // Act
            var result = source.SubstringAt("text");

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void SubstringAt_NullSearchText_ReturnsEmptyString()
        {
            // Arrange
            var source = "Hello World";

            // Act
            var result = source.SubstringAt(null);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void SubstringAt_WhitespaceSearchText_ReturnsEmptyString()
        {
            // Arrange
            var source = "Hello World";

            // Act
            var result = source.SubstringAt("   ");

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void SubstringAt_DuplicateOccurrencesOfSearchText_ReturnsFromFirstOccurrence()
        {
            // Arrange
            // IndexOf returns the first occurrence, so the result should start there.
            var source = "aXbXc";
            var searchText = "X";

            // Act
            var result = source.SubstringAt(searchText);

            // Assert
            Assert.AreEqual("XbXc", result);
        }

        [TestMethod]
        public void TruncateAndSetToPath_NullPath_ReturnsEmptyString()
        {
            // Arrange
            string path = null;

            // Act
            var result = path.TruncateAndSetToPath();

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void TruncateAndSetToPath_EmptyPath_ReturnsEmptyString()
        {
            // Arrange
            var path = string.Empty;

            // Act
            var result = path.TruncateAndSetToPath();

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void TruncateAndSetToPath_WhitespacePath_ReturnsEmptyString()
        {
            // Arrange
            var path = "   ";

            // Act
            var result = path.TruncateAndSetToPath();

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void TruncateAndSetToPath_ShortPathWithForwardSlash_ReturnsPathWithEllipsisPrefixAndTrailingSlash()
        {
            // Arrange
            // Path is shorter than maxLength (90), so no truncation — just "..." prefix
            // and trailing "/" appended.
            var path = "src/Project/";

            // Act
            var result = path.TruncateAndSetToPath();

            // Assert
            Assert.AreEqual("...src/Project/", result);
        }

        [TestMethod]
        public void TruncateAndSetToPath_ShortPathWithoutTrailingSlash_AppendsTrailingSlash()
        {
            // Arrange
            var path = "src/Project";

            // Act
            var result = path.TruncateAndSetToPath();

            // Assert
            Assert.IsTrue(result.EndsWith("/"));
            Assert.AreEqual("...src/Project/", result);
        }

        [TestMethod]
        public void TruncateAndSetToPath_BackslashesInPath_ReplacedWithForwardSlashes()
        {
            // Arrange
            var path = @"C:\Users\Dev\Project";

            // Act
            var result = path.TruncateAndSetToPath();

            // Assert
            Assert.IsFalse(result.Contains("\\"));
            Assert.IsTrue(result.Contains("/"));
        }

        [TestMethod]
        public void TruncateAndSetToPath_LongPath_TruncatesToMaxLengthMinusOneBeforeSlash()
        {
            // Arrange
            // Path exactly at maxLength triggers truncation.
            // startIdx = path.Length - maxLength + 4
            // result before "/" is "..." + path[startIdx..] which has length = maxLength - 1.
            var maxLength = 90;
            var path = new string('a', maxLength); // length == maxLength, triggers truncation

            // Act
            var result = path.TruncateAndSetToPath(maxLength);

            // Assert
            // Strip trailing "/" and verify the truncated body has exactly maxLength-1 chars.
            var body = result.TrimEnd('/');
            Assert.AreEqual(maxLength - 1, body.Length,
                $"Expected truncated body length {maxLength - 1} but got {body.Length}");
            Assert.IsTrue(result.StartsWith("..."));
            Assert.IsTrue(result.EndsWith("/"));
        }

        [TestMethod]
        public void TruncateAndSetToPath_PathLongerThanMaxLength_TruncatesCorrectly()
        {
            // Arrange
            var maxLength = 10;
            // "abcdefghijk" = 11 chars; triggers truncation (>= 10)
            var path = "abcdefghijk";
            // startIdx = 11 - 10 + 4 = 5
            // substring from index 5 = "fghijk"
            // result = "..." + "fghijk" + "/" = "...fghijk/"
            var expected = "...fghijk/";

            // Act
            var result = path.TruncateAndSetToPath(maxLength);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TruncateAndSetToPath_PathExactlyAtMaxLength_TruncatesCorrectly()
        {
            // Arrange
            var maxLength = 10;
            // "abcdefghij" = 10 chars; triggers truncation (>= 10)
            var path = "abcdefghij";
            // startIdx = 10 - 10 + 4 = 4
            // substring from index 4 = "efghij"
            // result = "..." + "efghij" + "/" = "...efghij/"
            var expected = "...efghij/";

            // Act
            var result = path.TruncateAndSetToPath(maxLength);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TruncateAndSetToPath_PathShorterThanMaxLength_NoTruncationOccurs()
        {
            // Arrange
            var maxLength = 20;
            var path = "short/path"; // 10 chars < 20

            // Act
            var result = path.TruncateAndSetToPath(maxLength);

            // Assert
            // All original characters must be retained.
            Assert.IsTrue(result.Contains("short/path"));
            Assert.IsTrue(result.StartsWith("..."));
        }

        [TestMethod]
        public void TruncateAndSetToPath_MixedSlashPath_AllBackslashesReplaced()
        {
            // Arrange
            var path = @"C:\src\sub/leaf";

            // Act
            var result = path.TruncateAndSetToPath();

            // Assert
            Assert.IsFalse(result.Contains("\\"));
        }

        [TestMethod]
        public void IfNullThenEmpty_NullSource_ReturnsEmptyString()
        {
            // Arrange
            string source = null;

            // Act
            var result = source.IfNullThenEmpty();

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void IfNullThenEmpty_NonNullSource_ReturnsSameValue()
        {
            // Arrange
            var source = "hello";

            // Act
            var result = source.IfNullThenEmpty();

            // Assert
            Assert.AreEqual("hello", result);
        }

        [TestMethod]
        public void IfNullThenEmpty_EmptyStringSource_ReturnsEmptyString()
        {
            // Arrange
            var source = string.Empty;

            // Act
            var result = source.IfNullThenEmpty();

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void IfNullThenEmpty_WhitespaceSource_ReturnsSameWhitespace()
        {
            // Arrange
            var source = "   ";

            // Act
            var result = source.IfNullThenEmpty();

            // Assert
            Assert.AreEqual("   ", result);
        }

        [TestMethod]
        public void ReplaceExact_NullInput_ReturnsNull()
        {
            // Arrange
            string input = null;

            // Act
            var result = input.ReplaceExact("old", "new");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ReplaceExact_WhitespaceInput_ReturnsNull()
        {
            // Arrange
            var input = "   ";

            // Act
            var result = input.ReplaceExact("old", "new");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ReplaceExact_EmptyInput_ReturnsNull()
        {
            // Arrange
            var input = string.Empty;

            // Act
            var result = input.ReplaceExact("old", "new");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ReplaceExact_NullOldValue_ReturnsInputUnchanged()
        {
            // Arrange
            var input = "some text";

            // Act
            var result = input.ReplaceExact(null, "new");

            // Assert
            Assert.AreEqual("some text", result);
        }

        [TestMethod]
        public void ReplaceExact_EmptyOldValue_ReturnsInputUnchanged()
        {
            // Arrange
            var input = "some text";

            // Act
            var result = input.ReplaceExact(string.Empty, "new");

            // Assert
            Assert.AreEqual("some text", result);
        }

        [TestMethod]
        public void ReplaceExact_WhitespaceOldValue_ReturnsInputUnchanged()
        {
            // Arrange
            var input = "some text";

            // Act
            var result = input.ReplaceExact("   ", "new");

            // Assert
            Assert.AreEqual("some text", result);
        }

        [TestMethod]
        public void ReplaceExact_ExactWordMatch_ReplacesWord()
        {
            // Arrange
            var input = "public class MyClass { }";

            // Act
            var result = input.ReplaceExact("class", "record");

            // Assert
            Assert.AreEqual("public record MyClass { }", result);
        }

        [TestMethod]
        public void ReplaceExact_OldValueIsSubstringOfAnotherWord_DoesNotReplace()
        {
            // Arrange
            // "class" should NOT match inside "MyClass" due to word-boundary (\b).
            var input = "public MyClass { }";

            // Act
            var result = input.ReplaceExact("class", "record");

            // Assert
            Assert.AreEqual("public MyClass { }", result);
        }

        [TestMethod]
        public void ReplaceExact_OldValueAppearsMultipleTimes_ReplacesAllOccurrences()
        {
            // Arrange
            var input = "foo and foo";

            // Act
            var result = input.ReplaceExact("foo", "bar");

            // Assert
            Assert.AreEqual("bar and bar", result);
        }

        [TestMethod]
        public void ReplaceExact_OldValueMatchesWholeString_ReplacesEntireContent()
        {
            // Arrange
            var input = "class";

            // Act
            var result = input.ReplaceExact("class", "record");

            // Assert
            Assert.AreEqual("record", result);
        }

        [TestMethod]
        public void ReplaceExact_OldValueNotPresent_ReturnsInputUnchanged()
        {
            // Arrange
            var input = "hello world";

            // Act
            var result = input.ReplaceExact("missing", "replacement");

            // Assert
            Assert.AreEqual("hello world", result);
        }

        [TestMethod]
        public void ReplaceExact_ClassToRecordReplacement_TypicalVsixScenario()
        {
            // Arrange
            // Mirrors the real use-case: swapping the class keyword in a generated
            // file header without touching class names embedded in identifiers.
            var input = "public class MyRequest : IRequest { }";

            // Act
            var result = input.ReplaceExact("class", "record");

            // Assert
            Assert.AreEqual("public record MyRequest : IRequest { }", result);
        }

        [TestMethod]
        public void ReplaceExact_WordAtStartOfString_IsReplaced()
        {
            // Arrange
            var input = "class Foo { }";

            // Act
            var result = input.ReplaceExact("class", "record");

            // Assert
            Assert.AreEqual("record Foo { }", result);
        }

        [TestMethod]
        public void ReplaceExact_WordAtEndOfString_IsReplaced()
        {
            // Arrange
            var input = "see class";

            // Act
            var result = input.ReplaceExact("class", "record");

            // Assert
            Assert.AreEqual("see record", result);
        }
    }
}