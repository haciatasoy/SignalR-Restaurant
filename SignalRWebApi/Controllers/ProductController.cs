using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concreate;
using DTOlayer.ProductDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SignalRWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;
		public ProductController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ProductList()
		{
			var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
			return Ok(value);
		}

		[HttpGet("ProductCount")]
		public IActionResult ProductCount()
		{
			return Ok(_productService.TProductCount());
		}

		[HttpGet("TotalPriceByDrinkCategory")]
		public IActionResult TotalPriceByDrinkCategory()
		{
			return Ok(_productService.TTotalPriceByDrinkCategory());
		}

		[HttpGet("TotalPriceBySaladCategory")]
		public IActionResult TotalPriceBySaladCategory()
		{
			return Ok(_productService.TTotalPriceBySaladCategory());
		}

		[HttpGet("ProductNameByMaxPrice")]
		public IActionResult ProductNameByMaxPrice()
		{
			return Ok(_productService.TProductNameByMaxPrice());
		}

		[HttpGet("ProductNameByMinPrice")]
		public IActionResult ProductNameByMinPrice()
		{
			return Ok(_productService.TProductNameByMinPrice());
		}

		[HttpGet("ProductAvgPriceByHamburger")]
		public IActionResult ProductAvgPriceByHamburger()
		{
			return Ok(_productService.TProductAvgPriceByHamburger());
		}

		[HttpGet("ProductCountByHamburger")]
		public IActionResult ProductCountByHamburger()
		{
			return Ok(_productService.TProductCountByCategoryNameHamburger());
		}

		[HttpGet("ProductCountByDrink")]
		public IActionResult ProductCountByDrink()
		{
			return Ok(_productService.TProductCountByCategoryNameDrink());
		}

		[HttpGet("ProductPriceAvg")]
		public IActionResult ProductPriceAvg()
		{
			return Ok(_productService.TProductPriceAvg());
		}

		[HttpGet("TotalPriceByTatli")]
		public IActionResult ProductPriceBySteakBurger()
		{
			return Ok(_productService.TTotalPriceByTatli());
		}



		[HttpGet("ProductListWithCategory")]
		public IActionResult ProductListWithCategory()
		{
			var context = new SignalRContext();
			var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategoryDto
			{
				Description = y.Description,
				ImageUrl = y.ImageUrl,
				Price = y.Price,
				ProductID = y.ProductID,
				ProductName = y.ProductName,
				ProductStatus = y.ProductStatus,
				CategoryName = y.Category.CategoryName
			});
			return Ok(values.ToList());
		}

		[HttpPost]
		public IActionResult CreateProduct(CreateProductDto createProductDto)
		{
			var value = _mapper.Map<Product>(createProductDto);
			_productService.TAdd(value);
			return Ok("Ürün Bilgisi Eklendi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteProduct(int id)
		{
			var value = _productService.TGetByID(id);
			_productService.TDelete(value);
			return Ok("Ürün Bilgisi Silindi");
		}

		[HttpGet("{id}")]
		public IActionResult GetProduct(int id)
		{
			var value = _productService.TGetByID(id);
			return Ok(_mapper.Map<GetByIdProductDto>(value));
		}
		[HttpPut]
		public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
		{
			var value = _productService.TGetByID(updateProductDto.ProductID);
			_productService.TUpdate(value);
			return Ok("Ürün Bilgisi Güncellendi");
		}

		[HttpGet("GetLast9Products")]
		public IActionResult GetLast9Products()
		{
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategoryDto
            {
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ProductID = y.ProductID,
                ProductName = y.ProductName,
                ProductStatus = y.ProductStatus,
                CategoryName = y.Category.CategoryName
            });
            return Ok(values.Take(9).OrderBy(x => Guid.NewGuid()).ToList());
        }
	}
}
