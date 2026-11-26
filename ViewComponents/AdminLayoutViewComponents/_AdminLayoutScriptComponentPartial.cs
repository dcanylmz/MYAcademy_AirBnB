using Microsoft.AspNetCore.Mvc;

namespace MYAcademy_AirBnB.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
