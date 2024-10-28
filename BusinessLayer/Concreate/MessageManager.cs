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
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            this.messageDal = messageDal;
        }

        public void TAdd(Message entity)
        {
            messageDal.Add(entity);
        }

        public void TDelete(Message entity)
        {
            messageDal.Delete(entity);
        }

        public List<Message> TGetAllMessagesByFalse()
        {
            return messageDal.GetAllMessagesByFalse();
        }

        public Message TGetByID(int id)
        {
           return messageDal.GetByID(id);
        }

        public List<Message> TGetListAll()
        {
            return messageDal.GetListAll();
        }

        public int TNotificationCountByFalse()
        {
            return messageDal.NotificationCountByFalse();
        }

        public void TUpdate(Message entity)
        {
            messageDal.Update(entity);
        }
    }
}
