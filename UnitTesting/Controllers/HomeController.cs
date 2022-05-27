using Microsoft.AspNetCore.Mvc;
using UnitTesting.Models;
using System.Linq;

namespace UnitTesting.Controllers
{
    public class HomeController : Controller
    {
        public  IRepository repository = SimpleRepository.simpleRepository;
        public IActionResult Index() => View(repository.Products);
        
        [HttpGet]
        public IActionResult AddProduct() => View(new Product());

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            repository.AddProduct(p);
            return RedirectToAction("Index");
        }
    }
}

