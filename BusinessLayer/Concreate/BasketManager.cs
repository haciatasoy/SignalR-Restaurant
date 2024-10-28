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
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            this.basketDal = basketDal;
        }

        public void TAdd(Basket entity)
        {
          basketDal.Add(entity);
        }

        public void TDelete(Basket entity)
        {
            basketDal.Delete(entity);
        }

        public List<Basket> TGetBasketByMenuTableNumber(int id)
        {
            return basketDal.GetBasketByMenuTableNumber(id);
        }

        public Basket TGetByID(int id)
        {
            return basketDal.GetByID(id);
        }

        public List<Basket> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Basket entity)
        {
           basketDal.Update(entity);
        }
    }
}
