using Microsoft.AspNetCore.Mvc;
using Sala_Reuniao_API.DTOs.Usuarios;
using Sala_Reuniao_API.Services.Interfaces;

namespace Sala_Reuniao_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
      private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioReadDTO>>> GetAll()
        {
            var usuarios = await _usuarioService.GetllAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioReadDTO>> GetById(int id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            if (usuario == null) { return NotFound(); }

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioReadDTO>> Create([FromBody] UsuarioCreateDTO usuarioCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var usuario = await _usuarioService.CreateAsync(usuarioCreateDTO);
            return CreatedAtAction(nameof(GetById), new { id = usuario.UsuarioId }, usuario);
        }

        [HttpPut]
        public async Task<IActionResult> Update (int id, [FromBody] UsuarioUpdateDTO usuarioUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _usuarioService.UpdateAsync(id, usuarioUpdateDTO);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            var deleted = await _usuarioService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}