using PetHubApi.Dto.Breed;

namespace PetHubApi.Configurations
{
    public class CountryDto
    {
        public int Id { get; set; }
        public virtual IList<BreedDto> Breeds { get; set; }
    }

    
}
