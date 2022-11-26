using First_ASP.Data;
using First_ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace First_ASP.Controllers
{
    public class CreateUserController : Controller
    {
        private AppDbContent db; // Для взаимодействия с базой данных 
        public CreateUserController(AppDbContent context)
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
            return View(await db.Users.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Check(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();

                return Redirect("/CreateUser/Users");
            }

            return View("Index");
        }
    }
}
