using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.WebUI.DTOs.BlogCategoryDtos;
using OnlineEdu.WebUI.DTOs.BlogDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BlogController : Controller
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultBlogDto>>("blogs");
            return View(values);
        }

        public async Task BlogCategoryDropdown()
        {
            var categoryList = await _httpClient.GetFromJsonAsync<List<ResultBlogCategoryDto>>("blogcategories");
            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.BlogCategoryId.ToString()
                                               }).ToList();
            ViewBag.Categories = categories;
        }

        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _httpClient.DeleteAsync($"blogs/?id={id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
            await BlogCategoryDropdown();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {
            await _httpClient.PostAsJsonAsync("blogs", createBlogDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateBlog(int id)
        {
            await BlogCategoryDropdown();
            var values = await _httpClient.GetFromJsonAsync<UpdateBlogDto>($"blogs/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)
        {
            await _httpClient.PutAsJsonAsync("blogs", updateBlogDto);
            return RedirectToAction(nameof(Index));
        }
    }
}