using Microsoft.AspNetCore.Mvc;

namespace MYAcademy_AirBnB.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
