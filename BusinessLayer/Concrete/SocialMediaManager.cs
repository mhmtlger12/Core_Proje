using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediDal _socialMediDal;

        public SocialMediaManager(ISocialMediDal socialMediDal)
        {
            _socialMediDal = socialMediDal;
        }

        public void TAdd(SocialMedia t)
        {
            _socialMediDal.Insert(t);
        }

        public void TDelete(SocialMedia t)
        {
            _socialMediDal.Delete(t);
        }

        public SocialMedia TGetByID(int id)
        {
            return _socialMediDal.GetById(id);
        }

        public List<SocialMedia> TGetList()
        {
            return _socialMediDal.GetList();
        }

        public void TUpdate(SocialMedia t)
        {
           _socialMediDal.Update(t);
        }
    }
}
