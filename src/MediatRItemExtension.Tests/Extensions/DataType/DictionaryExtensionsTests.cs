// ***********************************************************************
//  Assembly          : MediatRItemExtension.MediatRItemExtension.Tests
//  Author            : RzR
//  Created           : 15-06-2026 23:06
// 
//  Last Modified By : RzR
//  Last Modified On : 16-06-2026 19:51
//  ***********************************************************************
//  <copyright file="DictionaryExtensionsTests.cs" company="RzR SOFT & TECH">
//      Copyright (c) RzR. All rights reserved.
//  </copyright>
//  <contact>
//      https://iamrzr.dev/contact
//  </contact>
//  <summary></summary>
//  ***********************************************************************

#region U S I N G

using System.Collections.Generic;
using MediatRItemExtension.Extensions.DataType;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace MediatRItemExtension.Tests.Extensions.DataType
{
    [TestClass]
    public class DictionaryExtensionsTests
    {
        [TestMethod]
        public void AddOrUpdate_WhenKeyDoesNotExist_AddsKeyValuePair()
        {
            // Arrange
            IDictionary<string, int> source = new Dictionary<string, int>();
            var keyValue = new KeyValuePair<string, int>("alpha", 10);

            // Act
            source.AddOrUpdate(keyValue);

            // Assert
            Assert.IsTrue(source.ContainsKey("alpha"));
            Assert.AreEqual(10, source["alpha"]);
        }

        [TestMethod]
        public void AddOrUpdate_WhenKeyAlreadyExists_UpdatesExistingValue()
        {
            // Arrange
            IDictionary<string, int> source = new Dictionary<string, int>
            {
                { "alpha", 10 }
            };
            var keyValue = new KeyValuePair<string, int>("alpha", 99);

            // Act
            source.AddOrUpdate(keyValue);

            // Assert
            Assert.AreEqual(99, source["alpha"]);
            Assert.AreEqual(1, source.Count, "Entry count must remain 1 — no duplicate key inserted.");
        }

        [TestMethod]
        public void AddOrUpdate_WhenKeyDoesNotExist_ReturnsSameDictionaryInstance()
        {
            // Arrange
            IDictionary<string, int> source = new Dictionary<string, int>();
            var keyValue = new KeyValuePair<string, int>("beta", 5);

            // Act
            var returned = source.AddOrUpdate(keyValue);

            // Assert
            Assert.AreSame(source, returned, "Return value must be the same dictionary instance, not a copy.");
        }

        [TestMethod]
        public void AddOrUpdate_WhenKeyAlreadyExists_ReturnsSameDictionaryInstance()
        {
            // Arrange
            IDictionary<string, int> source = new Dictionary<string, int>
            {
                { "beta", 5 }
            };
            var keyValue = new KeyValuePair<string, int>("beta", 42);

            // Act
            var returned = source.AddOrUpdate(keyValue);

            // Assert
            Assert.AreSame(source, returned, "Return value must be the same dictionary instance, not a copy.");
        }
    }
}