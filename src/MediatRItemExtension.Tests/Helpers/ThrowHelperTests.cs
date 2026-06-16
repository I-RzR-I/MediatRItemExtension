// ***********************************************************************
//  Assembly          : MediatRItemExtension.MediatRItemExtension.Tests
//  Author            : RzR
//  Created           : 15-06-2026 22:06
// 
//  Last Modified By : RzR
//  Last Modified On : 15-06-2026 22:56
//  ***********************************************************************
//  <copyright file="ThrowHelperTests.cs" company="RzR SOFT & TECH">
//      Copyright (c) RzR. All rights reserved.
//  </copyright>
//  <contact>
//      https://iamrzr.dev/contact
//  </contact>
//  <summary></summary>
//  ***********************************************************************

#region U S I N G

using System;
using MediatRItemExtension.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace MediatRItemExtension.Tests.Helpers
{
    [TestClass]
    public class ThrowHelperTests
    {
        [TestMethod]
        public void IfNullArgumentNullException_WhenObjectIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            object sourceObject = null;
            const string message = "sourceObject";

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                ThrowHelper.IfNullArgumentNullException(sourceObject, message));
        }

        [TestMethod]
        public void IfNullArgumentNullException_WhenObjectIsNull_ExceptionParamNameMatchesProvidedMessage()
        {
            // Arrange
            object sourceObject = null;
            const string message = "myParam";

            // Act
            ArgumentNullException exception = null;
            try
            {
                ThrowHelper.IfNullArgumentNullException(sourceObject, message);
            }
            catch (ArgumentNullException ex)
            {
                exception = ex;
            }

            // Assert
            Assert.IsNotNull(exception, "Expected ArgumentNullException was not thrown.");
            Assert.AreEqual(message, exception.ParamName,
                "ParamName must equal the message string passed to IfNullArgumentNullException.");
        }

        [TestMethod]
        public void IfNullArgumentNullException_WhenObjectIsNonNullReferenceType_DoesNotThrow()
        {
            // Arrange
            var sourceObject = new object();
            const string message = "sourceObject";

            // Act & Assert — no exception expected
            ThrowHelper.IfNullArgumentNullException(sourceObject, message);
        }

        [TestMethod]
        public void IfNullArgumentNullException_WhenObjectIsNonEmptyString_DoesNotThrow()
        {
            // Arrange
            object sourceObject = "hello";
            const string message = "sourceObject";

            // Act & Assert
            ThrowHelper.IfNullArgumentNullException(sourceObject, message);
        }

        [TestMethod]
        public void IfNullArgumentNullException_WhenObjectIsEmptyString_DoesNotThrow()
        {
            // Arrange
            // An empty string is a non-null reference; must not throw.
            object sourceObject = string.Empty;
            const string message = "sourceObject";

            // Act & Assert
            ThrowHelper.IfNullArgumentNullException(sourceObject, message);
        }

        [TestMethod]
        public void IfNullArgumentNullException_WhenObjectIsBoxedValueType_DoesNotThrow()
        {
            // Arrange
            // A boxed integer can never be null.
            object sourceObject = 42;
            const string message = "sourceObject";

            // Act & Assert
            ThrowHelper.IfNullArgumentNullException(sourceObject, message);
        }
    }
}