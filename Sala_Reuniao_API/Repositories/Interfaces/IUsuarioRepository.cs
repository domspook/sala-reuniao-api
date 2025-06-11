using Sala_Reuniao_API.Models;

namespace Sala_Reuniao_API.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync (int id);
        Task AddAsync (Usuario usuario);
        void Update(Usuario usuario);
        void Delete (Usuario usuario);
    }
}
