using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.CourseCategoryDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CourseCategoryController : Controller
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultCourseCategoryDto>>("coursecategories");
            return View(values);
        }

        public async Task<IActionResult> DeleteCourseCategory(int id)
        {
            await _httpClient.DeleteAsync($"coursecategories/?id={id}");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateCourseCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseCategory(CreateCourseCategoryDto createCourseCategoryDto)
        {
            await _httpClient.PostAsJsonAsync("coursecategories", createCourseCategoryDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateCourseCategory(int id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateCourseCategoryDto>($"coursecategories/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCourseCategory(UpdateCourseCategoryDto updateCourseCategoryDto)
        {
            await _httpClient.PutAsJsonAsync("coursecategories", updateCourseCategoryDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _httpClient.GetAsync("coursecategories/showonhome/" + id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> HideOnHome(int id)
        {
            await _httpClient.GetAsync("coursecategories/hideonhome/" + id);
            return RedirectToAction(nameof(Index));
        }
    }
}