using Microsoft.AspNetCore.Mvc;
using Sala_Reuniao_API.DTOs.Salas;
using Sala_Reuniao_API.Services.Interfaces;

namespace Sala_Reuniao_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalasController : ControllerBase
    {
        private readonly ISalaService _salaService;

        public SalasController(ISalaService salaService)
        {
            _salaService = salaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalaReadDTO>>> GetAll()
        {
            var salas = await _salaService.GetAllAsync();
            return Ok(salas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalaReadDTO>> GetById(int id)
        {
            var sala = await _salaService.GetByIdAsync(id);
            if (sala == null)
            {
                return NotFound(new { message = "Sala não encontrada" });
            }

            return Ok(sala);
        }

        [HttpPost]
        public async Task<ActionResult<SalaCreateDTO>> Create(SalaCreateDTO salaCreateDTO)
        {
            var sala = await _salaService.CreateAsync(salaCreateDTO);
            return CreatedAtAction(nameof(GetById), new { id = sala?.SalaId }, sala);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update (int id, SalaUpdateDTO salaUpdateDTO)
        {
            var updated = await _salaService.UpdateAsync(id, salaUpdateDTO);
            if (!updated)
            {
                return NotFound(new { message = "Sala não encontrada para atuãlização"});
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            var deleted = await _salaService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound(new { message = "Sala não encontrada para exclusão"});
            }

            return NoContent();
        }
    }
}
