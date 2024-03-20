using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Task_2ITI.Models;
using Task_2ITI.ViewModels;

namespace Task_2ITI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public AccountController(UserManager<ApplicationUser> _UserManager,SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _UserManager;
            signInManager = _signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ApplicationUserViewModel NewUser)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser usermodel = new ApplicationUser();
                usermodel.UserName = NewUser.UserName;
                usermodel.PasswordHash = NewUser.Password;
                usermodel.Email = NewUser.Email;
                usermodel.Address = NewUser.Address;

                IdentityResult result = await userManager.CreateAsync(usermodel,NewUser.Password);
                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(usermodel, false);
                    return RedirectToAction("Index", "Instructor");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(NewUser);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserVm LoggedUser)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser usermodel = await userManager.FindByNameAsync(LoggedUser.UserName);
                if(usermodel is not null)
                {
                    bool found = await userManager.CheckPasswordAsync(usermodel, LoggedUser.Password);
                    if(found)
                    {
                        //List<Claim> claims = new();
                        //claims.Add(new Claim("Address", usermodel.Address));
                        //signInManager.SignInWithClaimsAsync(usermodel, false,claims );
                        await signInManager.SignInAsync(usermodel, LoggedUser.RememberMe);
                        return RedirectToAction("Index", "Instructor");
                    }
                }
                ModelState.AddModelError("", "User Name or Password invalid");
            }
            return View(LoggedUser);
        }
        [HttpGet]
        public async  Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
