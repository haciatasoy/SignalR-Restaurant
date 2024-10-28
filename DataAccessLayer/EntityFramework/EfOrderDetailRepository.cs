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
    public class EfOrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailDal
    {
        public EfOrderDetailRepository(SignalRContext context) : base(context)
        {
        }
		

		List<OrderDetail> IOrderDetailDal.GetByOrderId(int id)
		{
			using var context = new SignalRContext();
			return context.OrderDetails.Include(x=>x.Product).Where(x => x.OrderID == id).ToList();
		}
	}
}
