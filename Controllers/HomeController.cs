using First_ASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace First_ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        /* public void OnGet()
         {
             _logger.LogInformation("About page visited at {DT}",
                 DateTime.UtcNow.ToLongTimeString());
         }*/
        public IActionResult Index()
        {
            _logger.LogInformation($"Мы перешли в контроллер Home. Time:{DateTime.Now.ToLongTimeString()}"); // Запись в лог
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}