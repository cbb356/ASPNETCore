using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FormsValidation.Models
{
    public class FutureWorkingDayAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (value is not DateOnly date)
            { 
                return new ValidationResult("Invalid date format.");
            }

            if (date <= DateOnly.FromDateTime(DateTime.Today))
            {
                return new ValidationResult("Date must be in the future.");
            }

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                return new ValidationResult("Date cannot be a weekend (Saturday or Sunday).");
            }

            return ValidationResult.Success;
        }
    }


    public class ConsultationFormModel
    {
        [Required(ErrorMessage = "The first name is incorrect. Try again")]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "The last name is incorrect. Try again")]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "The email is incorrect. Try again")]
        [EmailAddress(ErrorMessage = "Format of the email is incorrect. Try again")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "The date is incorrect. Pick the date")]
        [UIHint("Date")]
        [Display(Name = "Consultation Date")]
        [FutureWorkingDay(ErrorMessage = "Please select a future working day.")]
        public DateOnly ConsultationDate { get; set; }

        [Required(ErrorMessage = "The course is incorrect. Pick the date")]
        [Display(Name = "Product Name")]
        public Course Product { get; set; }
    }
        
    public enum Course
    {
        JavaScript,
        [Display(Name = "C#")]
        CSharp, 
        Java, 
        Python, 
        Essential
    }
}
