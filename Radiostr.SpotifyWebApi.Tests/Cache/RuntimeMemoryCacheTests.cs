﻿using System;
using System.Runtime.Caching;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Radiostr.SpotifyWebApi.Cache;

namespace Radiostr.SpotifyWebApi.Tests.Cache
{
    [TestClass]
    public class RuntimeMemoryCacheTests
    {
        [TestMethod]
        public void Add_Value_CacheAddCalled()
        {
            // Arrange
            var expiry = DateTime.Now.AddHours(1);

            var mockObjectCache = new Mock<ObjectCache>();
            var cache = new RuntimeMemoryCache(mockObjectCache.Object);

            // Act
            cache.Add("abc123", "def345", expiry);

            // Assert
            mockObjectCache.Verify(c => c.Add("abc123", "def345", expiry, It.IsAny<string>()));
        }

        [TestMethod]
        public void Get_Key_CacheGetCalled()
        {
            // Arrange
            var mockObjectCache = new Mock<ObjectCache>();
            var cache = new RuntimeMemoryCache(mockObjectCache.Object);

            // Act
            cache.Get("abc123");

            // Assert
            mockObjectCache.Verify(c => c.Get("abc123", It.IsAny<string>()));
        }
    }
}
