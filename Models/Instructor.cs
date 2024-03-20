using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_2ITI.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(20, ErrorMessage = "The number of characters should be less than 20 chrs.")]
        [MinLength(3, ErrorMessage = "The number of characters should be at least more than 3 chrs. ")]
        public string Name { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="The Extension should be in jpg or png format")]
        public string Image { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [Range(minimum:3000,maximum:50000,ErrorMessage ="The salary should be between 3000 to 50000 (3K : 50K)")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Remote(action:"CheckCity",controller:"Instructor",ErrorMessage ="The City should be Cairo Only")]
        public string Address { get; set; }

        [ValidateNever]
        public Department Department { get; set; }

        [Display(Name="Department")]
        public int DepID { get; set; }

        [ValidateNever]
        public Course Course { get; set; }

        [Display(Name ="Course")]
        public int CourseId { get; set; }

    }
}
