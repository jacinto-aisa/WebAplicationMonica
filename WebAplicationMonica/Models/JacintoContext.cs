using Microsoft.EntityFrameworkCore;

namespace WebAplicationMonica.Models
{
    public class JacintoContext : DbContext
    {
        public JacintoContext(DbContextOptions<JacintoContext> options): base(options)
        {
        }


        public DbSet<Curso>? Cursos { get; set; }
        public DbSet<Modulo>? Modulos { get; set; }
    }
}
