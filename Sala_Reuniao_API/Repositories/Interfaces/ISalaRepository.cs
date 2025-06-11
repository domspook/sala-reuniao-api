using Sala_Reuniao_API.Models;

namespace Sala_Reuniao_API.Repositories.Interfaces
{
    public interface ISalaRepository
    {
        Task<IEnumerable<Sala>> GetAllAsync();
        Task<Sala?> GetByIdAsync(int it);
        Task AddAsync(Sala sala);
        void Update (Sala sala);
        void Delete(Sala sala);
        Task<bool> ExistAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
