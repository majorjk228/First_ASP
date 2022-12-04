using First_ASP.Domains;
using Microsoft.AspNetCore.Mvc;

namespace First_ASP.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ILogger<ServicesController> _logger;

        private readonly DataManager dataManager; // Для того, чтобы иметь доступ к базе данных

        public ServicesController(ILogger<ServicesController> logger, DataManager dataManager)
        {
            _logger = logger;
            this.dataManager = dataManager;
        }
        public IActionResult Index(Guid id)
        {
            _logger.LogInformation($"Мы перешли в контроллер Contacts. Time:{DateTime.Now.ToLongTimeString()}"); // Запись в лог

            if (id != default)
            {
                return View("Show", dataManager.ServiceItems.GetServiceItemById(id));
            }

            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageServices");
            return View(dataManager.ServiceItems.GetServiceItems());
        }
    }
}

