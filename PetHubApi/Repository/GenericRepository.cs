using Microsoft.EntityFrameworkCore;
using PetHubApi.Contracts;
using PetHubApi.Data;

namespace PetHubApi.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PetAPIDBContext _context;
        public GenericRepository(PetAPIDBContext context) 
        { 
            _context = context;
        }
        public async Task<T> AddAsync(T addentity)
        {
             await _context.AddAsync(addentity);
            _context.SaveChanges();
            return addentity;
        }

        public async Task DeleteAsync(int? id)
        {
            
                var gotten = await GetAsync(id);
                _context.Set<T>().Remove(gotten);
                _context.SaveChanges();
        }

        public async Task<bool> Exists(int id)
        {
            return await GetAsync(id) != null;
        }  

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            var returnitem = await GetAsync(id);
            if(returnitem is null)
            {
                return null;
            }
            return  returnitem;
        }

        public async Task UpdateAsync(T updateentity)
        {
            _context.Update(updateentity);
            await _context.SaveChangesAsync();
        }
    }
}
