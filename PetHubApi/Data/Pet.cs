using System.ComponentModel.DataAnnotations.Schema;

namespace PetHubApi.Data
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        [ForeignKey(nameof(BreedId))]
        public int BreedId { get; set; }
        public Breed Breed { get; set; }
    }
}
