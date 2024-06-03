using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Testimonial
{
    public class testimonialList:ViewComponent
    {
        TestimonialManager testimoniaManager = new TestimonialManager(new EfTestimonialDal());

        public IViewComponentResult Invoke()
        {
            var values= testimoniaManager.TGetList();
            return View(values);
        }
    }
}
