using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]

        {
            new Product { Id = 1, Name = "Potato Soup", Category = "Schmoceries", Price = 42 },
            new Product { Id = 2, Name = "Belt", Category = "clodes", Price = 12 },
            new Product { Id = 3, Name = "stick", Category = "Hadware", Price = 1 }
        };
        public ProductsController()
        {
        }
        public ProductsController(Product[] products)
        {
            this.products = products;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}