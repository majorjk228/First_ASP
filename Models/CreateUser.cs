using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security;

namespace First_ASP.Models
{
    public class CreateUser
    {
        #pragma warning disable CS8618 // Поле, не допускающее значения NULL
        public int Id { get; set; }   // Id
        public Guid Guid { get; set; }  // Guid

        [Display(Name = "Введите Имя")]
        [Required (ErrorMessage = "Нужно ввести имя")]
        [MinLength(3, ErrorMessage = "Нужно ввести не меньше 3 символов")]
        public string Name { get; set; } 

        [Display(Name = "Введите Фамилию")]
        [Required]
        [MinLength(3, ErrorMessage = "Нужно ввести не меньше 3 символов")]
        public string LastName { get; set; }

        [Display(Name = "Введите Возраст")]
        [Required(ErrorMessage = "Не указан возраст")]
        [Range(1, 110, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }
        #pragma warning restore CS8618 // Поле, не допускающее значения NULL

        //[Wrong("STAR", ErrorMessage = "Вы должны быть с ОДК-СТАР")]
        public string? CompanyName { get; set; }

    }
}
/*Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty*/