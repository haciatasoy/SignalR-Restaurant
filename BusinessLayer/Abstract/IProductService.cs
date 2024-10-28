using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IProductService:IGenericService<Product>
	{
		List<Product> TGetProductsWithCategories();
		public int TProductCount();
        int TProductCountByCategoryNameDrink();
        int TProductCountByCategoryNameHamburger();
        decimal TProductPriceAvg();
        string TProductNameByMaxPrice();
        string TProductNameByMinPrice();
        decimal TProductAvgPriceByHamburger();
        decimal TTotalPriceByTatli();
        decimal TTotalPriceByDrinkCategory();
        decimal TTotalPriceBySaladCategory();
        List<Product> TGetLast9Products();

    }
}
