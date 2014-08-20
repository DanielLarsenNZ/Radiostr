using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiostr.Model;
using Radiostr.Model.Extensions;

namespace Radiostr.Tests.Model.Extensions
{
    [TestClass]
    public class ValidationExtensionsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Validate_NullInstance_Throws()
        {
            // Arrange
            TrackModel instance = null;

            // Act
            try
            {
                instance.Validate();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }            
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Validate_TrackModel_Throws()
        {
            // Arrange
            var instance = new TrackModel();

            // Act
            try
            {
                instance.Validate();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }            
        }
    }
}
