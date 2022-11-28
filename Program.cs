using First_ASP.Data;
using First_ASP.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// получаем строку подключения из файла конфигурации
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
 // добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<AppDbContent>(options => options.UseSqlServer(connectionString));

//Для логгирования
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// устанавливаем файл для логгирования
builder.Logging.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDefaultFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Logger.LogInformation("Adding Routes");

/*app.Run(async (context) =>
{
    app.Logger.LogInformation($"Path: {context.Request.Path}  Time:{DateTime.Now.ToLongTimeString()}");
    await context.Response.WriteAsync("Hello World!");
});*/

app.Run();
