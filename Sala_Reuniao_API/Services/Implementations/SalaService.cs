using AutoMapper;
using Sala_Reuniao_API.DTOs.Salas;
using Sala_Reuniao_API.Models;
using Sala_Reuniao_API.Repositories.Implementations;
using Sala_Reuniao_API.Repositories.Interfaces;
using Sala_Reuniao_API.Services.Interfaces;

namespace Sala_Reuniao_API.Services.Implementations
{
    public class SalaService : ISalaService
    {
        private readonly IMapper _mapper;
        private readonly ISalaRepository _salaRepository;

        public SalaService(ISalaRepository salaRepository, IMapper mapper) 
        {

            _salaRepository = salaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SalaReadDTO>> GetAllAsync()
        {
            var salas = await _salaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SalaReadDTO>>(salas);
        }

        public async Task<SalaReadDTO?> GetByIdAsync(int id)
        {
            var sala = await _salaRepository.GetByIdAsync(id);
            return sala == null ? null : _mapper.Map<SalaReadDTO>(sala);
        }

        public async Task<SalaReadDTO?> CreateAsync(SalaCreateDTO salaCreateDTO)
        {
            var sala = _mapper.Map<Sala>(salaCreateDTO);
            await _salaRepository.AddAsync(sala);
            await _salaRepository.SaveChangesAsync();
            return _mapper.Map<SalaReadDTO>(sala);
        }

        public async Task<bool> UpdateAsync(int id, SalaUpdateDTO salaUpdateDTO)
        {
            var sala = await _salaRepository.GetByIdAsync(id);
            if (sala == null)
            {
                return false;
            }

            _mapper.Map(salaUpdateDTO, sala);
            _salaRepository.Update(sala);
            return await _salaRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sala = await _salaRepository.GetByIdAsync(id);
            if (sala == null)
            {
                return false;
            }

            _salaRepository.Delete(sala);
            return await _salaRepository.SaveChangesAsync();
        }   
    }
}
