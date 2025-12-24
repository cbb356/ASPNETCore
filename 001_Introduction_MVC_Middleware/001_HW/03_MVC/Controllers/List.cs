using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class ListController : Controller
    {
        public IActionResult Info()
        {
            return View();
        }
    }
}
