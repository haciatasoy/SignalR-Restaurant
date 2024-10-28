using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IProductDal:IGenericDal<Product>
	{
		List<Product> GetProductsWithCategories();
		public int ProductCount();
		int ProductCountByCategoryNameDrink();
        int ProductCountByCategoryNameHamburger();
		decimal ProductPriceAvg();
		string ProductNameByMaxPrice();
        string ProductNameByMinPrice();
        decimal ProductAvgPriceByHamburger();
        decimal TotalPriceByTatli();
        decimal TotalPriceByDrinkCategory();
        decimal TotalPriceBySaladCategory();
        List<Product> GetLast9Products();

    }
}
