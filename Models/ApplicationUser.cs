using Microsoft.AspNetCore.Identity;

namespace Task_2ITI.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }
    }
}
