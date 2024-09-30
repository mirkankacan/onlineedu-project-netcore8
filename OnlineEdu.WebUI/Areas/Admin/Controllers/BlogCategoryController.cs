using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BlogCategoryDtos;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Validators;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BlogCategoryController : Controller
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultBlogCategoryDto>>("blogcategories");
            return View(values);
        }

        public async Task<IActionResult> DeleteBlogCategory(int id)
        {
            await _httpClient.DeleteAsync($"blogcategories/?id={id}");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateBlogCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogCategory(CreateBlogCategoryDto createBlogCategoryDto)
        {
            var validator = new BlogCategoryValidator();
            var result = await validator.ValidateAsync(createBlogCategoryDto);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View();
            }
            await _httpClient.PostAsJsonAsync("blogcategories", createBlogCategoryDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateBlogCategory(int id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateBlogCategoryDto>($"blogcategories/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlogCategory(UpdateBlogCategoryDto updateBlogCategoryDto)
        {
            await _httpClient.PutAsJsonAsync("blogcategories", updateBlogCategoryDto);
            return RedirectToAction(nameof(Index));
        }
    }
}