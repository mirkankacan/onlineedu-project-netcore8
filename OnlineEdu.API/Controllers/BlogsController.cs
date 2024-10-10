using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.BlogDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IMapper _mapper, IBlogService _blogService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var values = await _blogService.TGetBlogsWithCategories();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var value = await _blogService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _blogService.TDeleteAsync(id);
            return Ok("Blog record deleted");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateBlogDto createBlogDto)
        {
            var newValue = _mapper.Map<Blog>(createBlogDto);
            await _blogService.TCreateAsync(newValue);
            return Ok("New blog record created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateBlogDto updateBlogDto)
        {
            var value = _mapper.Map<Blog>(updateBlogDto);
            await _blogService.TUpdateAsync(value);
            return Ok("Blog record updated");
        }
    }
}