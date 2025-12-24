using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Message()
        {
            return View();
        }
    }
}
