using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new  ServiceManager(new EfServiceDal());

        public IActionResult Index()
        {
			ViewBag.v1 = "Hizmet Listesi";
			ViewBag.v2 = "Hizmetler";
			ViewBag.v3 = "Hizmet Listesi";
			var values = serviceManager.TGetList();
            return View(values);
        }
		[HttpGet]
		public ActionResult AddService()
		{
			ViewBag.v1 = "Hizmet Ekleme";
			ViewBag.v2 = "Hizmetler";
			ViewBag.v3 = "Hizmet Ekleme";

			return View();
		}
		[HttpPost]
		public ActionResult AddService(Service service)
		{
			serviceManager.TAdd(service);
			return RedirectToAction("Index");

		}
		public IActionResult DeleteService(int id)
		{
			var service = serviceManager.TGetByID(id);

			if (service == null)
			{
				return NotFound(); // Yeteneğin mevcut olmadığı durumu ele al
			}

			return View("DeleteConfirmation", service); // Onay görünümüne yönlendir
		}

		[HttpPost]
		public IActionResult DeleteServiceConfirmed(int id)
		{
			var service = serviceManager.TGetByID(id);

			if (service == null)
			{
				return NotFound(); // Becerinin mevcut olmadığı durumlarda durumu ele alın (açıklık sağlamak için gereksizdir)
			}

			serviceManager.TDelete(service);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult EditService(int id)
		{
			ViewBag.v1 = "Hizmet Listesi";
			ViewBag.v2 = "Hizmetler";
			ViewBag.v3 = "Hizmet Güncelleme Düzenleme";
			var values = serviceManager.TGetByID(id);
			return View(values);
		}
		[HttpPost]
		public ActionResult EditService(Service service)
		{
			serviceManager.TUpdate(service);
			return RedirectToAction("Index");
		}

	}
}
