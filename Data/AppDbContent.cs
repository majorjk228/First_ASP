using First_ASP.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace First_ASP.Data
{
    public class AppDbContent : DbContext
    {
        public DbSet<User> Users { get; set; } = null!; //Свойство DbSet представляет собой коллекцию объектов, (Сама Таблица Users)
                                                        //которая сопоставляется с определенной таблицей в базе данных. То есть свойство Users будет представлять таблицу, в которой будут храниться объекты User.
        public AppDbContent(DbContextOptions<AppDbContent> options) : base(options) // Для взаимодействия с базой данных через Entity Framework Core
                                                                                    // необходим контекст данных - класс, унаследованный от класса Microsoft.EntityFrameworkCore.DbContext. Поэтому добавим в проект новый класс, который назовем AppDbContent
        {
            Database.EnsureCreated(); // создаем базу данных при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // в базу данных добавляются три начальных объекта
        {
            modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Tom", LastName = "Petrov", Age = 37 },
            new User { Id = 2, Name = "Bob", LastName = "Ivanov", Age = 41 },
            new User { Id = 3, Name = "Sam", LastName = "Sidorov", Age = 24 }
            );
        }

    }
}
