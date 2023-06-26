using Microsoft.EntityFrameworkCore;
using PetHubApi.Contracts;
using PetHubApi.Data;

namespace PetHubApi.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private readonly PetAPIDBContext _context;
        public CountryRepository(PetAPIDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Country> GetDetails(int id)
        {
            return await _context.Countries.Include(pet=> pet.Breeds)
                .FirstOrDefaultAsync(country => country.Id == id);
        }
    }
}
