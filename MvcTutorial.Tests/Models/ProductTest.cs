using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTutorial.Models;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace MvcTutorial.Tests.Models
{
    [TestClass]
    public class ProductTest
    {
        private MvcTutorialContext db = new MvcTutorialContext();

        [TestInitialize]
        public void InitDb()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<MvcTutorialContext>());
            db.Database.ExecuteSqlCommand("DELETE FROM ProductReviews");
            db.Database.ExecuteSqlCommand("DELETE FROM Products");
        }

        [TestMethod]
        public void TestCreateProductReviewThroughProduct()
        {
            var product = new Product()
            {
                Name = "Apple",
                PriceInCents = 1000,
                Reviews = new List<ProductReview>()
            };
            var review = new ProductReview()
            {
                Content = "Too expensive",
            };
            product.Reviews.Add(review);
            var db = new MvcTutorialContext();
            db.Products.Add(product);
            db.SaveChanges();

            var productReload = db.Products.Find(product.Id);
            Assert.AreEqual(1, productReload.Reviews.Count);
            Assert.AreEqual("Too expensive", productReload.Reviews.First().Content);
        }
    }
}
