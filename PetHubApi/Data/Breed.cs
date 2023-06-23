using System.ComponentModel.DataAnnotations.Schema;

namespace PetHubApi.Data
{
    public class Breed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(CountryId))]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public virtual IList<Pet> Pets { get; set; }
    }

   
}