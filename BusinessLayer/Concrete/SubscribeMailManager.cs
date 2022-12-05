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
    public class SubscribeMailManager : ISubscribeMailService
    {
        ISubscribeMailDal subscribeMailDal;

        public SubscribeMailManager(ISubscribeMailDal subscribeMailDal)
        {
            this.subscribeMailDal = subscribeMailDal;
        }

        public void Tadd(SubscribeMail t)
        {
            subscribeMailDal.Insert(t);
        }

        public void Tdelete(SubscribeMail t)
        {
            throw new NotImplementedException();
        }

        public SubscribeMail TgetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<SubscribeMail> TgetList()
        {
            throw new NotImplementedException();
        }

        public void Tupdate(SubscribeMail t)
        {
            throw new NotImplementedException();
        }
    }
}
