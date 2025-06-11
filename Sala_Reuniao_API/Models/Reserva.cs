using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sala_Reuniao_API.Models
{
    public class Reserva
    {
        public int ReservaId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }

        [Required]
        public int SalaId { get; set; }

        [ForeignKey("SalaId")]
        public Sala Sala { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataFim { get; set; }

        [Required]
        public bool Ativa { get; set; }

    }
}
