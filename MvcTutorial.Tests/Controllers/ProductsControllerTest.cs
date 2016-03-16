using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTutorial;
using MvcTutorial.Controllers;
using MvcTutorial.Models;
using System.Data.Entity;
using System.Net;

namespace MvcTutorial.Tests.Controllers
{
    [TestClass]
    public class ProductsControllerTest
    {
        private MvcTutorialContext db         = new MvcTutorialContext();
        private ProductsController controller = new ProductsController();

        [TestInitialize]
        public void InitDb()
        {
            db.Database.ExecuteSqlCommand("DELETE FROM Products");
        }

        [TestMethod]
        public void Index()
        {
            var product = new Product() {Name = "Apple", PriceInCents = 1000};
            db.Products.Add(product);
            db.SaveChanges();

            ViewResult result = controller.Index() as ViewResult;

            var products = result.Model as List<Product>;
            Assert.AreEqual(1,       products.Count());
            Assert.AreEqual("Apple", products.First().Name);
            Assert.AreEqual(1000,    products.First().PriceInCents);
        }

        [TestMethod]
        public void Details()
        {
            var product = new Product() { Name = "Apple", PriceInCents = 1000 };
            db.Products.Add(product);
            db.SaveChanges();

            ViewResult result = controller.Details(product.Id) as ViewResult;

            var p = result.Model as Product;
            Assert.AreEqual("Apple", p.Name);
            Assert.AreEqual(1000,    p.PriceInCents);
        }

        [TestMethod]
        public void DetailsIdNull()
        {
            var result = controller.Details(null) as HttpStatusCodeResult;
            Assert.AreEqual((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void DetailsIdNotFound()
        {
            var result = controller.Details(0) as HttpStatusCodeResult;
            Assert.AreEqual((int)HttpStatusCode.NotFound, result.StatusCode);
        }

        [TestMethod]
        public void Create()
        {
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreatePost()
        {
            var product = new Product() { Name = "Orange", PriceInCents = 1100 };

            var result = controller.Create(product) as RedirectToRouteResult;

            Assert.AreEqual("Index", result.RouteValues["Action"]);
            var p = db.Products.ToArray().Last();
            Assert.IsTrue(p.Id > 0);
            Assert.AreEqual("Orange", p.Name);
            Assert.AreEqual(1100,    p.PriceInCents);
        }

        [TestMethod]
        public void Edit()
        {
            var product = new Product() { Name = "Orange", PriceInCents = 1100 };
            controller.Create(product);

            var result = controller.Edit(product.Id) as ViewResult;

            Assert.AreEqual(result.ViewData.Model, product);
        }

        [TestMethod]
        public void EditIdNull()
        {
            var result = controller.Edit((int?)null) as HttpStatusCodeResult;
            Assert.AreEqual((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void EditIdNotFound()
        {
            var result = controller.Edit(0) as HttpStatusCodeResult;
            Assert.AreEqual((int)HttpStatusCode.NotFound, result.StatusCode);
        }

        [TestMethod]
        public void EditPost()
        {
            var product = new Product() { Name = "Orange", PriceInCents = 1100 };
            controller.Create(product);
            product.Name         = "Orange (Organic)";
            product.PriceInCents = 1200;
            var result = controller.Edit(product) as RedirectToRouteResult;

            Assert.AreEqual("Index", result.RouteValues["Action"]);

            var p = db.Products.Find(product.Id);
            Assert.AreEqual(product.Name,         p.Name);
            Assert.AreEqual(product.PriceInCents, p.PriceInCents);
        }

        [TestMethod]
        public void Delete()
        {
            var product = new Product() { Name = "Orange", PriceInCents = 1100 };
            controller.Create(product);

            var result = controller.Delete(product.Id) as ViewResult;

            Assert.AreEqual(result.ViewData.Model, product);
        }

        [TestMethod]
        public void DeleteIdNull()
        {
            var result = controller.Delete(null) as HttpStatusCodeResult;
            Assert.AreEqual((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void DeleteIdNotFound()
        {
            var result = controller.Delete(0) as HttpStatusCodeResult;
            Assert.AreEqual((int)HttpStatusCode.NotFound, result.StatusCode);
        }

        [TestMethod]
        public void DeleteConfirmed()
        {
            var product = new Product() { Name = "Orange", PriceInCents = 1100 };
            controller.Create(product);

            var result = controller.DeleteConfirmed(product.Id) as RedirectToRouteResult;

            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.IsNull(db.Products.Find(product.Id));
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void DeleteConfirmedIdNotFound()
        {
            controller.DeleteConfirmed(0);
        }
    }
}
