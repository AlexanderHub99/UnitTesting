using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UnitTesting.Controllers;
using UnitTesting.Models;
using Xunit;

namespace UnitTesting.Test
{
    public class HomeControllerTests
    {
        public class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Product> Products { get; set;  }
            public void AddProduct(Product p){}
        }
        
        [Theory]
        [InlineData(275,84.98,54.2,78.6)]
        [InlineData(235,14.18,94.32,48.6)]
        public void IndexActionModelIsComplete(decimal price1,decimal price2,decimal price3,decimal price4)
        {
            HomeController controller = new HomeController();
            controller.repository = new ModelCompleteFakeRepository
            {
                Products = new Product[]
                {
                    new Product {Name = "Sasha", Price = price1},
                    new Product {Name = "Canonade", Price = price2},
                    new Product {Name = "Diffraction", Price = price3},
                    new Product {Name = "Dog", Price = price4},
                }
            };
    
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
    
            Assert.Equal(controller.repository.Products, model, Comparer.Get<Product>((p1, p2)
                => p1.Name == p2.Name && p1.Price == p2.Price));
        }
       
    }
}

