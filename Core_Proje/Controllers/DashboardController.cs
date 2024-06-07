using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v2 = "İstatistikler";
            ViewBag.v3 = "İstatistikler Listesi";
            return View();
        }
    }
}
