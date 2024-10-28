using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfOrderRepository : GenericRepository<Order>, IOrderDal
    {
        public EfOrderRepository(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Where(x=>x.Description=="Müşteri Masada").Count();
        }

        public decimal LastOrderPrice()
        {
            using var context = new SignalRContext();
            return context.Orders.OrderByDescending(x=>x.OrderID).Take(1).Select(y=>y.TotalPrice).FirstOrDefault();
        }

		public List<Order> OrderListWithMenuTable()
		{
			using var context=new SignalRContext();
            return context.Orders.Include(x=>x.MenuTable).OrderByDescending(x=>x.OrderID).ToList();
		}

		public decimal TodayTotalPrice()
        {
            using var context = new SignalRContext();
            return context.Orders.Where(x => x.OrderDate ==DateTime.Today).Sum(y => y.TotalPrice);
        }

        public int TotalOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Count();
        }
    }
}
