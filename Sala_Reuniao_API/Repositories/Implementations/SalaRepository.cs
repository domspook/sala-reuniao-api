using Microsoft.EntityFrameworkCore;
using Sala_Reuniao_API.Context;
using Sala_Reuniao_API.Models;
using Sala_Reuniao_API.Repositories.Interfaces;

namespace Sala_Reuniao_API.Repositories.Implementations
{
    public class SalaRepository : ISalaRepository
    {
        private readonly AppDbContext _context;
        public SalaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sala>> GetAllAsync()
        {
            return await _context.Salas.ToListAsync();
        }

        public async Task<Sala?> GetByIdAsync(int id)
        {
            return await _context.Salas.FindAsync(id);
        }

        public async Task AddAsync(Sala sala)
        {
            await _context.Salas.AddAsync(sala);
        }

        public void Update(Sala sala)
        {
            _context.Salas.Update(sala);
        }

        public void Delete(Sala sala)
        {
            _context?.Salas.Remove(sala);
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Salas.AnyAsync(s => s.SalaId == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}