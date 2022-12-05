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
    public class AdminManager : IAdminService
    {
        IAdminDal adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            this.adminDal = adminDal;
        }

        public void Tadd(Admin t)
        {
            adminDal.Insert(t);
        }

        public void Tdelete(Admin t)
        {
            throw new NotImplementedException();
        }

        public void Tupdate(Admin t)
        {
            adminDal.Update(t);
        }

        public List<Admin> TgetList()
        {
            return adminDal.List();
        }

        public Admin TgetById(int id)
        {
            return adminDal.Find(x=>x.ID==id);
        }
    }
}
