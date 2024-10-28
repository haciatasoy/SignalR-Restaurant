using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfNotificationRepository : GenericRepository<Notification>, INotificationDal
    {
        
        
        SignalRContext context=new SignalRContext();

        public EfNotificationRepository(SignalRContext context) : base(context)
        {
        }

        public List<Notification> GetAllNotificationByFalse()
        {
            return context.Notifications.Where(x=>x.Status==false).ToList();
        }

        public int NotificationCountByStatusFalse()
        {
            return context.Notifications.Where(x=>x.Status==false).Count();
        }

        public void NotificationStatusChangeToFalse(int id)
        {
            var value = context.Notifications.Find(id);
            value.Status = false;
            context.SaveChanges();

        }

        public void NotificationStatusChangeToTrue(int id)
        {
            var value = context.Notifications.Find(id);
            value.Status = true;
            context.SaveChanges();
        }
    }
}
