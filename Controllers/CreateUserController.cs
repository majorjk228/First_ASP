using First_ASP.Domains;
using First_ASP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace First_ASP.Controllers
{
    public class CreateUserController : Controller
    {
        private readonly AppDbContext db; // Для взаимодействия с базой данных 
        private readonly UserManager<IdentityUser> _userManager; // Работаем с пользователем

        public CreateUserController(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            db = context;
            _userManager = userManager;
        }
        //[HttpGet("defUSER")] // Пример Только обычный пользователь может сюда зайти
        //[Authorize(RoleValidator<CreateUser>)]
        [HttpGet]
        public IActionResult Index()
        {
            return View("Indexnew");
        }
        public async Task<IActionResult> Users()
        {
            return View(await db.Users.ToListAsync()); // Выводим все из таблицы
        }
        [HttpPost]
        public async Task<IActionResult> Check(CreateUser user) 
        {
            if (ModelState.IsValid)
            {
                db.CreateUsers.Add(user);          // Добавляем
                await db.SaveChangesAsync();       // Сохраняем

                return Redirect("/");
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Checks(IdentityUser user) 
        { 
            if (ModelState.IsValid)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                await _userManager.CreateAsync(user);
                await _userManager.AddToRoleAsync(user, "user"); // присваемваем юзеру роль по дефолту

                return Redirect("/");
            }

            return View("Index");
        }
    }
}
