using AutoMapper;
using peace_kenya_api.Dtos.ContactUs;
using peace_kenya_api.Models;

namespace peace_kenya_api.Profiles
{
    public class ContactUsProfile : Profile
    {
        public ContactUsProfile()
        {
            CreateMap<CreateContactUsDto, ContactUs>(); //dto to entity
            CreateMap<ContactUs, ContactUsDto>();   // entity to response dto
        }

    }
}
