using System.ComponentModel.DataAnnotations;

namespace Sala_Reuniao_API.DTOs.Reservas
{
    public class ReservaCreateDTO
    {
        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int SalaId { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataFim { get; set; }
    }
}
