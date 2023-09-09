using Microsoft.EntityFrameworkCore;
using backendINAISO.Models;
using System;
using System.Collections.Generic;

namespace backendINAISO.Data
{
    public class INAISOContextDB : DbContext
    {
        
        public INAISOContextDB(DbContextOptions<INAISOContextDB> options) : base(options)
        {
        }
        public DbSet<Aplicacion> Aplicaciones { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relaciones, claves primarias, etc. (como lo tienes actualmente)
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.Reservas)
                .HasForeignKey(r => r.UsuarioId);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Aplicacion)
                .WithMany(a => a.Reservas)
                .HasForeignKey(r => r.AplicacionId);

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Name = "Usuario1", CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Usuario { Id = 2, Name = "Usuario2", CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Usuario { Id = 3, Name = "Usuario3", CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Usuario { Id = 4, Name = "Usuario4", CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Usuario { Id = 5, Name = "Usuario5", CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now }
            );

            modelBuilder.Entity<Aplicacion>().HasData(
                new Aplicacion { Id = 1, Clase = "a" },
                new Aplicacion { Id = 2, Clase = "b" },
                new Aplicacion { Id = 3, Clase = "c" }
            );

            modelBuilder.Entity<Reserva>().HasData(
                new Reserva { Id = 1, UsuarioId = 1, AplicacionId = 1, FechaInicio = DateTime.Now, FechaFin = DateTime.Now.AddDays(3) },
                new Reserva { Id = 2, UsuarioId = 2, AplicacionId = 1, FechaInicio = DateTime.Now, FechaFin = DateTime.Now.AddDays(4) },
                new Reserva { Id = 3, UsuarioId = 3, AplicacionId = 2, FechaInicio = DateTime.Now, FechaFin = DateTime.Now.AddDays(5) },
                new Reserva { Id = 4, UsuarioId = 4, AplicacionId = 2, FechaInicio = DateTime.Now, FechaFin = DateTime.Now.AddDays(6) },
                new Reserva { Id = 5, UsuarioId = 1, AplicacionId = 3, FechaInicio = DateTime.Now, FechaFin = DateTime.Now.AddDays(7) },
                new Reserva { Id = 6, UsuarioId = 2, AplicacionId = 3, FechaInicio = DateTime.Now, FechaFin = DateTime.Now.AddDays(8) },
                new Reserva { Id = 7, UsuarioId = 3, AplicacionId = 1, FechaInicio = DateTime.Now, FechaFin = DateTime.Now.AddDays(9) },
                new Reserva { Id = 8, UsuarioId = 4, AplicacionId = 1, FechaInicio = DateTime.Now, FechaFin = DateTime.Now.AddDays(10) }
            );
        }
    }
}