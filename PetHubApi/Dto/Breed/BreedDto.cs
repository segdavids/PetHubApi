using PetHubApi.Dto.Pet;

namespace PetHubApi.Dto.Breed
{
    public class BreedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CountryId { get; set; }

        public virtual IList<PetDto> Pets { get; set; }
    }


}
