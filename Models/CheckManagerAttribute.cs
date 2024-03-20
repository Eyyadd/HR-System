using System.ComponentModel.DataAnnotations;

namespace Task_2ITI.Models
{
    public class CheckManagerAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var dbcontext = new ApplicationDbContext();
            if (value?.ToString() is null)
                return new ValidationResult("The Name cant be null");
            else if (dbcontext.Instructors.Any(ins => ins.Name == value.ToString()))
            {
                return ValidationResult.Success;
            }
            else
                return new ValidationResult("The Manager should be one of the instructors");
           
        }
    }
}
