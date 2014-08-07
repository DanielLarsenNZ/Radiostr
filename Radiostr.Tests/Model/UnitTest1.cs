using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Radiostr.Model;

namespace Radiostr.Tests.Model
{
    [TestClass]
    public class TrackModelTests
    {
        [TestMethod]
        public void Version_NewlyCreatedEntity_NoException()
        {
            // Arrange
            

            // Act
            var track = new TrackModel("test title", new ArtistModel { Name = "artist name" }, 1000);

            // Assert
            Debug.WriteLine(track.ToString());
        }
    }

}
