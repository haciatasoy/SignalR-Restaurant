using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class MailSettingManager : IMailSettingService
    {
        private readonly IMailSettingDal mailSettingDal;

        public MailSettingManager(IMailSettingDal mailSettingDal)
        {
            this.mailSettingDal = mailSettingDal;
        }

        public void TAdd(MailSetting entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(MailSetting entity)
        {
            throw new NotImplementedException();
        }

        public MailSetting TGetByID(int id)
        {
            return mailSettingDal.GetByID(id);
        }

        public List<MailSetting> TGetListAll()
        {
            return mailSettingDal.GetListAll();
        }

        public void TUpdate(MailSetting entity)
        {
            throw new NotImplementedException();
        }
    }
}
