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
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            this.orderDal = orderDal;
        }

		public List<Order> OrderListWithMenuTable()
		{
			return orderDal.OrderListWithMenuTable();
		}

		public int TActiveOrderCount()
        {
           return orderDal.ActiveOrderCount();
        }

        public void TAdd(Order entity)
        {
           orderDal.Add(entity);
        }

        public void TDelete(Order entity)
        {
            orderDal.Delete(entity);
        }

        public Order TGetByID(int id)
        {
            return orderDal.GetByID(id);
        }

        public List<Order> TGetListAll()
        {
            return orderDal.GetListAll();
        }

        public decimal TLastOrderPrice()
        {
            return orderDal.LastOrderPrice();
        }

        public decimal TTodayTotalPrice()
        {
            return orderDal.TodayTotalPrice();
        }

        public int TTotalOrderCount()
        {
            return orderDal.TotalOrderCount();
        }

        public void TUpdate(Order entity)
        {
           orderDal.Update(entity);
        }
    }
}
