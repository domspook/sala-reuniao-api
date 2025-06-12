using Sala_Reuniao_API.Models;
using Sala_Reuniao_API.Repositories.Interfaces;
using Sala_Reuniao_API.Context;
using Microsoft.EntityFrameworkCore;

namespace Sala_Reuniao_API.Repositories.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }

        public void Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }

        public void Delete(Usuario usuario)
        {

            _context.Usuarios.Remove(usuario);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Usuario?> AuthAsync (string email, string senha)
        {
            return await _context.Usuarios.FirstOrDefaultAsync
                (u => u.Email == email &&  u.Senha == senha);
        }
    }
}
