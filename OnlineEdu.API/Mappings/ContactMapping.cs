using AutoMapper;
using OnlineEdu.DTO.DTOs.ContactDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mappings
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>().ReverseMap();
        }
    }
}