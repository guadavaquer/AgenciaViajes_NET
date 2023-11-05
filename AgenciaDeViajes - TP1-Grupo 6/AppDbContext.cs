using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AgenciaDeViajes
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Vuelo> Vuelos { get; set; }
        public DbSet<Hotel> Hoteles { get; set; }

        public AppDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(Properties.Resources.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Nombre de la tabla
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios")
                .HasKey(u => u.ID);

            //Propiedades de los datos
            modelBuilder.Entity<Usuario>(
                usr =>
                {
                    usr.Property(u => u.DNI).HasColumnType("int");
                    usr.Property(u => u.DNI).IsRequired(true);
                });

            modelBuilder.Ignore<Agencia>();
            modelBuilder.Ignore<Ciudad>();
            modelBuilder.Ignore<Hotel>();
            modelBuilder.Ignore<Vuelo>();
            modelBuilder.Ignore<ReservaHotel>();
            modelBuilder.Ignore<ReservaVuelo>();
        }
    }
}
