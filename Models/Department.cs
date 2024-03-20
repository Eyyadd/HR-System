using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Task_2ITI.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(20, ErrorMessage = "The number of characters should be less than 20 chrs.")]
        [MinLength(3, ErrorMessage = "The number of characters should be at least more than 3 chrs. ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(20, ErrorMessage = "The number of characters should be less than 20 chrs.")]
        [MinLength(3, ErrorMessage = "The number of characters should be at least more than 3 chrs. ")]
        [CheckManager]
        public string Manager { get; set; }

        [ValidateNever]
        public List<Instructor> Instructors { get; set; }
        [ValidateNever]
        public List<Trainee> Trainees { get; set; }
        [ValidateNever]
        public List<Course> Courses { get; set; }
    }
}
