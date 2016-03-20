﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTutorial;
using MvcTutorial.Models;
using System.ComponentModel.DataAnnotations;
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
        public void TestNameRequired()
        {
            var model = new Product();
            AssertValidation("Name is required!", model);
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
