using System.ComponentModel.DataAnnotations;

namespace Sala_Reuniao_API.Models
{
    public class Sala
    {
        public int SalaId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int Capacidade { get; set; }

        public ICollection<Reserva>? Reservas { get; set; }
    }
}
