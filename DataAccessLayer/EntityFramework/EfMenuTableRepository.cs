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
    public class EfMenuTableRepository : GenericRepository<MenuTable>, IMenuTableDal
    {
        SignalRContext context= new SignalRContext();
        public EfMenuTableRepository(SignalRContext context) : base(context)
        {
        }

		public void ChangeMenuTableStatusToFalse(int id)
		{
           var value= context.MenuTables.Find(id);
           value.Status= false;
            context.SaveChanges();
		}

		public void ChangeMenuTableStatusToTrue(int id)
		{
			var value = context.MenuTables.Find(id);
			value.Status = true;
			context.SaveChanges();
		}

		public int MenuTableCount()
        {
            return context.MenuTables.Count();
        }
    }
}
