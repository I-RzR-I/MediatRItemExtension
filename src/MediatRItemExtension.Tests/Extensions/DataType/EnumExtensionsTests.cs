// ***********************************************************************
//  Assembly          : MediatRItemExtension.MediatRItemExtension.Tests
//  Author            : RzR
//  Created           : 15-06-2026 23:06
// 
//  Last Modified By : RzR
//  Last Modified On : 16-06-2026 19:51
//  ***********************************************************************
//  <copyright file="EnumExtensionsTests.cs" company="RzR SOFT & TECH">
//      Copyright (c) RzR. All rights reserved.
//  </copyright>
//  <contact>
//      https://iamrzr.dev/contact
//  </contact>
//  <summary></summary>
//  ***********************************************************************

#region U S I N G

using System.Linq;
using MediatRItemExtension.Enums;
using MediatRItemExtension.Extensions.DataType;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace MediatRItemExtension.Tests.Extensions.DataType
{
    [TestClass]
    public class EnumExtensionsTests
    {
        [TestMethod]
        public void ToNameValues_OperationBlueprintType_CountMatchesEnumMemberCount()
        {
            // Arrange
            const int expectedCount = 2;

            // Act
            var result = EnumExtensions.ToNameValues<OperationBlueprintType>().ToList();

            // Assert
            Assert.AreEqual(expectedCount, result.Count);
        }

        [TestMethod]
        public void ToNameValues_OperationBlueprintType_ContainsClassName()
        {
            // Act
            var result = EnumExtensions.ToNameValues<OperationBlueprintType>().ToList();

            // Assert
            Assert.IsTrue(result.Any(x => x.Name == nameof(OperationBlueprintType.Class)));
        }

        [TestMethod]
        public void ToNameValues_OperationBlueprintType_ContainsRecordName()
        {
            // Act
            var result = EnumExtensions.ToNameValues<OperationBlueprintType>().ToList();

            // Assert
            Assert.IsTrue(result.Any(x => x.Name == nameof(OperationBlueprintType.Record)));
        }

        [TestMethod]
        public void ToNameValues_OperationBlueprintType_ClassEntryValueEqualsClassMember()
        {
            // Act
            var result = EnumExtensions.ToNameValues<OperationBlueprintType>().ToList();

            // Assert
            var entry = result.Single(x => x.Name == nameof(OperationBlueprintType.Class));
            Assert.AreEqual(OperationBlueprintType.Class, entry.Value);
        }

        [TestMethod]
        public void ToNameValues_OperationBlueprintType_RecordEntryValueEqualsRecordMember()
        {
            // Act
            var result = EnumExtensions.ToNameValues<OperationBlueprintType>().ToList();

            // Assert
            var entry = result.Single(x => x.Name == nameof(OperationBlueprintType.Record));
            Assert.AreEqual(OperationBlueprintType.Record, entry.Value);
        }

        [TestMethod]
        public void ToNameValues_OperationBlueprintType_AllEntriesHaveIsEnabledDefaultTrue()
        {
            // Act
            var result = EnumExtensions.ToNameValues<OperationBlueprintType>().ToList();

            // Assert
            Assert.IsTrue(result.All(x => x.IsEnabled));
        }

        [TestMethod]
        public void ToNameValues_OperationType_CountMatchesEnumMemberCount()
        {
            // Arrange
            const int expectedCount = 4;

            // Act
            var result = EnumExtensions.ToNameValues<OperationType>().ToList();

            // Assert
            Assert.AreEqual(expectedCount, result.Count);
        }

        [TestMethod]
        public void ToNameValues_OperationType_ContainsQueryName()
        {
            // Act
            var result = EnumExtensions.ToNameValues<OperationType>().ToList();

            // Assert
            Assert.IsTrue(result.Any(x => x.Name == nameof(OperationType.Query)));
        }

        [TestMethod]
        public void ToNameValues_OperationType_ContainsCommandName()
        {
            // Act
            var result = EnumExtensions.ToNameValues<OperationType>().ToList();

            // Assert
            Assert.IsTrue(result.Any(x => x.Name == nameof(OperationType.Command)));
        }

        [TestMethod]
        public void ToNameValues_OperationType_ContainsNotificationName()
        {
            // Act
            var result = EnumExtensions.ToNameValues<OperationType>().ToList();

            // Assert
            Assert.IsTrue(result.Any(x => x.Name == nameof(OperationType.Notification)));
        }

        [TestMethod]
        public void ToNameValues_OperationType_ContainsStreamName()
        {
            // Act
            var result = EnumExtensions.ToNameValues<OperationType>().ToList();

            // Assert
            Assert.IsTrue(result.Any(x => x.Name == nameof(OperationType.Stream)));
        }

        [TestMethod]
        public void ToNameValues_OperationType_QueryEntryValueEqualsQueryMember()
        {
            // Act
            var result = EnumExtensions.ToNameValues<OperationType>().ToList();

            // Assert
            var entry = result.Single(x => x.Name == nameof(OperationType.Query));
            Assert.AreEqual(OperationType.Query, entry.Value);
        }

        [TestMethod]
        public void ToNameValues_OperationType_CommandEntryValueEqualsCommandMember()
        {
            // Act
            var result = EnumExtensions.ToNameValues<OperationType>().ToList();

            // Assert
            var entry = result.Single(x => x.Name == nameof(OperationType.Command));
            Assert.AreEqual(OperationType.Command, entry.Value);
        }

        [TestMethod]
        public void ToNameValues_OperationType_NotificationEntryValueEqualsNotificationMember()
        {
            // Act
            var result = EnumExtensions.ToNameValues<OperationType>().ToList();

            // Assert
            var entry = result.Single(x => x.Name == nameof(OperationType.Notification));
            Assert.AreEqual(OperationType.Notification, entry.Value);
        }

        [TestMethod]
        public void ToNameValues_OperationType_StreamEntryValueEqualsStreamMember()
        {
            // Act
            var result = EnumExtensions.ToNameValues<OperationType>().ToList();

            // Assert
            var entry = result.Single(x => x.Name == nameof(OperationType.Stream));
            Assert.AreEqual(OperationType.Stream, entry.Value);
        }

        [TestMethod]
        public void ToNameValues_OperationType_AllEntriesHaveIsEnabledDefaultTrue()
        {
            // Act
            var result = EnumExtensions.ToNameValues<OperationType>().ToList();

            // Assert
            Assert.IsTrue(result.All(x => x.IsEnabled));
        }

        [TestMethod]
        public void ToNameValues_ProcessType_CountMatchesEnumMemberCount()
        {
            // Arrange
            const int expectedCount = 2;

            // Act
            var result = EnumExtensions.ToNameValues<ProcessType>().ToList();

            // Assert
            Assert.AreEqual(expectedCount, result.Count);
        }

        [TestMethod]
        public void ToNameValues_ProcessType_ContainsAsyncName()
        {
            // Act
            var result = EnumExtensions.ToNameValues<ProcessType>().ToList();

            // Assert
            Assert.IsTrue(result.Any(x => x.Name == nameof(ProcessType.Async)));
        }

        [TestMethod]
        public void ToNameValues_ProcessType_ContainsSyncName()
        {
            // Act
            var result = EnumExtensions.ToNameValues<ProcessType>().ToList();

            // Assert
            Assert.IsTrue(result.Any(x => x.Name == nameof(ProcessType.Sync)));
        }

        [TestMethod]
        public void ToNameValues_ProcessType_AsyncEntryValueEqualsAsyncMember()
        {
            // Act
            var result = EnumExtensions.ToNameValues<ProcessType>().ToList();

            // Assert
            var entry = result.Single(x => x.Name == nameof(ProcessType.Async));
            Assert.AreEqual(ProcessType.Async, entry.Value);
        }

        [TestMethod]
        public void ToNameValues_ProcessType_SyncEntryValueEqualsSyncMember()
        {
            // Act
            var result = EnumExtensions.ToNameValues<ProcessType>().ToList();

            // Assert
            var entry = result.Single(x => x.Name == nameof(ProcessType.Sync));
            Assert.AreEqual(ProcessType.Sync, entry.Value);
        }

        [TestMethod]
        public void ToNameValues_ProcessType_AllEntriesHaveIsEnabledDefaultTrue()
        {
            // Act
            var result = EnumExtensions.ToNameValues<ProcessType>().ToList();

            // Assert
            Assert.IsTrue(result.All(x => x.IsEnabled));
        }

        [TestMethod]
        public void ToNameValues_VersionCheckResultType_CountMatchesEnumMemberCount()
        {
            // Arrange
            const int expectedCount = 3;

            // Act
            var result = EnumExtensions.ToNameValues<VersionCheckResultType>().ToList();

            // Assert
            Assert.AreEqual(expectedCount, result.Count);
        }

        [TestMethod]
        public void ToNameValues_VersionCheckResultType_ContainsUpToDateName()
        {
            // Act
            var result = EnumExtensions.ToNameValues<VersionCheckResultType>().ToList();

            // Assert
            Assert.IsTrue(result.Any(x => x.Name == nameof(VersionCheckResultType.UpToDate)));
        }

        [TestMethod]
        public void ToNameValues_VersionCheckResultType_ContainsExistNewVersionName()
        {
            // Act
            var result = EnumExtensions.ToNameValues<VersionCheckResultType>().ToList();

            // Assert
            Assert.IsTrue(result.Any(x => x.Name == nameof(VersionCheckResultType.ExistNewVersion)));
        }

        [TestMethod]
        public void ToNameValues_VersionCheckResultType_ContainsErrorCheckName()
        {
            // Act
            var result = EnumExtensions.ToNameValues<VersionCheckResultType>().ToList();

            // Assert
            Assert.IsTrue(result.Any(x => x.Name == nameof(VersionCheckResultType.ErrorCheck)));
        }

        [TestMethod]
        public void ToNameValues_VersionCheckResultType_UpToDateEntryValueEqualsUpToDateMember()
        {
            // Act
            var result = EnumExtensions.ToNameValues<VersionCheckResultType>().ToList();

            // Assert
            var entry = result.Single(x => x.Name == nameof(VersionCheckResultType.UpToDate));
            Assert.AreEqual(VersionCheckResultType.UpToDate, entry.Value);
        }

        [TestMethod]
        public void ToNameValues_VersionCheckResultType_ExistNewVersionEntryValueEqualsExistNewVersionMember()
        {
            // Act
            var result = EnumExtensions.ToNameValues<VersionCheckResultType>().ToList();

            // Assert
            var entry = result.Single(x => x.Name == nameof(VersionCheckResultType.ExistNewVersion));
            Assert.AreEqual(VersionCheckResultType.ExistNewVersion, entry.Value);
        }

        [TestMethod]
        public void ToNameValues_VersionCheckResultType_ErrorCheckEntryValueEqualsErrorCheckMember()
        {
            // Act
            var result = EnumExtensions.ToNameValues<VersionCheckResultType>().ToList();

            // Assert
            var entry = result.Single(x => x.Name == nameof(VersionCheckResultType.ErrorCheck));
            Assert.AreEqual(VersionCheckResultType.ErrorCheck, entry.Value);
        }

        [TestMethod]
        public void ToNameValues_VersionCheckResultType_UpToDateEntryHasExplicitIntValueZero()
        {
            // Verifies that the explicit ordinal assignment (UpToDate = 0) is preserved through reflection.

            // Act
            var result = EnumExtensions.ToNameValues<VersionCheckResultType>().ToList();

            // Assert
            var entry = result.Single(x => x.Name == nameof(VersionCheckResultType.UpToDate));
            Assert.AreEqual(0, (int)(object)entry.Value);
        }

        [TestMethod]
        public void ToNameValues_VersionCheckResultType_ExistNewVersionEntryHasExplicitIntValueOne()
        {
            // Act
            var result = EnumExtensions.ToNameValues<VersionCheckResultType>().ToList();

            // Assert
            var entry = result.Single(x => x.Name == nameof(VersionCheckResultType.ExistNewVersion));
            Assert.AreEqual(1, (int)(object)entry.Value);
        }

        [TestMethod]
        public void ToNameValues_VersionCheckResultType_ErrorCheckEntryHasExplicitIntValueTwo()
        {
            // Act
            var result = EnumExtensions.ToNameValues<VersionCheckResultType>().ToList();

            // Assert
            var entry = result.Single(x => x.Name == nameof(VersionCheckResultType.ErrorCheck));
            Assert.AreEqual(2, (int)(object)entry.Value);
        }

        [TestMethod]
        public void ToNameValues_VersionCheckResultType_AllEntriesHaveIsEnabledDefaultTrue()
        {
            // Act
            var result = EnumExtensions.ToNameValues<VersionCheckResultType>().ToList();

            // Assert
            Assert.IsTrue(result.All(x => x.IsEnabled));
        }

        [TestMethod]
        public void GetDescription_WhenEnumValueIsUndefined_ReturnsNull()
        {
            // An enum cast from an integer that has no matching named member produces
            // a value whose .ToString() returns the integer literal; GetField() then
            // returns null for that string key, so the implementation returns null.
            // This covers the fieldInfo.IsNull() early-return branch.

            // Arrange
            var value = (TestDescriptionEnum)999;

            // Act
            var result = value.GetDescription();

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetDescription_WhenEnumValueIsUndefined_ReturnEmptyTrue_StillReturnsNull()
        {
            // returnEmpty only affects the no-description / defined-member branch.
            // The undefined-member branch (fieldInfo == null) returns null unconditionally.

            // Arrange
            var value = (TestDescriptionEnum)999;

            // Act
            var result = value.GetDescription(true);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetDescription_WhenMemberHasDescriptionAttribute_ReturnsAttributeDescription()
        {
            // Arrange
            var value = TestDescriptionEnum.WithDescription;

            // Act
            var result = value.GetDescription();

            // Assert
            Assert.AreEqual("My Description", result);
        }

        [TestMethod]
        public void GetDescription_WhenMemberHasDescriptionAttribute_ReturnEmpty_FlagHasNoEffect()
        {
            // When a [Description] exists the returnEmpty flag is irrelevant;
            // the attribute description must always be returned regardless.

            // Arrange
            var value = TestDescriptionEnum.WithDescription;

            // Act
            var result = value.GetDescription(true);

            // Assert
            Assert.AreEqual("My Description", result);
        }

        [TestMethod]
        public void GetDescription_WhenMemberHasEmptyDescriptionAttribute_ReturnsEmptyString()
        {
            // [Description("")] is a valid attribute — the implementation must return the
            // empty string stored in the attribute, not fall through to the name or empty fallback.

            // Arrange
            var value = TestDescriptionEnum.WithEmptyDescription;

            // Act
            var result = value.GetDescription();

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void GetDescription_WhenNoDescriptionAttribute_ReturnEmptyTrue_ReturnsEmptyString()
        {
            // Arrange
            var value = TestDescriptionEnum.WithoutDescription;

            // Act
            var result = value.GetDescription(true);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void GetDescription_WhenNoDescriptionAttribute_ReturnEmptyTrue_ResultIsNotNull()
        {
            // Arrange
            var value = TestDescriptionEnum.WithoutDescription;

            // Act
            var result = value.GetDescription(true);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetDescription_WhenNoDescriptionAttribute_ReturnEmptyFalse_ReturnsEnumName()
        {
            // Arrange
            var value = TestDescriptionEnum.WithoutDescription;

            // Act
            var result = value.GetDescription();

            // Assert
            Assert.AreEqual(nameof(TestDescriptionEnum.WithoutDescription), result);
        }

        [TestMethod]
        public void GetDescription_WhenNoDescriptionAttribute_DefaultReturnEmpty_ReturnsEnumName()
        {
            // Verifies that the default value of returnEmpty (false) produces the same
            // outcome as explicitly passing false.

            // Arrange
            var value = TestDescriptionEnum.WithoutDescription;

            // Act
            var result = value.GetDescription();

            // Assert
            Assert.AreEqual(nameof(TestDescriptionEnum.WithoutDescription), result);
        }

        [TestMethod]
        public void GetDescription_WhenNoDescriptionAttribute_ReturnedNameMatchesToString()
        {
            // The implementation returns value.ToString() on the no-description / no-empty path.
            // Confirms the return equals what Enum.ToString() produces.

            // Arrange
            var value = TestDescriptionEnum.WithoutDescription;

            // Act
            var result = value.GetDescription();

            // Assert
            Assert.AreEqual(value.ToString(), result);
        }
    }
}