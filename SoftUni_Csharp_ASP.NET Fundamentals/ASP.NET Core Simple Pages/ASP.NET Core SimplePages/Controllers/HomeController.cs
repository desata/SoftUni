using ASP.NET_Core_SimplePages.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.NET_Core_SimplePages.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Hello World!";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "This is an ASP.NET Core MVC app.";
            return View();
        }

        [Route("/Numbers")]
        public IActionResult Numbers()
        {
            return View();
        }  
        
        [Route("/NumbersToN")]
        public IActionResult NumbersToN(int number = 3)
        {
            ViewBag.Number = number;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}