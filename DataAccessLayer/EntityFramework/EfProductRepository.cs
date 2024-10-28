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
	public class EfProductRepository : GenericRepository<Product>, IProductDal
	{
        SignalRContext context = new SignalRContext();
        public EfProductRepository(SignalRContext context) : base(context)
		{
		}

		public List<Product> GetProductsWithCategories()
		{
			
			var values=context.Products.Include(x=>x.Category).ToList();
			return values;
		}

        public string ProductNameByMaxPrice()
        {
            return context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public string ProductNameByMinPrice()
        {
            return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public int ProductCount()
        {
            return context.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "İçecek").Select(z => z.CategoryID).FirstOrDefault())).Count();
        }

        public int ProductCountByCategoryNameHamburger()
        {
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Count();

        }

        public decimal ProductPriceAvg()
        {
           return context.Products.Average(x => x.Price);
        }

        public decimal ProductAvgPriceByHamburger()
        {
            return context.Products.Where(x=>x.CategoryID==(context.Categories.Where(y=>y.CategoryName=="Hamburger").Select(z=>z.CategoryID).FirstOrDefault())).Average(w=>w.Price);
        }

        public decimal TotalPriceByTatli()
        {
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Tatlı").Select(z => z.CategoryID).FirstOrDefault())).Sum(w => w.Price);

        }

        public decimal TotalPriceByDrinkCategory()
        {
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "İçecek").Select(z => z.CategoryID).FirstOrDefault())).Sum(w => w.Price);
        }

        public decimal TotalPriceBySaladCategory()
        {
            return context.Products.Where(x=>x.CategoryID==(context.Categories.Where(y=>y.CategoryName=="Salata").Select(z=>z.CategoryID).FirstOrDefault())).Sum(w=>w.Price);
        }

        public List<Product> GetLast9Products()
        {
            // return context.Products.Take(9).OrderByDescending(x => x.ProductID).ToList();
            throw new Exception();
        }
    }
}
