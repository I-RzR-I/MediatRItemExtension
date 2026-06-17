// ***********************************************************************
//  Assembly          : MediatRItemExtension.MediatRItemExtension.Tests
//  Author            : RzR
//  Created           : 15-06-2026 23:06
// 
//  Last Modified By : RzR
//  Last Modified On : 16-06-2026 19:51
//  ***********************************************************************
//  <copyright file="ObjectExtensionsTests.cs" company="RzR SOFT & TECH">
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
    public class ObjectExtensionsTests
    {
        [TestMethod]
        public void IsNull_WhenObjectIsNull_ReturnsTrue()
        {
            // Arrange
            object obj = null;

            // Act
            var result = obj.IsNull();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNull_WhenObjectIsNonNullReferenceType_ReturnsFalse()
        {
            // Arrange
            var obj = new object();

            // Act
            var result = obj.IsNull();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNull_WhenObjectIsNonNullString_ReturnsFalse()
        {
            // Arrange
            object obj = "hello";

            // Act
            var result = obj.IsNull();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNull_WhenObjectIsEmptyString_ReturnsFalse()
        {
            // Arrange
            // An empty string is a valid non-null reference.
            object obj = string.Empty;

            // Act
            var result = obj.IsNull();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNull_WhenObjectIsBoxedValueType_ReturnsFalse()
        {
            // Arrange
            // A boxed int is never null.
            object obj = 42;

            // Act
            var result = obj.IsNull();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNotNull_WhenObjectIsNull_ReturnsFalse()
        {
            // Arrange
            object obj = null;

            // Act
            var result = obj.IsNotNull();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNotNull_WhenObjectIsNonNullReferenceType_ReturnsTrue()
        {
            // Arrange
            var obj = new object();

            // Act
            var result = obj.IsNotNull();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNotNull_WhenObjectIsNonNullString_ReturnsTrue()
        {
            // Arrange
            object obj = "world";

            // Act
            var result = obj.IsNotNull();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNotNull_WhenObjectIsEmptyString_ReturnsTrue()
        {
            // Arrange
            // An empty string is a valid non-null reference.
            object obj = string.Empty;

            // Act
            var result = obj.IsNotNull();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNotNull_WhenObjectIsBoxedValueType_ReturnsTrue()
        {
            // Arrange
            object obj = 0;

            // Act
            var result = obj.IsNotNull();

            // Assert
            Assert.IsTrue(result);
        }
    }
}