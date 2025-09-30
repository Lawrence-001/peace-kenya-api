using peace_kenya_api.Dtos;
using peace_kenya_api.Helpers;

namespace peace_kenya_api.Services.Interfaces
{
    public interface IEnumService
    {
        Task<Result<Dictionary<string, List<EnumDto>>>> GetAllEnums();
        Task<Result<List<EnumDto>>> GetEnumByName(string enumName);
    }
}
