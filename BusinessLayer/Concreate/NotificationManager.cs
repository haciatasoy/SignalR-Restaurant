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
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            this.notificationDal = notificationDal;
        }

        public void TAdd(Notification entity)
        {
            notificationDal.Add(entity);
        }

        public void TDelete(Notification entity)
        {
            notificationDal.Delete(entity);
        }

        public List<Notification> TGetAllNotificationByFalse()
        {
            return notificationDal.GetAllNotificationByFalse();
        }

        public Notification TGetByID(int id)
        {
           return (notificationDal.GetByID(id));
        }

        public List<Notification> TGetListAll()
        {
            return notificationDal.GetListAll();
        }

        public int TNotificationCountByStatusFalse()
        {
            return notificationDal.NotificationCountByStatusFalse();
        }

        public void TNotificationStatusChangeToFalse(int id)
        {
            notificationDal.NotificationStatusChangeToFalse(id);
        }

        public void TNotificationStatusChangeToTrue(int id)
        {
            notificationDal.NotificationStatusChangeToTrue(id);
        }

        public void TUpdate(Notification entity)
        {
            notificationDal.Update(entity); 
        }
    }
}
