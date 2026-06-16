// ***********************************************************************
//  Assembly          : MediatRItemExtension.MediatRItemExtension.Tests
//  Author            : RzR
//  Created           : 15-06-2026 23:06
// 
//  Last Modified By : RzR
//  Last Modified On : 16-06-2026 19:51
//  ***********************************************************************
//  <copyright file="BoolExtensionsTests.cs" company="RzR SOFT & TECH">
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
    public class BoolExtensionsTests
    {
        [TestMethod]
        public void IsTrue_WhenValueIsTrue_ReturnsTrue()
        {
            // Arrange
            var source = true;

            // Act
            var result = source.IsTrue();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTrue_WhenValueIsFalse_ReturnsFalse()
        {
            // Arrange
            var source = false;

            // Act
            var result = source.IsTrue();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTrue_WhenDefaultBool_ReturnsFalse()
        {
            // Arrange
            // default(bool) == false
            var source = default(bool);

            // Act
            var result = source.IsTrue();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsFalse_WhenValueIsFalse_ReturnsTrue()
        {
            // Arrange
            var source = false;

            // Act
            var result = source.IsFalse();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFalse_WhenValueIsTrue_ReturnsFalse()
        {
            // Arrange
            var source = true;

            // Act
            var result = source.IsFalse();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsFalse_WhenDefaultBool_ReturnsTrue()
        {
            // Arrange
            // default(bool) == false, so IsFalse must return true.
            var source = default(bool);

            // Act
            var result = source.IsFalse();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTrue_WhenNullableValueIsTrue_ReturnsTrue()
        {
            // Arrange
            bool? source = true;

            // Act
            var result = source.IsTrue();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTrue_WhenNullableValueIsFalse_ReturnsFalse()
        {
            // Arrange
            bool? source = false;

            // Act
            var result = source.IsTrue();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTrue_WhenNullableValueIsNull_ReturnsFalse()
        {
            // Arrange
            bool? source = null;

            // Act
            var result = source.IsTrue();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsFalse_WhenNullableValueIsFalse_ReturnsTrue()
        {
            // Arrange
            bool? source = false;

            // Act
            var result = source.IsFalse();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFalse_WhenNullableValueIsTrue_ReturnsFalse()
        {
            // Arrange
            bool? source = true;

            // Act
            var result = source.IsFalse();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsFalse_WhenNullableValueIsNull_ReturnsTrue()
        {
            // Arrange
            // A null bool? is treated as false by IsFalse.
            bool? source = null;

            // Act
            var result = source.IsFalse();

            // Assert
            Assert.IsTrue(result);
        }
    }
}