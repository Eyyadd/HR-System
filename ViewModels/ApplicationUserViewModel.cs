using System.ComponentModel.DataAnnotations;

namespace Task_2ITI.ViewModels
{
    public class ApplicationUserViewModel
    {
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]

        public int Phone { get; set; }
    }
}
