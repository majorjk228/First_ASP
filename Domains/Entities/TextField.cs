using System.ComponentModel.DataAnnotations;

namespace First_ASP.Domains.Entities
{
    public class TextField : EntityBase
    {
        [Required]
        public string? CodeWord { get; set; }

        [Display(Name = "Название (заголовок)")]
        public override string Title { get; set; } = "Информационная страница";

        [Display(Name = "Содержание страницы")]
        public override string Text { get; set; } = "Содержание заполняется администратором";
    }
}
