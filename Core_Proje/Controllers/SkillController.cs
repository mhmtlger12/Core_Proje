using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Yetenekler Listesi";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenekler Listesi";
            var values = skillManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            ViewBag.v1 = "Yetenekler Ekleme";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenekler Ekleme";

            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(Skill skill)
        {
            skillManager.TAdd(skill);  
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSkill(int id)
        {
            var skill = skillManager.TGetByID(id);

            if (skill == null)
            {
                return NotFound(); // Yeteneğin mevcut olmadığı durumu ele al
            }

            return View("DeleteConfirmation", skill); // Onay görünümüne yönlendir
        }

        [HttpPost]
        public IActionResult DeleteSkillConfirmed(int id)
        {
            var skill = skillManager.TGetByID(id);

            if (skill == null)
            {
                return NotFound(); // Becerinin mevcut olmadığı durumlarda durumu ele alın (açıklık sağlamak için gereksizdir)
            }

            skillManager.TDelete(skill);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            ViewBag.v1 = "Düzenleme";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenekler Düzenleme";
            var values = skillManager.TGetByID(id);
            return View(values);    
        }
        [HttpPost]
        public ActionResult EditSkill(Skill skill)
        {
            skillManager.TUpdate(skill);
            return RedirectToAction("Index");
        }

    }
}
