using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace First_ASP.Models
{
    public class CreateIdentityUser : IdentityUser
    {
        #pragma warning disable CS8618 // Поле, не допускающее значения NULL
        [Display(Name = "Введите Имя")]
        [Required(ErrorMessage = "Нужно ввести имя")]
        [MinLength(3, ErrorMessage = "Нужно ввести не меньше 3 символов")]
        public override string UserName { get; set; }

        #pragma warning restore CS8618 // Поле, не допускающее значения NULL

        [Required]
        public override string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public override string? PasswordHash { get; set; }
        
        public string? Role { get; set; }
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