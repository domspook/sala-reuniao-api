using Sala_Reuniao_API.DTOs.Salas;

namespace Sala_Reuniao_API.Services.Interfaces
{
    public interface ISalaService
    {
        Task<IEnumerable<SalaReadDTO>> GetAllAsync();
        Task<SalaReadDTO?> GetByIdAsync(int id);
        Task<SalaReadDTO?> CreateAsync(SalaCreateDTO salaCreateDTO);
        Task<bool> UpdateAsync(int id, SalaUpdateDTO salaUpdateDTO);
        Task<bool> DeleteAsync(int id);
    }
}
