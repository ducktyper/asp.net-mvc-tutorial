using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTutorial.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace MvcTutorial.Tests.Models
{
    [TestClass]
    public class HouseTest
    {
        [TestInitialize]
        public void SetLocal()
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = ci;
        }

        [TestMethod]
        public void TestValidHouse()
        {
            var model = ValidHouse();
            var context = new ValidationContext(model);
            try
            {
                Validator.ValidateObject(model, context);
            }
            catch (ValidationException ext)
            {
                Assert.Fail(ext.Message);
            }
        }

        [TestMethod]
        public void TestNumberOfRooms_Required()
        {
            var model = ValidHouse();
            model.NumberOfRooms = null;
            AssertValidation("The NumberOfRooms field is required.", model);
        }

        [TestMethod]
        public void TestNumberOfRooms_Range()
        {
            var model = ValidHouse();
            model.NumberOfRooms = 101;
            AssertValidation("The field NumberOfRooms must be between 1 and 100.", model);
        }

        private House ValidHouse()
        {
            return new House()
            {
                NumberOfRooms = 3
            };
        }

        private void AssertValidation(string message, Object model)
        {
            var context = new ValidationContext(model);
            try
           {
                Validator.ValidateObject(model, context, true);
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
