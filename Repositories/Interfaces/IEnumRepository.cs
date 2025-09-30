using peace_kenya_api.Dtos;

namespace peace_kenya_api.Repositories.Interfaces
{
    public interface IEnumRepository
    {
        Dictionary<string, List<EnumDto>> GetAllEnums();
        List<EnumDto> GetEnumByName(string enumName);
    }
}
