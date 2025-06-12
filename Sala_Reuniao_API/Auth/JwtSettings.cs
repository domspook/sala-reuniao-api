using System.ComponentModel.DataAnnotations;

namespace Sala_Reuniao_API.Auth
{
    public class JwtSettings
    {
        [Required]
        public string SecretKey { get; set; }
        [Required]
        public string Issuer { get; set; }
        [Required]
        public string Audience { get; set; }
        [Required]
        public int ExpirationMinutes { get; set; }
    }
}
