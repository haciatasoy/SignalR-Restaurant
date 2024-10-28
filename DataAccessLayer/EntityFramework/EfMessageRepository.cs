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
    public class EfMessageRepository : GenericRepository<Message>, IMessageDal
    {
        public EfMessageRepository(SignalRContext context) : base(context)
        {
        }

        public List<Message> GetAllMessagesByFalse()
        {
            using var context = new SignalRContext();
            return context.Messages.Where(x => x.Status == false).ToList();
        }

        public int NotificationCountByFalse()
        {
           using var context = new SignalRContext();
            return context.Messages.Where(x=>x.Status==false).Count();
        }
    }
}
