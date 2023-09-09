using Microsoft.EntityFrameworkCore;
using backendINAISO.Models;

namespace backendINAISO.Data
{
    public class INAISOContextDB : DbContext
    {
        public INAISOContextDB(DbContextOptions<INAISOContextDB> options)
        {
        }

        public DbSet<Aplicacion> Aplicaciones { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.Reservas)
                .HasForeignKey(r => r.UsuarioId);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Aplicacion)
                .WithMany(a => a.Reservas)
                .HasForeignKey(r => r.AplicacionId);
        }
    }
}
