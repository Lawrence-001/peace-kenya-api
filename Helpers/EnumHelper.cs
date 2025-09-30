using peace_kenya_api.Dtos;

namespace peace_kenya_api.Helpers
{
    public static class EnumHelper
    {
        public static List<EnumDto> ToDtoList<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(e => new EnumDto
                {
                    Key = Convert.ToInt32(e),
                    Value = e.ToString()
                })
                .ToList();
        }
    }
}
