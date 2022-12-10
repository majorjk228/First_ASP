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
// ���������� ������ �� appsettings
builder.Configuration.Bind("Project", new Config());

//���������� ������ ���������� ���������� � �������� ��������
builder.Services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>(); // ��������� ��� ��������� � ���������� ����������� �������
builder.Services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
builder.Services.AddTransient<DataManager>();

// �������� ������ ����������� �� ����� ������������ 
var connectionString = Config.ConnectionString;
// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

//����������� identity �������
builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
{
    opts.User.RequireUniqueEmail = true;    // ������������ ����� (����. ������)
    opts.Password.RequiredLength = 6;       // ��� ����� ������
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();//.AddRoles<IdentityRole>(); // ��������� �� ��� ������������ ���������, ������������ ����.

//����������� authentication cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "myCompanyAuth"; // ������� ����
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login"; // ����������� ������������ (���� �����������) �������� ���� ����� � ������ ������
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
});

// ��� ������������
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// ������������� ���� ��� ������������
//builder.Logging.AddFilter(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));

//����������� �������� ����������� ��� Admin area
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
});

// ��������� ��������� ������������ � ������������� (MVC)
builder.Services.AddControllersWithViews(x =>
{
    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
});

var app = builder.Build();
// � �������� ���������� ��� ����� ������ ��������� ���������� �� �������
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// ����������� �����
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDefaultFiles();

// ������� ������������� 
app.UseRouting();

//���������� �������������� � �����������
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

// ������������ ������ ��������
app.MapControllerRoute(
    name: "admin", 
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
   name: "default",
   pattern: "{controller=Home}/{action=Index}/{id?}");

app.Logger.LogInformation("Adding Routes"); // ������ �������� ��� ���� � �������

/*app.Run(async (context) => // ������ ����
{
    app.Logger.LogInformation($"Path: {context.Request.Path}  Time:{DateTime.Now.ToLongTimeString()}");
    await context.Response.WriteAsync("Hello World!");
});*/

app.Run();
