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

            modelBuilder.Entity<Vuelo>()
                .ToTable("Vuelos")
                .HasKey(v => v.idVuelo);

            modelBuilder.Entity<Usuario>()
               .ToTable("Usuarios")
               .HasKey(u => u.idUsuario);

            //Relaciones entre clases

            //Definición de la relación many to many Usuario -> Hotel
            modelBuilder.Entity<Usuario>()
                .HasMany(U => U.hoteles)
                .WithMany(H => H.usuarios)
                .UsingEntity<ReservaHotel>(
                    erh => erh.HasOne(rh => rh.hotel).WithMany(h => h.reservas).HasForeignKey(r => r.idHotel),
                    erh => erh.HasOne(rh => rh.usuario).WithMany(u => u.reservasHoteles).HasForeignKey(r => r.idUsuario),
                    erh => erh.HasKey(k => new { k.idUsuario, k.idHotel })
                );

            //Definición de la relación many to many Usuario -> Vuelo
            modelBuilder.Entity<Usuario>()
                .HasMany(U => U.vuelos)
                .WithMany(V => V.pasajeros)
                .UsingEntity<ReservaVuelo>(
                    erv => erv.HasOne(rv => rv.vuelo).WithMany(v => v.reservas).HasForeignKey(r => r.idVuelo),
                    erv => erv.HasOne(rv => rv.usuario).WithMany(u => u.reservasVuelos).HasForeignKey(r => r.idUsuario),
                    erv => erv.HasKey(k => new { k.idUsuario, k.idVuelo })
                );

            //Definición de la relación one to many Hotel -> Ciudad
            modelBuilder.Entity<Hotel>()
                .HasOne(H => H.ciudad)
                .WithMany(C => C.hoteles)
                .HasForeignKey(H => H.idCiudad)
                .OnDelete(DeleteBehavior.Cascade
                );
            modelBuilder.Entity<Ciudad>()
                .HasMany(C => C.hoteles)
                .WithOne(H => H.ciudad)
                .HasForeignKey(H => H.idCiudad)
                .OnDelete(DeleteBehavior.Cascade
                );

            //Definición de la relación one to many Vuelo -> Ciudad origen 
            modelBuilder.Entity<Vuelo>()
                .HasOne(v => v.origen)
                .WithMany(c => c.vuelosOrigen)
                .HasForeignKey(v => v.idCiudadOrigen)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Ciudad>()
                .HasMany(c => c.vuelosOrigen)
                .WithOne(v => v.origen)
                .HasForeignKey(v => v.idCiudadOrigen)
                .OnDelete(DeleteBehavior.NoAction);

            //Definición de la relación one to many Vuelo -> Ciudad destino
            modelBuilder.Entity<Vuelo>()
                .HasOne(v => v.destino)
                .WithMany(c => c.vuelosDestino)
                .HasForeignKey(v => v.idCiudadDestino)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Ciudad>()
                .HasMany(c => c.vuelosDestino)
                .WithOne(v => v.destino)
                .HasForeignKey(v => v.idCiudadDestino)
                .OnDelete(DeleteBehavior.NoAction);

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

            modelBuilder.Entity<ReservaHotel>(
                resH =>
                {
                    resH.Property(rh => rh.idHotel).HasColumnType("int");
                    resH.Property(rh => rh.idHotel).IsRequired(true);
                    resH.Property(rh => rh.idUsuario).HasColumnType("int");
                    resH.Property(rh => rh.idUsuario).IsRequired(true);
                    resH.Property(rh => rh.fechaDesde).HasColumnType("datetime");
                    resH.Property(rh => rh.fechaDesde).IsRequired(true);
                    resH.Property(rh => rh.fechaHasta).HasColumnType("datetime");
                    resH.Property(rh => rh.fechaHasta).IsRequired(true);
                    resH.Property(rh => rh.pagado).HasColumnType("int");

                }
                );

            modelBuilder.Entity<ReservaVuelo>(
            resV =>
                {
                    resV.Property(rv => rv.idVuelo).HasColumnType("int");
                    resV.Property(rv => rv.idVuelo).IsRequired(true);
                    resV.Property(rv => rv.idUsuario).HasColumnType("int");
                    resV.Property(rv => rv.idUsuario).IsRequired(true);
                    resV.Property(rv => rv.pagado).HasColumnType("int");

                }
                );

            modelBuilder.Entity<Usuario>(
                usr =>
                {
                    usr.Property(u => u.idUsuario).HasColumnType("int");
                    usr.Property(u => u.idUsuario).IsRequired(true);
                    usr.Property(u => u.dni).HasColumnType("int");
                    usr.Property(u => u.dni).IsRequired(true);
                    usr.Property(u => u.nombre).HasColumnType("varchar(50)");
                    usr.Property(u => u.nombre).IsRequired(true);
                    usr.Property(u => u.apellido).HasColumnType("varchar(50)");
                    usr.Property(u => u.apellido).IsRequired(true);
                    usr.Property(u => u.mail).HasColumnType("varchar(512)");
                    usr.Property(u => u.mail).IsRequired(true);
                    usr.Property(u => u.password).HasColumnType("varchar(50)");
                    usr.Property(u => u.password).IsRequired(true);
                    usr.Property(u => u.intentosFallidos).HasColumnType("int");
                    usr.Property(u => u.esAdmin).HasColumnType("bit");
                    usr.Property(u => u.bloqueado).HasColumnType("bit");
                    usr.Property(u => u.credito).HasColumnType("float");
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


            //Agrego datos de prueba

            modelBuilder.Entity<Ciudad>().HasData(
               new { idCiudad = 1, nombre= "Buenos Aires" },
               new { idCiudad = 2, nombre = "Berlin" });

            modelBuilder.Entity<Hotel>().HasData(
                new { idHotel = 1, nombre = "Four Seasons", capacidad = 150, costo = (double)25000, idCiudad = 1 },
                new { idHotel = 2, nombre = "Gat Point Charlie", capacidad = 200, costo = (double)15000, idCiudad = 2 });

            modelBuilder.Entity<Vuelo>().HasData(
                new { idVuelo = 1, capacidad = 150, costo = (double)600000, fecha= new DateTime(2023, 5, 30), aerolinea ="Aero", avion="LF-5909", idCiudadOrigen = 1, idCiudadDestino=2 },
                new { idVuelo = 2, capacidad = 150, costo = (double)650000, fecha = new DateTime(2023, 6, 20), aerolinea = "Aero", avion = "LF-9501", idCiudadOrigen = 2, idCiudadDestino = 1 },
                new { idVuelo = 3, capacidad = 1, costo = (double)950000, fecha = new DateTime(2024, 8, 10), aerolinea = "Aero", avion = "LF-5958", idCiudadOrigen = 1, idCiudadDestino = 2 },
                new { idVuelo = 4, capacidad = 1, costo = (double)900000, fecha = new DateTime(2024, 2, 24), aerolinea = "Aero", avion = "LF-5965", idCiudadOrigen = 2, idCiudadDestino = 1 },
                new { idVuelo = 5, capacidad = 1, costo = (double)850000, fecha = new DateTime(2024, 5, 31), aerolinea = "Aero", avion = "LF-9531", idCiudadOrigen = 1, idCiudadDestino = 2 });


            modelBuilder.Entity<ReservaHotel>().HasData(

                new { idHotel = 1, idUsuario = 2, fechaDesde = new DateTime(2023,5,30), fechaHasta = new DateTime(2023, 6, 20), pagado = (int)1});

            modelBuilder.Entity<ReservaVuelo>().HasData(
                new { idVuelo = 1, idUsuario = 2, pagado = (int)1 },
                new { idVuelo = 2, idUsuario = 2, pagado = (int)1 });

            modelBuilder.Entity<Usuario>().HasData(
                new { idUsuario = 1, dni = 11222333, nombre = "Admin", apellido = "Administrador", mail = "admin@agencia", password = "12345", intentosFallidos = 0, esAdmin = true, bloqueado = false, credito = (double)0 },
                new { idUsuario = 2, dni = 22333444, nombre = "User", apellido = "Usuario", mail = "user@agencia", password = "56789", intentosFallidos = 1, esAdmin = false, bloqueado = false, credito = (double)15000 });

            modelBuilder.Ignore<Agencia>();
           
        }
    }
}
