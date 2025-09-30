using AutoMapper;
using peace_kenya_api.Dtos.Beneficiary;
using peace_kenya_api.Models;

namespace peace_kenya_api.Profiles
{
    public class BeneficiaryProfile : Profile
    {
        public BeneficiaryProfile()
        {
            CreateMap<CreateBeneficiaryDto, Beneficiary>().ReverseMap();
            CreateMap<Beneficiary, BeneficiaryDto>();
        }
    }
}
