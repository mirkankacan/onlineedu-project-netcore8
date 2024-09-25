using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IGenericService<About> _aboutService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var values = await _aboutService.TGetListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var value = await _aboutService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _aboutService.TDeleteAsync(id);
            return Ok("About us record deleted");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateAboutDto createAboutDto)
        {
            var newValue = _mapper.Map<About>(createAboutDto);
            await _aboutService.TCreateAsync(newValue);
            return Ok("New about us record created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateAboutDto updateAboutDto)
        {
            var value = _mapper.Map<About>(updateAboutDto);
            await _aboutService.TUpdateAsync(value);
            return Ok("About us record updated");
        }
    }
}