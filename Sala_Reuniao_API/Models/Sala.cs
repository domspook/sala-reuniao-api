using System.ComponentModel.DataAnnotations;

namespace Sala_Reuniao_API.Models
{
    public class Sala
    {
        public int SalaId { get; set; }

        public string Nome { get; set; }

        public int Capacidade { get; set; }

        public ICollection<Reserva>? Reservas { get; set; }
    }
}
