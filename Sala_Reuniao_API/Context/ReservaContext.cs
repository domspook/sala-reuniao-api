using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Sala_Reuniao_API.Context
{
    public class ReservaContext : DbContext
    {
        public ReservaContext(DbContextOptions<ReservaContext> options) : base(options)
        {
            
        }
    }
}
