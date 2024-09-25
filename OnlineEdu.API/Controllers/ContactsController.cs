using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.ContactDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IGenericService<Contact> _contactService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var values = await _contactService.TGetListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var value = await _contactService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _contactService.TDeleteAsync(id);
            return Ok("Contact record deleted");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateContactDto createContactDto)
        {
            var newValue = _mapper.Map<Contact>(createContactDto);
            await _contactService.TCreateAsync(newValue);
            return Ok("New contact record created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateContactDto updateContactDto)
        {
            var value = _mapper.Map<Contact>(updateContactDto);
            await _contactService.TUpdateAsync(value);
            return Ok("Contact record updated");
        }
    }
}