using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager aboutManager = new (new EfServiceDal());

        public IActionResult Index()
        {
			ViewBag.v1 = "Hizmet Listesi";
			ViewBag.v2 = "Hizmetler";
			ViewBag.v3 = "Hizmet Listesi";
			var values = aboutManager.TGetList();
            return View(values);
        }

     
    }
}
