using Sala_Reuniao_API.DTOs.Usuarios;

namespace Sala_Reuniao_API.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioReadDTO>> GetllAsync();
        Task<UsuarioReadDTO> GetByIdAsync(int id);
        Task<UsuarioReadDTO> CreateAsync(UsuarioCreateDTO usuarioCreateDTO);
        Task<bool> UpdateAsync (int id, UsuarioUpdateDTO usuarioUpdateDTO);
        Task<bool> DeleteAsync(int id);
    }
}
