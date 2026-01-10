using FormsValidation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FormsValidation.Controllers
{
    public class ConsultationController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(ConsultationFormModel model)
        {
            if (model.Product == Course.Essential &&
                model.ConsultationDate.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError(nameof(model.Product),
                    "Consultations for 'Essential' cannot be scheduled on Mondays.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                Console.WriteLine($"Consultation created: FirstName: {model.FirstName}, " +
                    $"LastName: {model.LastName} Email: {model.Email}, " +
                    $"Date: {model.ConsultationDate}, Product: {model.Product})");
                return View("Success");
            }
        }
    }
}
