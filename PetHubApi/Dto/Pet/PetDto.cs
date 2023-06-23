using System.ComponentModel.DataAnnotations.Schema;

namespace PetHubApi.Dto.Pet
{
    public class PetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public int BreedId { get; set; }
    }
}
