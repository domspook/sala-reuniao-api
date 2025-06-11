using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sala_Reuniao_API.Models
{
    public class Reserva
    {
        public int ReservaId { get; set; }

        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }

        public int SalaId { get; set; }

        [ForeignKey("SalaId")]
        public Sala Sala { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public bool Ativa { get; set; }

    }
}
