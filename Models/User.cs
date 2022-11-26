using System.ComponentModel.DataAnnotations;

namespace First_ASP.Models
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "Введите Имя")]
        [Required (ErrorMessage = "Нужно ввести имя")]
        [StringLength(3, ErrorMessage = "Имя не менее 3 символов")]
        public string Name { get; set; }

        [Display(Name = "Введите Фамилию")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Введите Возраст")]
        [Required]
        public int Age { get; set; }

    }
}
