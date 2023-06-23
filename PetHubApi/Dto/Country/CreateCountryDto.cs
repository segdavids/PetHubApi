using Microsoft.Build.Framework;

namespace PetHubApi.Dto.Country
{
    public class CreateCountryDto : BaseCountryDto
    {
        public int Id { get; set; }
    }

    public class UpdateCountry : BaseCountryDto
    {
        public int Id { get; set; }
    }
}
