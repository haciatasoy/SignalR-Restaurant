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
	public class EfDiscountRepository : GenericRepository<Discount>, IDiscountDal
	{
        SignalRContext context=new SignalRContext();
		public EfDiscountRepository(SignalRContext context) : base(context)
		{
		}

        public void ChangeStatusToFalse(int id)
        {
            var value = context.Discounts.Find(id);
            value.Status = false;
            context.SaveChanges();
        }

        public void ChangeStatusToTrue(int id)
        {
            var value = context.Discounts.Find(id);
            value.Status = true;
            context.SaveChanges();
        }

        public void GetByName(string coupon,int id)
        {            
            var values = context.Discounts.Where(x => x.Title == coupon && x.Status == true).Select(x=>x.Amount).FirstOrDefault();
            var basketitems=context.Baskets.Where(x=>x.MenuTableID== id).ToList();
            foreach(var basketitem in basketitems)
            {
                basketitem.Price = basketitem.Price - ((basketitem.Price * values) / 100);
                context.Baskets.Update(basketitem);
                
            }
            context.SaveChanges();
            
        }

        public List<Discount> GetListByStatusTrue()
        {
            return context.Discounts.Where(x=>x.Status==true).ToList();
        }
    }
}
