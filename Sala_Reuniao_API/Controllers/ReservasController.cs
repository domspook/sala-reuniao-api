using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sala_Reuniao_API.DTOs.Reservas;
using Sala_Reuniao_API.Models;
using Sala_Reuniao_API.Services.Interfaces;

namespace Sala_Reuniao_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly IReservaService _reservaService;
        private readonly IMapper _mapper;

        public ReservasController(IReservaService reservaService, IMapper mapper)
        {
            _reservaService = reservaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaReadDTO>>> GetAll()
        {
            var reservas = await _reservaService.GetAllAsync();
            return Ok(reservas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaReadDTO>> GetByIdAsync(int id)
        {
            var reserva = await _reservaService.GetByIdAsync(id);
            if (reserva == null)
            {
                return NotFound("Reserva não encontrada.");
            }
            return Ok(reserva);
        }

        [HttpPost]
        public async Task<ActionResult<ReservaReadDTO>> Create([FromBody] ReservaCreateDTO reservaCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _reservaService.CreateAsync(reservaCreateDTO);

            if (resultado == null)
            {
                return Conflict("Horário indisponível para reserva ou datas inválidas.");
            }

            return Ok(resultado);
        }

        [HttpPut("cancelar/{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            var sucesso = await _reservaService.CancelAsync(id);
            if (!sucesso)
            {
                return NotFound("Reserva não encontrada ou já cancelada.");
            }

            return NoContent();
        }

        [HttpGet("filtro")]
        public async Task<ActionResult<IEnumerable<ReservaReadDTO>>> Filter([FromQuery] int? usuarioId, [FromQuery] int? salaId, [FromQuery] DateTime? data, [FromQuery] bool? ativa)
        {
            var reservas = await _reservaService.GetByFilterAsync(usuarioId, salaId, data, ativa); 
            return Ok(reservas);
        }
    }
}
