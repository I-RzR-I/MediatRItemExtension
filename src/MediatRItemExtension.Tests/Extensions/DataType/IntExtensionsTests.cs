// ***********************************************************************
//  Assembly          : MediatRItemExtension.MediatRItemExtension.Tests
//  Author            : RzR
//  Created           : 15-06-2026 23:06
// 
//  Last Modified By : RzR
//  Last Modified On : 16-06-2026 19:51
//  ***********************************************************************
//  <copyright file="IntExtensionsTests.cs" company="RzR SOFT & TECH">
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
    public class IntExtensionsTests
    {
        [TestMethod]
        public void IsSuccessExecution_WhenCodeIsOne_ReturnsTrue()
        {
            // Arrange
            const int sourceExecCode = 1;

            // Act
            var result = sourceExecCode.IsSuccessExecution();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsSuccessExecution_WhenCodeIsZero_ReturnsFalse()
        {
            // Arrange
            const int sourceExecCode = 0;

            // Act
            var result = sourceExecCode.IsSuccessExecution();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsSuccessExecution_WhenCodeIsNegativeOne_ReturnsFalse()
        {
            // Arrange
            const int sourceExecCode = -1;

            // Act
            var result = sourceExecCode.IsSuccessExecution();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsSuccessExecution_WhenCodeIsTwo_ReturnsFalse()
        {
            // Arrange
            const int sourceExecCode = 2;

            // Act
            var result = sourceExecCode.IsSuccessExecution();

            // Assert
            Assert.IsFalse(result);
        }
    }
}