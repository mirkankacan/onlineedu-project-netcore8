using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.UserDtos;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.Controllers
{
    public class LoginController(IUserService _userService) : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto userLoginDto)
        {
            var userRole = await _userService.LoginAsync(userLoginDto);
            if (userRole == "Admin")
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
            }
            else if (userRole == "Teacher")
            {
                return RedirectToAction("Index", "MyCourse", new { area = "Teacher" });
            }
            else if (userRole == "Student")
            {
                return RedirectToAction("Index", "CourseRegister", new { area = "Student" });
            }
            else
            {
                ModelState.AddModelError("", "E-posta ya da şifre hatalı.");
                return View();
            }
        }
    }
}