using Microsoft.AspNetCore.Mvc;

namespace Task_2ITI.Controllers
{
    public class DayController : Controller
    {
        public IActionResult SetCookies()
        {
            HttpContext.Response.Cookies.Append("Name", "Alllllli");
            return Content("Hello From Set Cookies");
        }
        public IActionResult getCookies()
        {
            string Name;
            Name = Request.Cookies["Name"];
            return Content($"Hello from Cookies {Name}");
        }
        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("Name", "Eyad");
            return Content("Hello from  Set session ");
        }
        public IActionResult GetSession()
        {
            string name;
            name=HttpContext.Session.GetString("Name");
            return Content($"Hello from get Session {name} ");
        }
        public IActionResult Index()
        {
            TempData["Name"] = "Eyad";
            TempData["Age"] = 23;
            return Content("Hello from Set TempData");
        }
        public IActionResult About()
        {
            string username="Empty";
            int age;
            if(TempData.ContainsKey("Name"))
            {
                username = TempData["Name"].ToString();
            }
            if(TempData.ContainsKey("Age"))
            {
                age = int.Parse(TempData["Age"].ToString());
            }
            return Content("Hello From Get the Temp Data "+username);
        }
        public IActionResult AboutPeek()
        {
            string Name;
            Name = TempData.Peek("Name").ToString();
            return Content("Hello From Peek " + Name);
        }
    }
}
