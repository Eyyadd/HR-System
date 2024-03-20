using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Task_2ITI.Models
{
    public class Trainee
    {
        [Key]
        public  int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(20, ErrorMessage = "The number of characters should be less than 20 chrs.")]
        [MinLength(3, ErrorMessage = "The number of characters should be at least more than 3 chrs. ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"\w+\.(jpg|png)", ErrorMessage = "The Extension should be in jpg or png format")]
        public string? Image { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Grade { get; set; }

        [ValidateNever]
        public Department Department { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [Display(Name="Department")]
        public int DepID { get; set; }

        //[ValidateNever]
        //public List<CoursesResult> CourseResults { get; set; }

        [ValidateNever]
        public ICollection<Course> Courses { get; set; }
    }
}
