using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concreate;
using DTOlayer.OrderDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IBasketService basketService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IMenuTableService _menuTableService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMapper mapper;

        public OrdersController(IOrderService orderService, IMapper mapper, IBasketService basketService, IOrderDetailService orderDetailService, IMenuTableService menuTableService, IMoneyCaseService moneyCaseService)
        {
            _orderService = orderService;
            this.mapper = mapper;
            this.basketService = basketService;
            _orderDetailService = orderDetailService;
            _menuTableService = menuTableService;
            _moneyCaseService = moneyCaseService;
        }

        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            return Ok(_orderService.TTotalOrderCount());
        }

        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            return Ok(_orderService.TActiveOrderCount());
        }

        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            return Ok(_orderService.TLastOrderPrice());
        }
        [HttpGet("TodayTotalPrice")]
        public IActionResult TodayTotalPrice()
        {
            return Ok(_orderService.TTodayTotalPrice());
        }
        [HttpGet("OrderDetails")]
        public IActionResult OrderDetails(int id)
        {
            var values=_orderDetailService.GetByOrderID(id);
            return Ok(values);
        }
        [HttpGet]
        public IActionResult OrderList()
        {			
            var values=_orderService.OrderListWithMenuTable();
			return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateOrder(CreateOrderDto createOrderDto)
        {
			using var context = new SignalRContext();

            var kasa = context.MoneyCases.FirstOrDefault();
            

            createOrderDto.OrderDate =DateTime.Now;
            createOrderDto.TotalPrice = 0;

			var values = mapper.Map<Order>(createOrderDto);
            _orderService.TAdd(values);
           
            var lastorderid=context.Orders.Take(1).OrderByDescending(x=>x.OrderID).Select(y=>y.OrderID).FirstOrDefault();
            var basketitems=context.Baskets.Where(x=>x.MenuTableID==values.MenuTableID).ToList();
            foreach(var basketitem in basketitems)
            {
                OrderDetail orderDetail = new OrderDetail();

                orderDetail.ProductID=basketitem.ProductID;
                orderDetail.Count=basketitem.Count;
                orderDetail.UnitPrice = basketitem.Price;
                orderDetail.TotalPrice=basketitem.TotalPrice;
                orderDetail.OrderID = lastorderid;

				basketService.TDelete(basketitem);
				
				_orderDetailService.TAdd(orderDetail);
                   
            }
            decimal kdv =Convert.ToDecimal(1.10);
			values.TotalPrice = basketitems.Sum(x => x.TotalPrice)*kdv;
            _orderService.TUpdate(values);
            _menuTableService.TChangeMenuTableStatusToFalse(values.MenuTableID);

            var kasatutar = kasa.TotalAmount;
            kasa.TotalAmount =kasatutar + values.TotalPrice;
            context.MoneyCases.Update(kasa);
            context.SaveChanges();
 
            return Ok("Sipariş Alındı");
        }
       

    }
}
