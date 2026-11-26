using Microsoft.AspNetCore.Mvc;

namespace MYAcademy_AirBnB.ViewComponents.CategoryViewComponents
{
    public class _CreateCategoryStyleComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
