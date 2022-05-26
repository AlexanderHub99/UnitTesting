using Microsoft.AspNetCore.Mvc;
using UnitTesting.Models;
using System.Linq;

namespace UnitTesting.Controllers
{
    public class HomeController : Controller
    {
        private readonly SimpleRepository _repository = SimpleRepository.simpleRepository;
        public IActionResult Index() => View(_repository.Products.Where(p => p?.Price< 50));
        
        [HttpGet]
        public IActionResult AddProduct() => View(new Product());

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            _repository.AddProduct(p);
            return RedirectToAction("Index");
        }
    }
}

