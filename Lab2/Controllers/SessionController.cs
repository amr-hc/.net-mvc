using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult setsession()
        {
            HttpContext.Session.SetString("Name", "Amr");
            HttpContext.Session.SetInt32("age", 26);

            return Content("Session Saved!");
        }

        public IActionResult getsession()
        {
            string name = HttpContext.Session.GetString("Name");
            int? age = HttpContext.Session.GetInt32("age");

            return Content($"Your Name is {name} and age is {age}");
        }


        public IActionResult setcookie()
        {
            HttpContext.Response.Cookies.Append("name", "Ahmed");
            HttpContext.Response.Cookies.Append("age", "25");

            return Content("Cookies Saved!");
        }

        public IActionResult getcookie()
        {
            string name = HttpContext.Request.Cookies["Name"];
            string age = HttpContext.Request.Cookies["age"];

            return Content($"Your Name is {name} and age is {age}");
        }
    }
}
