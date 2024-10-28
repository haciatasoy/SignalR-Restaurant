using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.MessageDtos;

namespace SignalRWebUI.Controllers
{
    public class MessageAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MessageAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7186/api/Message/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task <IActionResult> DeleteMessage(int id)
        {
			
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7186/api/Message/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
                return RedirectToAction("Index");
			}
			return NoContent();
		}
        public async Task<IActionResult> ViewMessage(int id)
        {
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7186/api/Message/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateMessageDto>(jsonData);
				return View(values);
			}
			return View();
		}

	}
}
