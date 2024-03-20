using Microsoft.AspNetCore.Identity;

namespace Task_2ITI.Application
{
    public class ApplicationUser:IdentityUser<int>
    {
        public string Address { get; set; }
    }
}
