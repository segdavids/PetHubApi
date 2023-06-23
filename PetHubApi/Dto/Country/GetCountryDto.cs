using PetHubApi.Data;
using PetHubApi.Dto.Country;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHubApi.Configurations
{
    public class GetCountryDto: BaseCountryDto
    {
        public int Id { get; set; }
    }

    
}
