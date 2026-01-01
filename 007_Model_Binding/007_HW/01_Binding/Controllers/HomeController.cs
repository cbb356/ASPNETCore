using System.Diagnostics;
using Binding.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_Binding.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(BindingModel model)
        {
            Console.WriteLine("First = " + model.First);
            Console.WriteLine("Second = " + model.Second);
            Console.WriteLine("Count = " + model.Count);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
