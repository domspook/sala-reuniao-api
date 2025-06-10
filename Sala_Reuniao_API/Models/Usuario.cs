using System.ComponentModel.DataAnnotations;

namespace Sala_Reuniao_API.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        public ICollection<Reserva>? Reservas { get; set; }
    }
}
