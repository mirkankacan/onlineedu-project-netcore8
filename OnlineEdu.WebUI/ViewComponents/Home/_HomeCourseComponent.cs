using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.CourseDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeCourseComponent : ViewComponent
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ResultCourseDto>>("courses/getactivecourses");
            return View(result);
        }
    }
}