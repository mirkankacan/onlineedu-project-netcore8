using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoriesController(IGenericService<CourseCategory> _courseCategoryService, IMapper _mapper) : ControllerBase
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
    }
}