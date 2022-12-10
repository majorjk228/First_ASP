using System.ComponentModel.DataAnnotations;

namespace First_ASP.Domains.Entities
{
    public class ServiceItem : EntityBase
    {
        [Required(ErrorMessage = "Заполните название услуги")]
        [Display(Name = "Название услуги")]
        #pragma warning disable CS8618 // Поле, не допускающее значения NULL
        public override string Title { get; set; }
        #pragma warning restore CS8618 // Поле, не допускающее значения NULL

        [Display(Name = "Краткое описание услуги")]
        public override string? Subtitle { get; set; }

        [Display(Name = "Полное описание услуги")]
        public override string? Text { get; set; }
    }
}
