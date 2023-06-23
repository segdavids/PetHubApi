namespace PetHubApi.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task DeleteAsync(int? id);
        Task<T> UpdateAsync(T updateentity);
        Task<T> AddAsync(T addentity);
        Task<bool> Exists(int id);
    }
}
