namespace Sala_Reuniao_API.DTOs.Reservas
{
    public class ReservaFilterDTO
    {
        public int? UsuarioId { get; set; }
        public int? SalaId { get; set; }
        public DateTime? Data { get; set; }
        public bool? Ativa { get; set; }
    }
}
