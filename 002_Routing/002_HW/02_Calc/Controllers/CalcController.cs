using Microsoft.AspNetCore.Mvc;

namespace Calc.Controllers
{
    public class CalcController : Controller
    {
        public IActionResult Add(int x, int y)
        {
            int result = x + y;
            return View("Result", result);
        }

        public IActionResult Sub(int x, int y)
        {
            int result = x - y;
            return View("Result", result);
        }

        public IActionResult Mul(int x, int y)
        {
            int result = x * y;
            return View("Result", result);
        }

        public IActionResult Div(int x, int y)
        {
            if (y == 0)
            {
                return View("Error", "Cannot divide by zero.");
            }
            
            double result = (double)x / y;
            return View("Result", result);
        }
    }
}
