using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using MvcTutorial.Models;
using System.Threading;

namespace MvcTutorial.Tests.Models
{
    [TestClass]
    public class ProductTest
    {
        [TestInitialize]
        public void SetLocal()
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = ci;
        }

        [TestMethod]
        public void TestValidProduct()
        {
            var product = ValidProduct();
            var context = new ValidationContext(product);
            try
            {
                Validator.ValidateObject(product, context, true);
            }
            catch (ValidationException ext)
            {
                Assert.Fail(ext.Message);
            }
        }

        [TestMethod]
        public void TestProductKey()
        {
            var product = ValidProduct();
            product.ProductKey = "2016-invalid key";
            AssertValidation("The field ProductKey must be of format xxxx-xxxx-xxxx-xxxx.", product);
        }

        [TestMethod]
        public void TestProductName_Prefix()
        {
            var product = ValidProduct();
            product.ProductName = "Engine";
            AssertValidation("The field ProductName is invalid.", product);
        }

        [TestMethod]
        public void TestManufactureYearIsFirstFourDigitsOfProductKey()
        {
            var product = ValidProduct();
            product.ManufactureYear = 2015;
            AssertValidation("The field Product is invalid.", product);
        }

        private Product ValidProduct()
        {
            return new Product() {
                ProductKey = "2016-0000-0000-0000",
                ManufactureYear = 2016,
                ProductName = "AA-Engine"
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
