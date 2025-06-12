using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sala_Reuniao_API.Auth;
using Sala_Reuniao_API.Services.Interfaces;

namespace Sala_Reuniao_API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly Token _token;

        public AuthController(IUsuarioService usuarioService, Token token)
        {
            _usuarioService = usuarioService;
            _token = token;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = await _usuarioService.AuthAsync(login.Email, login.Senha);

            if (usuario == null)
            {
                return Unauthorized(new { message = "Email ou senha inválidos." });
            }

            var jtw = _token.GerarToken(usuario);

            return Ok(new
            {
                Token = jtw,
                usuario = new
                {
                    usuario.UsuarioId,
                    usuario.Nome,
                    usuario.Email
                }
            });
        }
    }
}
