using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace First_ASP.Models
{
    public class WrongAttribute : ValidationAttribute // Класс реализует собсвтенный атрибут который Должен соблюдаться. Используется в форме заполнения
                                                      // быть только определенный атрибут город Пермь
    {
        private const string City = "Perm";

        public WrongAttribute(string name) { }

        public override bool IsValid(object? value)
        {
            var nameCity = value.ToString();
            if (nameCity == City && value != null)
            {
                return true;
            } 
            return false;
        }
    }
}
