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
    public class EfBasketRepository : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketRepository(SignalRContext context) : base(context)
        {
        }

        public List<Basket> GetBasketByMenuTableNumber(int id)
        {
           using var context = new SignalRContext();
            return context.Baskets.Include(y=>y.Product).Where(x=>x.MenuTableID == id).ToList();
        }
    }
}
