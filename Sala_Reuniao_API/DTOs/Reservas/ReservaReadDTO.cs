using Sala_Reuniao_API.Models;

namespace Sala_Reuniao_API.DTOs.Reservas
{
    public class ReservaReadDTO
    {
        public int ReservaId { get; set; }

        public int UsuarioId { get; set; }

        public string Usuario { get; set; } = string.Empty;

        public int SalaId { get; set; }

        public string Sala { get; set; } = string.Empty;

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public bool Ativa { get; set; }
    }
}
