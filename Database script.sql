USE [master]
GO
/****** Object:  Database [AgenciaDeViajes]    Script Date: 29/10/2023 15:37:15 ******/
CREATE DATABASE [AgenciaDeViajes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AgenciaDeViajes', FILENAME = N'/var/opt/mssql/data/AgenciaDeViajes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AgenciaDeViajes_log', FILENAME = N'/var/opt/mssql/data/AgenciaDeViajes_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [AgenciaDeViajes] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AgenciaDeViajes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AgenciaDeViajes] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AgenciaDeViajes] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AgenciaDeViajes] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AgenciaDeViajes] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AgenciaDeViajes] SET ARITHABORT OFF 
GO
ALTER DATABASE [AgenciaDeViajes] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AgenciaDeViajes] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AgenciaDeViajes] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AgenciaDeViajes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AgenciaDeViajes] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AgenciaDeViajes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AgenciaDeViajes] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AgenciaDeViajes] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AgenciaDeViajes] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AgenciaDeViajes] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AgenciaDeViajes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AgenciaDeViajes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AgenciaDeViajes] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AgenciaDeViajes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AgenciaDeViajes] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AgenciaDeViajes] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AgenciaDeViajes] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AgenciaDeViajes] SET RECOVERY FULL 
GO
ALTER DATABASE [AgenciaDeViajes] SET  MULTI_USER 
GO
ALTER DATABASE [AgenciaDeViajes] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AgenciaDeViajes] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AgenciaDeViajes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AgenciaDeViajes] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AgenciaDeViajes] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AgenciaDeViajes] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'AgenciaDeViajes', N'ON'
GO
ALTER DATABASE [AgenciaDeViajes] SET QUERY_STORE = ON
GO
ALTER DATABASE [AgenciaDeViajes] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [AgenciaDeViajes]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 29/10/2023 15:37:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudad](
	[idCiudad] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Ciudades] PRIMARY KEY CLUSTERED 
(
	[idCiudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 29/10/2023 15:37:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[idHotel] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Capacidad] [int] NOT NULL,
	[Costo] [numeric](18, 2) NOT NULL,
	[Vendido] [bit] NOT NULL,
	[idCiudad] [int] NOT NULL,
 CONSTRAINT [PK_Hoteles] PRIMARY KEY CLUSTERED 
(
	[idHotel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservaHotel]    Script Date: 29/10/2023 15:37:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservaHotel](
	[idReservaHotel] [int] IDENTITY(1,1) NOT NULL,
	[idHotel] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[FechaDesde] [date] NOT NULL,
	[FechaHasta] [date] NOT NULL,
	[Pagado] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_ReservaHotel] PRIMARY KEY CLUSTERED 
(
	[idReservaHotel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservaVuelo]    Script Date: 29/10/2023 15:37:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservaVuelo](
	[idReservaVuelo] [int] IDENTITY(1,1) NOT NULL,
	[idVuelo] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[Pagado] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_ReservaVuelo] PRIMARY KEY CLUSTERED 
(
	[idReservaVuelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/10/2023 15:37:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Dni] [bigint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Mail] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Bloqueado] [bit] NOT NULL,
	[Credito] [numeric](18, 2) NOT NULL,
	[EsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vuelo]    Script Date: 29/10/2023 15:37:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vuelo](
	[idVuelo] [int] IDENTITY(1,1) NOT NULL,
	[Capacidad] [int] NOT NULL,
	[Vendido] [bit] NOT NULL,
	[Costo] [numeric](18, 2) NOT NULL,
	[Fecha] [date] NOT NULL,
	[Aerolinea] [varchar](50) NOT NULL,
	[Avion] [varchar](50) NOT NULL,
	[idCiudadOrigen] [int] NOT NULL,
	[idCiudadDestino] [int] NOT NULL,
 CONSTRAINT [PK_Vuelos] PRIMARY KEY CLUSTERED 
(
	[idVuelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Hotel]  WITH CHECK ADD  CONSTRAINT [FK_Hotel_Ciudad] FOREIGN KEY([idCiudad])
REFERENCES [dbo].[Ciudad] ([idCiudad])
GO
ALTER TABLE [dbo].[Hotel] CHECK CONSTRAINT [FK_Hotel_Ciudad]
GO
ALTER TABLE [dbo].[ReservaHotel]  WITH CHECK ADD  CONSTRAINT [FK_ReservaHotel_Hotel] FOREIGN KEY([idHotel])
REFERENCES [dbo].[Hotel] ([idHotel])
GO
ALTER TABLE [dbo].[ReservaHotel] CHECK CONSTRAINT [FK_ReservaHotel_Hotel]
GO
ALTER TABLE [dbo].[ReservaHotel]  WITH CHECK ADD  CONSTRAINT [FK_ReservaHotel_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[ReservaHotel] CHECK CONSTRAINT [FK_ReservaHotel_Usuario]
GO
ALTER TABLE [dbo].[ReservaVuelo]  WITH CHECK ADD  CONSTRAINT [FK_ReservaVuelo_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[ReservaVuelo] CHECK CONSTRAINT [FK_ReservaVuelo_Usuario]
GO
ALTER TABLE [dbo].[ReservaVuelo]  WITH CHECK ADD  CONSTRAINT [FK_ReservaVuelo_Vuelo] FOREIGN KEY([idVuelo])
REFERENCES [dbo].[Vuelo] ([idVuelo])
GO
ALTER TABLE [dbo].[ReservaVuelo] CHECK CONSTRAINT [FK_ReservaVuelo_Vuelo]
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_CiudadDestino] FOREIGN KEY([idCiudadDestino])
REFERENCES [dbo].[Ciudad] ([idCiudad])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK_Vuelo_CiudadDestino]
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_CiudadOrigen] FOREIGN KEY([idCiudadOrigen])
REFERENCES [dbo].[Ciudad] ([idCiudad])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK_Vuelo_CiudadOrigen]
GO


-- Crear un inicio de sesión (login) para el usuario
CREATE LOGIN AppAgencia
    WITH PASSWORD = 'Administrador',
    DEFAULT_DATABASE = AgenciaDeViajes,  -- Puedes cambiar esto si lo deseas
    CHECK_POLICY = OFF;  -- Puedes habilitar políticas de contraseña si lo deseas
GO

-- Asignar el inicio de sesión al rol de servidor de sysadmin (administrador del servidor)
EXEC sp_addsrvrolemember 'AppAgencia', 'sysadmin';
GO

USE [master]
GO
ALTER DATABASE [AgenciaDeViajes] SET  READ_WRITE 
GO


