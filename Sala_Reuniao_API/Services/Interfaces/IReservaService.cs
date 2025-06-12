using Sala_Reuniao_API.DTOs.Reservas;
using Sala_Reuniao_API.Models;
using System.Data;

namespace Sala_Reuniao_API.Services.Interfaces
{
    public interface IReservaService
    {
        Task<IEnumerable<ReservaReadDTO>> GetAllAsync();
        Task<ReservaReadDTO> GetByIdAsync(int id);
        Task<IEnumerable<ReservaReadDTO>> GetByFilterAsync(int? usuarioId, int? salaId, DateTime? data, bool? ativa);
        Task<ReservaReadDTO> CreateAsync (ReservaCreateDTO reservaCreateDTO);
        Task<bool> CancelAsync(int id);
    }
}
