using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using First_ASP.Domains.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using First_ASP.Models;

namespace First_ASP.Domains
{
    public class AppDbContext : IdentityDbContext<IdentityUser> // IdentityDbContext необходимо для операцияий(идентификации) с пользователями.
                                                                // К примеру личный кабинет можно прописывать свои свйоства
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            //Database.EnsureCreated(); // создаем базу данных при первом обращении
        }

        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }
        public DbSet<CreateUser> CreateUsers { get; set; } = null!; //Свойство DbSet представляет собой коллекцию объектов, (Сама Таблица Users)

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole // Создаем роли
            {
                Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                Name = "Admin",
                NormalizedName = "ADMIN"
            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole // Создаем роли
            {
                Id = "c46bbbae-3c45-438e-9ee9-594306aeb8f0",
                Name = "User",
                NormalizedName = "USER"
            });

            #pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });
            
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "eac74484-b5ab-4acc-a36c-17a27cf417c8",
                UserName = "Alex",
                NormalizedUserName = "defUSER",
                Email = "my1@email.com",
                NormalizedEmail = "MY1@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "123"),
                SecurityStamp = string.Empty
            });
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "eac74484-b5ab-4acc-a36c-17a27cf418c8",
                UserName = "Alex2",
                NormalizedUserName = "defUSER2",
                Email = "my12@email.com",
                NormalizedEmail = "MY12@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "123"),
                SecurityStamp = string.Empty
            });
            #pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> // Привязываем юзера к роли
            {
                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab", // Admin
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "c46bbbae-3c45-438e-9ee9-594306aeb8f0", // DefaultUser
                UserId = "eac74484-b5ab-4acc-a36c-17a27cf417c8",
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "c46bbbae-3c45-438e-9ee9-594306aeb8f0", // DefaultUser
                UserId = "eac74484-b5ab-4acc-a36c-17a27cf418c8",
            });
            // новый вариант
            modelBuilder.Entity<TextField>().HasData(
                new TextField { Id = new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"), CodeWord = "PageIndex", Title = "Главная" },
                new TextField { Id = new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"), CodeWord = "PageServices", Title = "Наши услуги" },
                new TextField { Id = new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"), CodeWord = "PageContacts", Title = "Контакты" }
            );
            // Старый вариант
            /*            modelBuilder.Entity<TextField>().HasData(new TextField
                        {
                            Id = new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                            CodeWord = "PageIndex",
                            Title = "Главная"
                        });
                        modelBuilder.Entity<TextField>().HasData(new TextField
                        {
                            Id = new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                            CodeWord = "PageServices",
                            Title = "Наши услуги"
                        });
                        modelBuilder.Entity<TextField>().HasData(new TextField
                        {
                            Id = new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                            CodeWord = "PageContacts",
                            Title = "Контакты"
                        });
            */
        }
    }
}
