using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sala_Reuniao_API.DTOs.Reservas;
using Sala_Reuniao_API.Models;
using Sala_Reuniao_API.Repositories.Interfaces;
using Sala_Reuniao_API.Services.Interfaces;
using System.Data;

namespace Sala_Reuniao_API.Services.Implementations
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IMapper _mapper;

        public ReservaService(IReservaRepository reservaRepository, IMapper mapper)
        {
            _reservaRepository = reservaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReservaReadDTO>> GetAllAsync()
        {
            var reservas = await _reservaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReservaReadDTO>>(reservas);
        }

        public async Task<ReservaReadDTO?> GetByIdAsync(int id)
        {
            var reserva = await _reservaRepository.GetByIdAsync(id);
            return reserva == null ? null : _mapper.Map<ReservaReadDTO>(reserva);
        }

        public async Task<IEnumerable<ReservaReadDTO>> GetByFilterAsync(int? usuarioId, int? salaId, DateTime? data, bool? ativa)
        {
            var query = _reservaRepository.GetQueryable();

            if (usuarioId.HasValue)
            {
                query = query.Where(r => r.UsuarioId == usuarioId.Value);
            }

            if (salaId.HasValue)
            {
                query = query.Where(r => r.SalaId == salaId.Value);
            }

            if (data.HasValue)
            {
                var inicioIntervalo = data.Value;
                var fimIntervalo = inicioIntervalo.AddHours(1);

                query = query.Where(r =>
                    (r.DataInicio >= inicioIntervalo && r.DataInicio < fimIntervalo) ||
                    (r.DataFim > inicioIntervalo && r.DataFim <= fimIntervalo) ||
                    (r.DataInicio <= inicioIntervalo && r.DataFim >= fimIntervalo));
            }

            if (ativa.HasValue)
            {
                query = query.Where(r => r.Ativa == ativa.Value);
            }

            var resultado =  await query.ToListAsync();

            return _mapper.Map<IEnumerable<ReservaReadDTO>>(resultado);
        }

        public async Task<ReservaReadDTO> CreateAsync(ReservaCreateDTO reservaCreateDTO)
        {
            if (reservaCreateDTO.DataInicio.Date != reservaCreateDTO.DataFim.Date)
            {
                throw new InvalidOperationException("A reserva deve iniciar e terminar no mesmo dia.");
            }

            bool temConflito = await _reservaRepository.ExistsConflictAsync(reservaCreateDTO.SalaId, reservaCreateDTO.DataInicio, reservaCreateDTO.DataFim);

            if (temConflito)
            {
                throw new InvalidOperationException("Conflito de horário: já existe uma reserva para essa sala nesse período.");
            }

            var reserva = _mapper.Map<Reserva>(reservaCreateDTO);
            reserva.Ativa = true;

            await _reservaRepository.AddAsync(reserva);
            var reservaCompleta = await _reservaRepository.GetByIdAsync(reserva.ReservaId);

            return _mapper.Map<ReservaReadDTO>(reservaCompleta);
        }

        public async Task<bool> CancelAsync(int id)
        {
            var reserva = await _reservaRepository.GetByIdAsync(id);

            if(reserva == null || !reserva.Ativa)
            {
                return false;
            }

            await _reservaRepository.CancelAsync(reserva);
            return true;
        }

    }
}
