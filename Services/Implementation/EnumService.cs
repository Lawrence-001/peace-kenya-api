using peace_kenya_api.Dtos;
using peace_kenya_api.Helpers;
using peace_kenya_api.Repositories.Interfaces;
using peace_kenya_api.Services.Interfaces;

namespace peace_kenya_api.Services.Implementation
{
    public class EnumService : IEnumService
    {
        private readonly IEnumRepository _enumRepository;

        public EnumService(IEnumRepository enumRepository)
        {
            _enumRepository = enumRepository;
        }

        public async Task<Result<Dictionary<string, List<EnumDto>>>> GetAllEnums()
        {
            var enums = _enumRepository.GetAllEnums();
            var result = Result<Dictionary<string, List<EnumDto>>>.Success(enums);
            return result;
        }

        public async Task<Result<List<EnumDto>>> GetEnumByName(string enumName)
        {
            try
            {
                var enumValues = _enumRepository.GetEnumByName(enumName);
                return Result<List<EnumDto>>.Success(enumValues);
            }
            catch (ArgumentException ex)
            {
                return Result<List<EnumDto>>.Failure(ex.Message);
            }
        }
    }
}
