using First_ASP.Domains;
using First_ASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace First_ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly DataManager dataManager; // Для того, чтобы иметь доступ к базе данных

        public HomeController(ILogger<HomeController> logger, DataManager dataManager)
        {
            _logger = logger;
            this.dataManager = dataManager;
        }
        /* public void OnGet()
         {
             _logger.LogInformation("About page visited at {DT}",
                 DateTime.UtcNow.ToLongTimeString());
         }*/
        public IActionResult Index()
        {
            _logger.LogInformation($"Мы перешли в контроллер Home. Time:{DateTime.Now.ToLongTimeString()}"); // Запись в лог
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageIndex"));   // Возвращаем представление, в качестве модели передает название из БД(Из AppDBContext)
        }

        public IActionResult Contacts()
        {
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageContacts")); // Возвращаем представление, в качестве модели передает название из БД(Из AppDBContext)
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}