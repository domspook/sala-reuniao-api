using System.ComponentModel.DataAnnotations;

namespace Sala_Reuniao_API.DTOs.Salas
{
    public class SalaCreateDTO
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public int Capacidade { get; set; }
    }
}
