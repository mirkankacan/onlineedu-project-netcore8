using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(ICourseService _courseService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var values = await _courseService.TGetCoursesWithCategories();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var value = await _courseService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _courseService.TDeleteAsync(id);
            return Ok("Course record deleted");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCourseDto createCourseDto)
        {
            var newValue = _mapper.Map<Course>(createCourseDto);
            await _courseService.TCreateAsync(newValue);
            return Ok("New course record created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateCourseDto updateCourseDto)
        {
            var value = _mapper.Map<Course>(updateCourseDto);
            await _courseService.TUpdateAsync(value);
            return Ok("Course record updated");
        }
        [HttpGet("ShowOnHome/{id}")]
        public async Task<IActionResult> ShowOnHome(int id)
        {
            try
            {
                await _courseService.TShowOnHome(id);
                return Ok();
            }
            catch
            {
                throw;
            }

        }

        [HttpGet("HideOnHome/{id}")]
        public async Task<IActionResult> HideOnHome(int id)
        {
            try
            {
                await _courseService.THideOnHome(id);
                return Ok();
            }
            catch
            {
                throw;
            }
        }
    }
}