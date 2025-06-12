using Sala_Reuniao_API.Models;

namespace Sala_Reuniao_API.Repositories.Interfaces
{
    public interface IReservaRepository
    {
        Task<IEnumerable<Reserva>> GetAllAsync();
        Task<Reserva?> GetByIdAsync(int id);
        Task AddAsync(Reserva reserva);
        Task<bool> ExistsConflictAsync(int salaId, DateTime dataInicio, DateTime dataFim);
        Task<bool> ExistAsync(int id);
        Task<IEnumerable<Reserva>> GetByUsuarioIdAsync(int usuarioId);
        Task<IEnumerable<Reserva>> GetBySalaIdAsync(int salaId);
        Task CancelAsync(Reserva reserva);
        IQueryable<Reserva> GetQueryable();
    }
}
