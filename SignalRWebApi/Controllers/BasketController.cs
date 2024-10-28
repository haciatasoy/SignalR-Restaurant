using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concreate;
using DTOlayer.BasketDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalRWebApi.Models;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService basketService;
        private readonly IMapper mapper;


        public BasketController(IBasketService basketService, IMapper mapper)
        {
            this.basketService = basketService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetBasketByMenuTableID(int id)
        {
            var values=basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }
        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableID == id).Select(z => new ResultBasketListWithProducts
            {
                BasketID = z.BasketID,
                Count = z.Count,
                MenuTableID = z.MenuTableID,
                Price = z.Price,
                ProductID = z.ProductID,
                TotalPrice = z.TotalPrice,
                ProductName = z.Product.ProductName
            }).ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
           
            using var context = new SignalRContext();
            basketService.TAdd(new Basket()
            {
                ProductID = createBasketDto.ProductID,
                MenuTableID = createBasketDto.MenuTableID,
                Count = 1,
                Price = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(y => y.Price).FirstOrDefault(),
                
            });
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = basketService.TGetByID(id);
            basketService.TDelete(value);
            return Ok("Sepetteki Seçilen Ürün Silindi");
        }
        [HttpPut("BasketAzalt")]
        public IActionResult BasketAzalt(int id)
        {

            var value = basketService.TGetByID(id);
            value.Count = value.Count - 1;
            if (value.Count == 0)
            {
                return DeleteBasket(id);
            }
            basketService.TUpdate(value);
            return Ok("Ürün adeti eksildi.");
        }
        [HttpPut("BasketArt")]
        public IActionResult BasketArt(int id)
        {
            var value = basketService.TGetByID(id);
            value.Count = value.Count + 1;            
            basketService.TUpdate(value);
            return Ok("Ürün adeti arttı.");
        }




    }
}
