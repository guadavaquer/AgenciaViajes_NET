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
        //DbSet es un data set
        public DbSet<Ciudad> ciudades { get; set; }
        public DbSet<Hotel> hoteles { get; set; }
        public DbSet<ReservaHotel> reservaHoteles { get; set; }
        public DbSet<ReservaVuelo> reservaVuelos { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Vuelo> vuelos { get; set; }
        
        //Constructor sin parámetros de la clase AppDbContext
        public AppDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(Properties.Resources.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Nombre de la tabla
            modelBuilder.Entity<Ciudad>()
               .ToTable("Ciudades")
               .HasKey(c => c.ID);

            modelBuilder.Entity<Hotel>()
                .ToTable("Hoteles")
                .HasKey(h => h.idHotel);

           /* modelBuilder.Entity<ReservaHotel>()
               .ToTable("ReservaHoteles")
               .HasKey(rh => rh.ID); 

            modelBuilder.Entity<ReservaVuelo>()
              .ToTable("ReservaVuelos")
              .HasKey(rv => rv.ID); */

            modelBuilder.Entity<Usuario>() 
                .ToTable("Usuarios")
                .HasKey(u => u.ID);

            modelBuilder.Entity<Vuelo>()
                .ToTable("Vuelos")
                .HasKey(v => v.ID);

            //Propiedades de los datos

            modelBuilder.Entity<Ciudad>();

            modelBuilder.Entity<Hotel>();

            modelBuilder.Entity<ReservaHotel>();

            modelBuilder.Entity<ReservaVuelo>();

            modelBuilder.Entity<Usuario>(
                usr =>
                {
                    usr.Property(u => u.DNI).HasColumnType("int");
                    usr.Property(u => u.DNI).IsRequired(true);
                });

            modelBuilder.Entity<Vuelo>();

            modelBuilder.Ignore<Agencia>();
           
        }
    }
}
