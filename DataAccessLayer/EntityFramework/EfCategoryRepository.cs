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
	public class EfCategoryRepository : GenericRepository<Category>, ICategoryDal
	{
        SignalRContext context=new SignalRContext();
		public EfCategoryRepository(SignalRContext context) : base(context)
		{
		}

        public int ActiveCategoryCount()
        {
            return context.Categories.Where(x=>x.Status==true).Count();
        }

        public int CategoryCount()
        {
           return context.Categories.Count();
        }

        public int PassiveCategoryCount()
        {
            return context.Categories.Where(x=>x.Status==false).Count();
        }
    }
}
