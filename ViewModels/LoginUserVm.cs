using System.ComponentModel.DataAnnotations;

namespace Task_2ITI.ViewModels
{
    public class LoginUserVm
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
