using First_ASP.Domains;
using Microsoft.AspNetCore.Mvc;

namespace First_ASP.Models.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly DataManager dataManager; // Подкл. БД

        public SidebarViewComponent(DataManager dataManager) // Принимаем запросы БД
        {
            this.dataManager = dataManager;
        }
        
        public Task<IViewComponentResult> InvokeAsync() //Invoke асинхронная версия
        {
            return Task.FromResult((IViewComponentResult)View("Default", dataManager.ServiceItems.GetServiceItems())); // Возвращаем представление. дефолт это по соглашению(по стандартам)
        }
    }
}
