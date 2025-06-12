using System.ComponentModel.DataAnnotations;

namespace Sala_Reuniao_API.Auth
{
    public class Login
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
