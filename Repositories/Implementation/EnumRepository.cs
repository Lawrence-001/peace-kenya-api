using peace_kenya_api.Dtos;
using peace_kenya_api.Enums;
using peace_kenya_api.Helpers;
using peace_kenya_api.Repositories.Interfaces;

namespace peace_kenya_api.Repositories.Implementation
{
    public class EnumRepository : IEnumRepository
    {
        public Dictionary<string, List<EnumDto>> GetAllEnums()
        {
            return new Dictionary<string, List<EnumDto>>
            {
                { "DonationStatus", EnumHelper.ToDtoList<DonationStatus>() },
                { "DonationType", EnumHelper.ToDtoList<DonationType>() },
                { "Gender", EnumHelper.ToDtoList<Gender>() },
                { "Location", EnumHelper.ToDtoList<Location>() },
                { "Programs", EnumHelper.ToDtoList<Programs>() },
                { "Skills", EnumHelper.ToDtoList<Skills>() },
                {"PaymentMethod", EnumHelper.ToDtoList<PaymentMethod>() }
            };
        }

        public List<EnumDto> GetEnumByName(string enumName)
        {
            var type = Type.GetType(enumName, false, true);

            if (type == null || !type.IsEnum)
                throw new ArgumentException($"Enum '{enumName}' not found.");

            return Enum.GetValues(type)
                .Cast<object>()
                .Select(e => new EnumDto
                {
                    Key = Convert.ToInt32(e),
                    Value = e.ToString() ?? ""
                })
                .ToList();
        }
    }
}
