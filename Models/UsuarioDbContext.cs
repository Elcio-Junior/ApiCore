using Microsoft.EntityFrameworkCore;

namespace ProjetoCoreApi.Models
{
    public class UsuarioDbContext: DbContext
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options)
        {
            
        }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}