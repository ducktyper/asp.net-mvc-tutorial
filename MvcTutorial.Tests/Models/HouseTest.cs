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

        [TestMethod]
        public void TestRoad_Required()
        {
            var model = ValidHouse();
            model.Road = null;
            AssertValidation("The Road field is required.", model);
        }

        [TestMethod]
        public void TestRoad_StringLength()
        {
            var model = ValidHouse();
            model.Road = "aaaa aaaa aaaa aaaa rd";
            AssertValidation("The field Road must be a string with a maximum length of 10.", model);
        }

        [TestMethod]
        public void TestRoad_RegularExpression()
        {
            var model = ValidHouse();
            model.Road = "no road";
            AssertValidation("The field Road must match the regular expression '[1-9a-zA-Z- ]+ rd'.", model);
        }

        [TestMethod]
        public void TestRoad_MinLength()
        {
            var model = ValidHouse();
            model.Road = "a rd";
            AssertValidation("The field Road must be a string or array type with a minimum length of '5'.", model);
        }

        [TestMethod]
        public void TestPhoneNumber()
        {
            var model = ValidHouse();
            model.PhoneNumber = "invalid phone number";
            AssertValidation("The PhoneNumber field is not a valid phone number.", model);
        }

        [TestMethod]
        public void TestOwnerEmail()
        {
            var model = ValidHouse();
            model.OwnerEmail = "invalid email";
            AssertValidation("The OwnerEmail field is not a valid e-mail address.", model);
        }

        [TestMethod]
        public void TestOwnerCreditCard()
        {
            var model = ValidHouse();
            model.OwnerCreditCard = "invalid credit card";
            AssertValidation("The OwnerCreditCard field is not a valid credit card number.", model);
        }

        [TestMethod]
        public void TestConfirmOwnerCreditCard_Compare()
        {
            var model = ValidHouse();
            model.ConfirmOwnerCreditCard = "1111111111111111";
            AssertValidation("'ConfirmOwnerCreditCard' and 'OwnerCreditCard' do not match.", model);
        }

        private House ValidHouse()
        {
            return new House()
            {
                NumberOfRooms = 3,
                Road          = "1 Queen rd",
                PhoneNumber   = "+64-(0)9-111-1111",
                OwnerEmail    = "ducktyper@gmail.com",
                OwnerCreditCard = "0000000000000000",
                ConfirmOwnerCreditCard = "0000000000000000"
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
