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
    public class ContactManager : IContactService
    {
        IContactDal contactDal;

        public ContactManager(IContactDal contactDal)
        {
            this.contactDal = contactDal;
        }
        public void Tadd(Contact t)
        {
            contactDal.Insert(t);
        }

        public void Tdelete(Contact t)
        {
            throw new NotImplementedException();
        }

        public void Tupdate(Contact t)
        {
            contactDal.Update(t);
        }

        public List<Contact> TgetList()
        {
            return contactDal.List();
        }

        public Contact TgetById(int id)
        {
            return contactDal.Find(x => x.ID == id);
        }
    }
}
