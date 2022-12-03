using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using First_ASP.Domains;
using First_ASP.Domains.Entities;
using First_ASP.Domain.Repositories.Abstract;

namespace First_ASP.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository : ITextFieldsRepository
    {
        private readonly AppDbContext context;
        public EFTextFieldsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<TextField> GetTextFields()            // все записи из таблицы
        {
            return context.TextFields;
        }

        public TextField GetTextFieldById(Guid id)              // первая запись из таблицы
        {
            return context.TextFields.FirstOrDefault(x => x.Id == id);
        }

        public TextField GetTextFieldByCodeWord(string codeWord) // по ключевому полю из таблицы
        {
            return context.TextFields.FirstOrDefault(x => x.CodeWord == codeWord);
        }

        public void SaveTextField(TextField entity)                // Сохраняем
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;   // Если идентификатора нет, то он его добавит
            else
                context.Entry(entity).State = EntityState.Modified; // Если уже был, обозначем флагом изменен
            context.SaveChanges();                                  // Сохраняем
        }

        public void DeleteTextField(Guid id)                        // Удаляем текстовое поля из БД
        {
            context.TextFields.Remove(new TextField() { Id = id }); // необходим идентификатор
            context.SaveChanges();
        }
    }
}
