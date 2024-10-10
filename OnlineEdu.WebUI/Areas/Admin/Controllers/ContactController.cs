using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.ContactDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ContactController : Controller
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultContactDto>>("contacts");
            return View(values);
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            await _httpClient.DeleteAsync($"contacts/?id={id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            await _httpClient.PostAsJsonAsync("contacts", createContactDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateContact(int id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateContactDto>($"contacts/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            await _httpClient.PutAsJsonAsync("contacts", updateContactDto);
            return RedirectToAction(nameof(Index));
        }
    }
}