using First_ASP.Domain.Repositories.Abstract;
using First_ASP.Domain.Repositories.EntityFramework;
using First_ASP.Domains;
using First_ASP.Models;
using First_ASP.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// подключаем конфиг из appsettings
builder.Configuration.Bind("Project", new Config());

//подключаем нужный функционал приложения в качестве сервисов
builder.Services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>(); // Связываем наш интерфейс с конкретной реализацией проекта
builder.Services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
builder.Services.AddTransient<DataManager>();

// получаем строку подключения из файла конфигурации 
var connectionString = Config.ConnectionString;
// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

//настраиваем identity систему
builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
{
    opts.User.RequireUniqueEmail = true;    // обязательный емаил (потв. емаила)
    opts.Password.RequiredLength = 6;       // мин длина пароля
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();//.AddRoles<IdentityRole>(); // Добавляем ЕФ Кор использовать хранилище, использовать роли.

//настраиваем authentication cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "myCompanyAuth"; // Нзвание куки
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login"; // авторизация пользователя (путь контроллера) например чтоб войти в панель админа
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
});

// для логгирования
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// устанавливаем файл для логгирования
//builder.Logging.AddFilter(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));

//настраиваем политику авторизации для Admin area
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
});

// добавляем поддержку котнроллеров и представлений (MVC)
builder.Services.AddControllersWithViews(x =>
{
    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
});

var app = builder.Build();
// в процессе разработки нам важно видеть подробную информацию об ошибках
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// статические файлы
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDefaultFiles();

// система маршрутизации 
app.UseRouting();

//подключаем аутентификацию и авторизацию
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

// регистрируем нужные маршруты
app.MapControllerRoute(
    name: "admin", 
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
   name: "default",
   pattern: "{controller=Home}/{action=Index}/{id?}");

app.Logger.LogInformation("Adding Routes"); // Строка тестовая для лога в консоль

/*app.Run(async (context) => // Пример лога
{
    app.Logger.LogInformation($"Path: {context.Request.Path}  Time:{DateTime.Now.ToLongTimeString()}");
    await context.Response.WriteAsync("Hello World!");
});*/

app.Run();
