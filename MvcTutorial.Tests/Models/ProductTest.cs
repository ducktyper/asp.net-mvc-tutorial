using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTutorial;
using MvcTutorial.Models;
using System.ComponentModel.DataAnnotations;

namespace MvcTutorial.Tests.Models
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void TestNameRequired()
        {
            var model = new Product();
            AssertValidation("The Name field is required.", model);
        }

        private void AssertValidation(string message, Object model)
        {
            var context = new ValidationContext(model);
            try
            {
                Validator.ValidateObject(model, context);
            }
            catch (ValidationException ext)
            {
                Assert.AreEqual(message, ext.Message);
                return;
            }
            Assert.Fail("Expected validation errors");
        }
    }
}
