using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal aboutdal;
        Repository<About> repoAbout = new Repository<About>();

        public AboutManager(IAboutDal aboutdal)
        {
            this.aboutdal = aboutdal;
        }

        public void Tadd(About t)
        {
            throw new NotImplementedException();
        }

        public void Tdelete(About t)
        {
            throw new NotImplementedException();
        }

        public void Tupdate(About t)
        {
            aboutdal.Update(t);
        }

        public List<About> TgetList()
        {
            return aboutdal.List();
        }

        public About TgetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
