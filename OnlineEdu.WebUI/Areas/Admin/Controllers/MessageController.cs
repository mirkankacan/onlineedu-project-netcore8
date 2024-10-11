using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.MessageDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MessageController : Controller
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultMessageDto>>("Messages");
            return View(values);
        }

        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _httpClient.DeleteAsync($"Messages/?id={id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> MessageDetail(int id)
        {
            var value = await _httpClient.GetFromJsonAsync<ResultMessageDto>($"messages/{id}");
            return View(value);
        }
    }
}