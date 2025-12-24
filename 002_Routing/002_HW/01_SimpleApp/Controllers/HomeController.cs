using Microsoft.AspNetCore.Mvc;

namespace SimpleApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Download()
        {
            FileStream fileStream = System.IO.File.OpenRead("App_Data/001_Introduction.pdf");
            return File(fileStream, "application/pdf", "001_Introduction.pdf");
        }
    }
}
