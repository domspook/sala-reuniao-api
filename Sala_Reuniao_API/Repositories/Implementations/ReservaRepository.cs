using Microsoft.EntityFrameworkCore;
using Sala_Reuniao_API.Context;
using Sala_Reuniao_API.Models;
using Sala_Reuniao_API.Repositories.Interfaces;

namespace Sala_Reuniao_API.Repositories.Implementations
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly AppDbContext _context;

        public ReservaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
        }


        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Reservas.AnyAsync(r => r.ReservaId == id);
        }

        public async Task<bool> ExistsConflictAsync(int salaId, DateTime dataInicio, DateTime dataFim)
        {
            return await _context.Reservas.AnyAsync(r =>
                r.SalaId == salaId &&
                r.Ativa &&
                dataInicio < r.DataFim &&
                dataFim > r.DataInicio

            );
        }

        public async Task<IEnumerable<Reserva>> GetAllAsync()
        {
            return await _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Sala)
                .ToListAsync();
        }

        public async Task<Reserva?> GetByIdAsync(int id)
        {
            return await _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Sala)
                .FirstOrDefaultAsync(r => r.ReservaId == id);
        }

        public async Task<IEnumerable<Reserva>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await _context.Reservas
                .Include (r => r.Sala)
                .Where(r => r.UsuarioId == usuarioId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Reserva>> GetBySalaIdAsync(int salaId)
        {
            return await _context.Reservas
                .Include(r => r.Usuario)
                .Where(r => r.SalaId == salaId)
                .ToListAsync();
        }

        public async Task CancelAsync(Reserva reserva)
        {
            reserva.Ativa = false;
            _context.Reservas.Update(reserva);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Reserva> GetQueryable()
        {
            return _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Sala)
                .AsNoTracking()
                .AsQueryable();
        }
    }
}
