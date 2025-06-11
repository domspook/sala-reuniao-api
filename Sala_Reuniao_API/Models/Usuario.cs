namespace Sala_Reuniao_API.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Cpf { get; set; }

        public string Contato { get; set; }

        public ICollection<Reserva>? Reservas { get; set; }
    }
}
