using AutoMapper;
using peace_kenya_api.Dtos.Donation;
using peace_kenya_api.Models;

namespace peace_kenya_api.Profiles
{
    public class DonationProfile : Profile
    {
        public DonationProfile()
        {
            CreateMap<CreateDonationDto, Donations>().ReverseMap();
            CreateMap<Donations, DonationDto>();
        }
    }
}
