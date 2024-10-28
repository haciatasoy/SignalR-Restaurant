using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.OrderDtos;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.DiscountDtos;
using SignalRWebUI.Dtos.OrderDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class BasketsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BasketsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int id)
        {
            TempData["id"] = id;
            TempData["TableNumber"] = id;
            ViewBag.id = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7186/api/Basket/BasketListByMenuTableWithProductName?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);                
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> DeleteBasket(int id)
        {
            
            var menuTableID = int.Parse(TempData["id"].ToString());
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7186/api/Basket/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Baskets", new { id = menuTableID });
            }
            return NoContent();
        }
               
        public async Task<IActionResult> BasketAzalt(int id,UpdateBasketDto updateBasketDto)
        {
            

            updateBasketDto.MenuTableID = int.Parse(TempData["id"].ToString());

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBasketDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7186/api/Basket/BasketAzalt?id="+id, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Baskets", new { id = updateBasketDto.MenuTableID });
            }
            return NoContent();
        }
        public async Task<IActionResult> BasketArt(int id, UpdateBasketDto updateBasketDto)
        {
           
            updateBasketDto.MenuTableID = int.Parse(TempData["id"].ToString());

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBasketDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7186/api/Basket/BasketArt?id=" + id, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Baskets",new {id=updateBasketDto.MenuTableID});
            }
            return NoContent();
        }
        public async Task <IActionResult> KuponSorgula(string coupon,int id,UpdateBasketDto updateBasketDto)
        {
            updateBasketDto.MenuTableID = int.Parse(TempData["id"].ToString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBasketDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7186/api/Discount/GetByName?coupon="+coupon+"&id=" + updateBasketDto.MenuTableID + "", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "Baskets", new { id = updateBasketDto.MenuTableID }) });
            }

			return NoContent();
        }
        public async Task<IActionResult> SiparisTamamla(CreateOrderDto createOrderDto)
        {
            
            createOrderDto.Description = "Hesap Kapatıldı";
            createOrderDto.MenuTableId = int.Parse(TempData["TableNumber"].ToString());
            
            var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createOrderDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7186/api/Orders", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index","Default");
			}
			return NoContent();
		}
        

    }
}
