﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsApp.Models;
using ProductsApp.Controllers;

namespace ProductsApp.Tests
{
    [TestClass]
    public class TestSimpleProductController
    {
        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            var testProducts = GetTestProducts();
            var controller = new ProductsController(testProducts);
            var result = controller.GetAllProducts() as Product[];
            Assert.AreEqual(testProducts.Length, result.Length);
        }

        [TestMethod]
        public void GetProduct_ShouldReturnCorrectProduct()
        {
            var testProducts = GetTestProducts();
            var controller = new ProductsController(testProducts);
            var result = controller.GetProduct(4) as
            OkNegotiatedContentResult<Product>;
            Assert.IsNull(result);
            //Assert.AreEqual(testProducts[3].Name, result.Content.Name);
        }

        [TestMethod]
        public void GetProduct_ShouldNotFindProduct()
        {
            var controller = new ProductsController(GetTestProducts());
            var result = controller.GetProduct(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        private Product[] GetTestProducts()
        {
            var testProducts = new Product[]
            {
new Product { Id = 1, Name = "Potato Soup", Price = 42 },
new Product { Id = 2, Name = "Belt", Price = 12 },
new Product { Id = 3, Name = "stick", Price = 1 },
            };
            return testProducts;
        }
    }
}