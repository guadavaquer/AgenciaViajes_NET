using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;

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
               .HasKey(c => c.idCiudad);

            modelBuilder.Entity<Hotel>()
                .ToTable("Hoteles")
                .HasKey(h => h.idHotel);

            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios")
                .HasKey(u => u.idUsuario);

            modelBuilder.Entity<Vuelo>()
                .ToTable("Vuelos")
                .HasKey(v => v.idVuelo);

            //Relaciones entre clases 
            modelBuilder.Entity<Usuario>()
                .HasMany(U => U.hoteles)
                .WithMany(H => H.usuarios)
                .UsingEntity<ReservaHotel>(
                    erh => erh.HasOne(rh => rh.hotel).WithMany(h => h.reservas).HasForeignKey(r => r.idHotel),
                    erh => erh.HasOne(rh => rh.usuario).WithMany(u => u.reservasHoteles).HasForeignKey(r => r.idUsuario),
                    erh => erh.HasKey(k => new { k.idUsuario, k.idHotel })
                );

            modelBuilder.Entity<Usuario>()
                .HasMany(U => U.vuelos)
                .WithMany(V => V.pasajeros)
                .UsingEntity<ReservaVuelo>(
                    erv => erv.HasOne(rv => rv.vuelo).WithMany(v => v.reservas).HasForeignKey(r => r.idVuelo),
                    erv => erv.HasOne(rv => rv.usuario).WithMany(u => u.reservasVuelos).HasForeignKey(r => r.idUsuario),
                    erv => erv.HasKey(k => new { k.idUsuario, k.idVuelo })
                );

            modelBuilder.Entity<Hotel>()
            .HasOne(H => H.ciudad)
            .WithMany(C => C.hoteles)
            .HasForeignKey(H => H.idCiudad)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vuelo>()
            .HasOne(v => v.origen)
            .WithMany(c => c.vuelos)
            .HasForeignKey(v => v.idCiudadOrigen)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vuelo>()
            .HasOne(v => v.destino)
            .WithMany(c => c.vuelos)
            .HasForeignKey(v => v.idCiudadDestino)
            .OnDelete(DeleteBehavior.Cascade);

            //Propiedades de los datos

            modelBuilder.Entity<Ciudad>(
                cdad =>
                {
                    cdad.Property(c => c.idCiudad).HasColumnType("int");
                    cdad.Property(c => c.idCiudad).IsRequired(true);
                    cdad.Property(c => c.nombre).HasColumnType("varchar(512)");
                    cdad.Property(c => c.nombre).IsRequired(true);
                });

            modelBuilder.Entity<Hotel>(
                htel =>
                {
                    htel.Property(h => h.idHotel).HasColumnType("int");
                    htel.Property(h => h.idHotel).IsRequired(true);
                    htel.Property(h => h.nombre).HasColumnType("varchar(512)");
                    htel.Property(h => h.nombre).IsRequired(true);
                    htel.Property(h => h.capacidad).HasColumnType("int");
                    htel.Property(h => h.capacidad).IsRequired(true);
                    htel.Property(h => h.costo).HasColumnType("float");
                    htel.Property(h => h.costo).IsRequired(true);
                });

            modelBuilder.Entity<ReservaHotel>();

            modelBuilder.Entity<ReservaVuelo>();

            modelBuilder.Entity<Usuario>(
                usr =>
                {
                    usr.Property(u => u.idUsuario).HasColumnType("int");
                    usr.Property(u => u.idUsuario).IsRequired(true);
                    usr.Property(u => u.nombre).HasColumnType("varchar(50)");
                    usr.Property(u => u.nombre).IsRequired(true);
                    usr.Property(u => u.mail).HasColumnType("varchar(512)");
                    usr.Property(u => u.mail).IsRequired(true);
                    usr.Property(u => u.password).HasColumnType("varchar(50)");
                    usr.Property(u => u.password).IsRequired(true);
                    usr.Property(u => u.esAdmin).HasColumnType("bit");
                    usr.Property(u => u.bloqueado).HasColumnType("bit");
                });

            modelBuilder.Entity<Vuelo>(
                 vlo =>
                 {
                     vlo.Property(v => v.idVuelo).HasColumnType("int");
                     vlo.Property(v => v.idVuelo).IsRequired(true);
                     vlo.Property(v => v.capacidad).HasColumnType("int");
                     vlo.Property(v => v.capacidad).IsRequired(true);
                     vlo.Property(v => v.costo).HasColumnType("float");
                     vlo.Property(v => v.costo).IsRequired(true);
                     vlo.Property(v => v.aerolinea).HasColumnType("varchar(512)");
                     vlo.Property(v => v.aerolinea).IsRequired(true);
                     vlo.Property(v => v.avion).HasColumnType("varchar(50)");
                     vlo.Property(v => v.avion).IsRequired(true);
                 });
            
                

            modelBuilder.Ignore<Agencia>();
           
        }
    }
}
