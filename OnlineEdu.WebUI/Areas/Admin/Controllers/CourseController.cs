using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.WebUI.DTOs.CourseCategoryDtos;
using OnlineEdu.WebUI.DTOs.CourseDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CourseController : Controller
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultCourseDto>>("Courses");
            return View(values);
        }

        public async Task CourseCategoryDropdown()
        {
            var categoryList = await _httpClient.GetFromJsonAsync<List<ResultCourseCategoryDto>>("coursecategories");
            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CourseCategoryId.ToString()
                                               }).ToList();
            ViewBag.Categories = categories;
        }

        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _httpClient.DeleteAsync($"Courses/?id={id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> CreateCourse()
        {
            await CourseCategoryDropdown();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseDto createCourseDto)
        {
            await _httpClient.PostAsJsonAsync("Courses", createCourseDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateCourse(int id)
        {
            await CourseCategoryDropdown();
            var values = await _httpClient.GetFromJsonAsync<UpdateCourseDto>($"Courses/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCourse(UpdateCourseDto updateCourseDto)
        {
            await _httpClient.PutAsJsonAsync("Courses", updateCourseDto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _httpClient.GetAsync("courses/showonhome/" + id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> HideOnHome(int id)
        {
            await _httpClient.GetAsync("courses/hideonhome/" + id);
            return RedirectToAction(nameof(Index));
        }
    }
}