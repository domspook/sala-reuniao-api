using System.ComponentModel.DataAnnotations;

namespace Sala_Reuniao_API.DTOs.Usuarios
{
    public class UsuarioCreateDTO
    {
        [Required]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required, RegularExpression(@"\d{3}\.\d{3}\.\d{3}-\d{2}", ErrorMessage = "CPF inválido")]
        public string Cpf { get; set; }

        [Required, RegularExpression(@"^\(\d{2}\)\s?\d{4,5}-\d{4}$", ErrorMessage = "Contato inválido. Ex: (99) 99999-9999")]
        public string Contato { get; set; }
    }
}
