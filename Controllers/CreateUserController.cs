using First_ASP.Domains;
using First_ASP.Domains.Entities;
using First_ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace First_ASP.Controllers
{
    public class CreateUserController : Controller
    {
        private AppDbContext db; // Для взаимодействия с базой данных 
        public CreateUserController(AppDbContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Users()
        {
            return View(await db.Users.ToListAsync()); // Выводим все из таблицы
        }
        [HttpPost]
        public async Task<IActionResult> Check(User user)
        {
            if (ModelState.IsValid)
            {
                //db.Users.Add(user);          // Добавляем
                await db.SaveChangesAsync(); // Сохраняем

                return Redirect("/CreateUser/Users");
            }

            return View("Index");
        }
    }
}
