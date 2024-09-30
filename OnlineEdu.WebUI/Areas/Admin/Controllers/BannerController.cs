using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BannerDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BannerController : Controller
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultBannerDto>>("banners");
            return View(values);
        }

        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _httpClient.DeleteAsync($"banners/?id={id}");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            await _httpClient.PostAsJsonAsync("banners", createBannerDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateBanner(int id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateBannerDto>($"banners/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            await _httpClient.PutAsJsonAsync("banners", updateBannerDto);
            return RedirectToAction(nameof(Index));
        }
    }
}