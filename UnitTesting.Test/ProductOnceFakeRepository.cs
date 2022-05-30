using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UnitTesting.Controllers;
using UnitTesting.Models;
using Xunit;

namespace UnitTesting.Test
{
    public class ProductOnceFakeRepository: IRepository

    {
        public int ProductCounter { get; set; } = 0;

        public IEnumerable<Product> Products
        {
            get
            {
                ProductCounter++;
                return new[]
                {
                    new Product
                    {
                        Name = "P1", Price = 100
                    }
                };
            }
        }
        public void AddProduct(Product p) { }

        [Fact]
        public void RepositoryProductCalledOne()
        {
            var repo = new ProductOnceFakeRepository();
            var controller = new HomeController() {repository = repo};

            var result = controller.Index();
            
            Assert.Equal(1,repo.ProductCounter);
        }
    }
}

