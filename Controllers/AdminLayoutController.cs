using Microsoft.AspNetCore.Mvc;

namespace MYAcademy_AirBnB.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
