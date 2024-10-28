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
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDal orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            this.orderDetailDal = orderDetailDal;
        }

		public List<OrderDetail> GetByOrderID(int id)
		{
			return orderDetailDal.GetByOrderId(id);
		}

		public void TAdd(OrderDetail entity)
        {
            orderDetailDal.Add(entity);
        }

        public void TDelete(OrderDetail entity)
        {
            orderDetailDal.Delete(entity);
        }

        public OrderDetail TGetByID(int id)
        {
           return orderDetailDal.GetByID(id);
        }

        public List<OrderDetail> TGetListAll()
        {
           return orderDetailDal.GetListAll();
        }

        public void TUpdate(OrderDetail entity)
        {
            orderDetailDal.Update(entity);
        }
    }
}
