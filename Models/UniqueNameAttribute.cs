using System.ComponentModel.DataAnnotations;

namespace Task_2ITI.Models
{
    public class UniqueNameAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var dbcontext = new ApplicationDbContext();
            if (value.ToString() is null)
                return new ValidationResult("The Name Should not be null");

            else if (dbcontext.Courses.Any(crs => crs.Name == value.ToString()))
            {
                return new ValidationResult("The Name Should be Unique");
            }
            else
                return ValidationResult.Success;
        }
    }
}
