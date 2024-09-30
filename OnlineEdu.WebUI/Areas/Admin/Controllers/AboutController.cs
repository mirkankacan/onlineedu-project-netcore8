using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.AboutDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AboutController : Controller
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(values);
        }

        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _httpClient.DeleteAsync($"abouts/?id={id}");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _httpClient.PostAsJsonAsync("abouts", createAboutDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateAbout(int id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateAboutDto>($"abouts/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _httpClient.PutAsJsonAsync("abouts", updateAboutDto);
            return RedirectToAction(nameof(Index));
        }
    }
}