using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System.Diagnostics;

namespace Project.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
      
        public IActionResult Index()
        {
            ViewBag.ShowLoginButton = true; // Set ViewBag to indicate that the login button should be shown on the index page
            ViewBag.ShowSignupButton = true; // Set ViewBag to indicate that the login button should be shown on the index page
            
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult GetSessionValue()
        {
            var sessionValue = HttpContext.Session.GetString("LoggedInUserName");
            Console.WriteLine(sessionValue);
            return Json(sessionValue);
        }

    }
}