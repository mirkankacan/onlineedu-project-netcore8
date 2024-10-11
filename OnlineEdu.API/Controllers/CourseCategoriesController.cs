using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoriesController(ICourseCategoryService _courseCategoryService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var values = await _courseCategoryService.TGetListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var value = await _courseCategoryService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _courseCategoryService.TDeleteAsync(id);
            return Ok("Course category record deleted");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCourseCategoryDto createCourseCategoryDto)
        {
            var newValue = _mapper.Map<CourseCategory>(createCourseCategoryDto);
            await _courseCategoryService.TCreateAsync(newValue);
            return Ok("New course category record created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateCourseCategoryDto updateCourseCategoryDto)
        {
            var value = _mapper.Map<CourseCategory>(updateCourseCategoryDto);
            await _courseCategoryService.TUpdateAsync(value);
            return Ok("Course category record updated");
        }

        [HttpGet("ShowOnHome/{id}")]
        public async Task<IActionResult> ShowOnHome(int id)
        {
            try
            {
                await _courseCategoryService.TShowOnHome(id);
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
                await _courseCategoryService.THideOnHome(id);
                return Ok();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("GetActiveCategories")]
        public async Task<IActionResult> GetActiveCategories()
        {
            try
            {
                var values = await _courseCategoryService.TGetFilteredListAsync(x => x.IsShown == true);
                return Ok(values);
            }
            catch
            {
                throw;
            }
        }
    }
}