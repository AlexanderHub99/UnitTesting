using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UnitTesting.Controllers;
using UnitTesting.Models;
using Xunit;
using Moq;

namespace UnitTesting.Test
{
    public class HomeControllerTests
    {
        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete(Product[] products)
        {
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products)
                .Returns(products);

            var controller = new HomeController {repository = mock.Object};

            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            Assert.Equal(controller.repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name
                && p1.Price == p2.Price));
        }

        [Fact]
        public void RepositoryProductCalledOne()
        {
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products)
                .Returns(new[] {new Product {Name = "P1", Price = 100}});
            var controller = new HomeController {repository = mock.Object};

            var result = controller.Index();

            mock.VerifyGet(m => m.Products, Times.Once);
        }
    }
}