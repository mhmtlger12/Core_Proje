using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Proje Listesi";
            ViewBag.v2 = "Projelerim";
            ViewBag.v3 = "Proje Listesi";
            var values= portfolioManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            ViewBag.v1 = "Proje Listesi";
            ViewBag.v2 = "Projelerim";
            ViewBag.v3 = "Proje Ekleme";
            portfolioManager.TAdd(portfolio);
           return RedirectToAction("Index");   
        }
        public IActionResult DeletePortfolio(int id)
        {
            var values = portfolioManager.TGetByID(id);
            portfolioManager.TDelete(values);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult EditPortfolio(int id)
        {
            ViewBag.v1 = "Proje Listesi";
            ViewBag.v2 = "Projelerim";
            ViewBag.v3 = "Proje Düzenleme";
            var values = portfolioManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult EditPortfolio(Portfolio portfolio)
        {
            
            portfolioManager.TUpdate(portfolio);
            return RedirectToAction("Index");
        }


    }
}
