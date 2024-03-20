using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Task_2ITI.Models
{
    public class Course
    {
        public int Id { get; set;}
        [Required(ErrorMessage ="This field is required")]
        [MaxLength(20,ErrorMessage = "The number of characters should be less than 20 chrs.")]
        [MinLength(3,ErrorMessage ="The number of characters should be at least more than 3 chrs. ")]
      // [UniqueName]
        public string Name { get; set; }
        [Required]
        [Range(minimum:50,maximum:100,ErrorMessage ="The degree should be between 50 : 100 ")]
        public int Degree { get; set; }

        [Remote(action: "CheckMinimumDegree", controller:"Course",ErrorMessage ="The minimum degree should be less than degree",AdditionalFields ="Degree")]
        public int MinDegree { get; set; }

        [ValidateNever]
        public List<Instructor> Instructors { get; set; } = new();
        [ValidateNever]
        public Department Department { get; set; }
        public int DepId { get; set; }
        [ValidateNever]
      //  public List<CoursesResult> CoursesResults { get; set; } = new();
        
        public ICollection<Trainee> Trainees { get; set; } 
    }
}
