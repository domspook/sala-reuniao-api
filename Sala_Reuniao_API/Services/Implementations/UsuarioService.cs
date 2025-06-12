using AutoMapper;
using Sala_Reuniao_API.DTOs.Usuarios;
using Sala_Reuniao_API.Models;
using Sala_Reuniao_API.Repositories.Interfaces;
using Sala_Reuniao_API.Services.Interfaces;

namespace Sala_Reuniao_API.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioReadDTO> CreateAsync(UsuarioCreateDTO usuarioCreateDTO)
        {
           var usuario = _mapper.Map<Usuario>(usuarioCreateDTO);
           await _usuarioRepository.AddAsync(usuario);
           await _usuarioRepository.SaveChangesAsync();
  
            return _mapper.Map<UsuarioReadDTO>(usuario);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                return false;
            }
            _usuarioRepository.Delete(usuario);
            return await _usuarioRepository.SaveChangesAsync();       
        }

        public async Task<UsuarioReadDTO> GetByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            return usuario == null ? null : _mapper.Map<UsuarioReadDTO>(usuario);
        }

        public async Task<IEnumerable<UsuarioReadDTO>> GetllAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UsuarioReadDTO>>(usuarios);
        }

        public async Task<bool> UpdateAsync(int id, UsuarioUpdateDTO usuarioUpdateDTO)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) {  return false; }

            _mapper.Map(usuarioUpdateDTO, usuario);
            _usuarioRepository.Update(usuario);
            await _usuarioRepository.SaveChangesAsync();
            return true;
        }

        public async Task<Usuario?> AuthAsync(string email, string senha)
        {
            return await _usuarioRepository.AuthAsync(email, senha);
        }
    }
}
