using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sala_Reuniao_API.Context;
using Sala_Reuniao_API.DTOs.Usuarios;
using Sala_Reuniao_API.Models;
using Sala_Reuniao_API.Services.Interfaces;

namespace Sala_Reuniao_API.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UsuarioService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UsuarioReadDTO> CreateAsync(UsuarioCreateDTO usuarioCreateDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioCreateDTO);
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return _mapper.Map<UsuarioReadDTO>(usuario);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioReadDTO> GetByIdAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            return usuario == null ? null : _mapper.Map<UsuarioReadDTO>(usuario);
        }

        public async Task<IEnumerable<UsuarioReadDTO>> GetllAsync()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return _mapper.Map<IEnumerable<UsuarioReadDTO>>(usuarios);
        }

        public async Task<bool> UpdateAsync(int id, UsuarioUpdateDTO usuarioUpdateDTO)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) {  return false; }

            _mapper.Map(usuarioUpdateDTO, usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
