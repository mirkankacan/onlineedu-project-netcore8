using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.SocialMediaDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class SocialMediaController : Controller
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultSocialMediaDto>>("SocialMedias");
            return View(values);
        }

        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            await _httpClient.DeleteAsync($"SocialMedias/?id={id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            await _httpClient.PostAsJsonAsync("SocialMedias", createSocialMediaDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateSocialMediaDto>($"SocialMedias/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            await _httpClient.PutAsJsonAsync("SocialMedias", updateSocialMediaDto);
            return RedirectToAction(nameof(Index));
        }
    }
}