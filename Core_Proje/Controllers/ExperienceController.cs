using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            var values = experienceManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
		[HttpPost]
		public ActionResult AddExperience( Experience experience)
		{
            ExperienceValidator validator = new ExperienceValidator();
            ValidationResult results = validator.Validate(experience);

            if (results.IsValid)
            {
                experienceManager.TAdd(experience);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var failure in results.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }

            return View(experience);

      
          
		}
		public IActionResult Deleteexperience(int id)
		{
			var experience = experienceManager.TGetByID(id);

			if (experience == null)
			{
				return NotFound(); // Yeteneğin mevcut olmadığı durumu ele al
			}

			return View("DeleteConfirmation", experience); // Onay görünümüne yönlendir
		}

		[HttpPost]
		public IActionResult DeleteexperienceConfirmed(int id)
		{
			var experience = experienceManager.TGetByID(id);

			if (experience == null)
			{
				return NotFound(); // Becerinin mevcut olmadığı durumlarda durumu ele alın (açıklık sağlamak için gereksizdir)
			}

			experienceManager.TDelete(experience);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Editexperience(int id)
		{
			ViewBag.v1 = "Düzenleme";
			ViewBag.v2 = "Yetenekler";
			ViewBag.v3 = "Yetenekler Düzenleme";
			var values = experienceManager.TGetByID(id);
			return View(values);
		}
		[HttpPost]
		public ActionResult Editexperience(Experience experience)
		{
			experienceManager.TUpdate(experience);
			return RedirectToAction("Index");
		}


	}
}
