USE [master]
GO
/****** Object:  Database [MiBanco]    Script Date: 10/9/2023 10:53:17 PM ******/
CREATE DATABASE [MiBanco] ON  PRIMARY 
( NAME = N'MiBanco', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MiBanco.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MiBanco_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MiBanco_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MiBanco].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MiBanco] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MiBanco] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MiBanco] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MiBanco] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MiBanco] SET ARITHABORT OFF 
GO
ALTER DATABASE [MiBanco] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MiBanco] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MiBanco] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MiBanco] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MiBanco] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MiBanco] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MiBanco] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MiBanco] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MiBanco] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MiBanco] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MiBanco] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MiBanco] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MiBanco] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MiBanco] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MiBanco] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MiBanco] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MiBanco] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MiBanco] SET RECOVERY FULL 
GO
ALTER DATABASE [MiBanco] SET  MULTI_USER 
GO
ALTER DATABASE [MiBanco] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MiBanco] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MiBanco', N'ON'
GO
USE [MiBanco]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [MiBanco]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 10/9/2023 10:53:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[NumeroContacto] [varchar](15) NOT NULL,
	[Ocupacion] [varchar](75) NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tarjeta]    Script Date: 10/9/2023 10:53:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjeta](
	[TarjetaId] [int] IDENTITY(1,1) NOT NULL,
	[TipoTarjetaId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[Banco] [varchar](50) NOT NULL,
	[NumeroTarjeta] [varchar](15) NOT NULL,
	[MesVence] [int] NOT NULL,
	[AnioVence] [int] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TarjetaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoTarjeta]    Script Date: 10/9/2023 10:53:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoTarjeta](
	[TipoTarjetaId] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](25) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoTarjetaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Apellido], [NumeroContacto], [Ocupacion], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (1, N'Jesus Nazare', N'Soriano Sepulveda', N'8296740526', N'Analista Programador Senior', CAST(N'2023-10-07T16:31:30.477' AS DateTime), CAST(N'2023-10-09T19:28:34.730' AS DateTime), 1)
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Apellido], [NumeroContacto], [Ocupacion], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (2, N'Jose Antonio', N'Soriano', N'8297405213', N'Electricista endustrial', CAST(N'2023-10-08T16:24:15.867' AS DateTime), NULL, 1)
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Apellido], [NumeroContacto], [Ocupacion], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (3, N'Dani', N'Sepulveda', N'8296740527', N'Gerente', CAST(N'2023-10-08T16:29:32.060' AS DateTime), NULL, 1)
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Apellido], [NumeroContacto], [Ocupacion], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (4, N'Ismael', N'Soriano Sepulveda', N'8292343241', N'Supervisor', CAST(N'2023-10-08T16:32:47.467' AS DateTime), NULL, 1)
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Apellido], [NumeroContacto], [Ocupacion], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (5, N'Loida Emilia', N'De Soriano Peña', N'8297405213', N'Licenciada en magisterio', CAST(N'2023-10-08T21:06:28.320' AS DateTime), NULL, 1)
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Apellido], [NumeroContacto], [Ocupacion], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (6, N'Emiliano de jesus', N'Soriano Peña', N'8296740527', N'Pelotero Grande Ligas', CAST(N'2023-10-08T21:11:24.250' AS DateTime), NULL, 1)
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Apellido], [NumeroContacto], [Ocupacion], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (7, N'Loennys', N'Soriano Peña', N'8292343241', N'VP del banco central', CAST(N'2023-10-08T21:19:45.180' AS DateTime), NULL, 1)
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Apellido], [NumeroContacto], [Ocupacion], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (8, N'Alexandra', N'Soriano Sepulveda', N'8296740526', N'Maestra docente', CAST(N'2023-10-09T15:42:49.433' AS DateTime), NULL, 1)
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Apellido], [NumeroContacto], [Ocupacion], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (9, N'Ramona', N'De Soriano Sepulvedad ', N'8292343241', N'Pastora', CAST(N'2023-10-09T15:46:06.207' AS DateTime), CAST(N'2023-10-09T15:46:24.490' AS DateTime), 1)
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Apellido], [NumeroContacto], [Ocupacion], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (10, N'Dania', N'Cespedes', N'8292343241', N'Gerente', CAST(N'2023-10-09T16:20:01.220' AS DateTime), CAST(N'2023-10-09T20:32:07.753' AS DateTime), 1)
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Apellido], [NumeroContacto], [Ocupacion], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (11, N'Maximina', N'Garcia', N'8296585285', N'Gerente', CAST(N'2023-10-09T20:44:13.020' AS DateTime), NULL, 1)
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Apellido], [NumeroContacto], [Ocupacion], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (12, N'Juan', N'Perez', N'8296742585', N'Coronel', CAST(N'2023-10-09T20:47:19.750' AS DateTime), NULL, 1)
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Apellido], [NumeroContacto], [Ocupacion], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (13, N'Tomas', N'de nazare', N'8297422556', N'Profecta ', CAST(N'2023-10-09T22:37:23.837' AS DateTime), CAST(N'2023-10-09T22:38:33.973' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
SET IDENTITY_INSERT [dbo].[Tarjeta] ON 

INSERT [dbo].[Tarjeta] ([TarjetaId], [TipoTarjetaId], [ClienteId], [Banco], [NumeroTarjeta], [MesVence], [AnioVence], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (1, 1, 1, N'Ban reservas', N'12345', 5, 2024, CAST(N'2023-10-09T14:42:55.010' AS DateTime), NULL, 1)
INSERT [dbo].[Tarjeta] ([TarjetaId], [TipoTarjetaId], [ClienteId], [Banco], [NumeroTarjeta], [MesVence], [AnioVence], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (2, 2, 1, N'BHD Leon', N'32112125522', 3, 2027, CAST(N'2023-10-09T15:18:11.907' AS DateTime), NULL, 1)
INSERT [dbo].[Tarjeta] ([TarjetaId], [TipoTarjetaId], [ClienteId], [Banco], [NumeroTarjeta], [MesVence], [AnioVence], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (3, 1, 1, N'Banco ademy', N'742556', 7, 2024, CAST(N'2023-10-09T15:39:55.900' AS DateTime), NULL, 1)
INSERT [dbo].[Tarjeta] ([TarjetaId], [TipoTarjetaId], [ClienteId], [Banco], [NumeroTarjeta], [MesVence], [AnioVence], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (4, 1, 9, N'Ban reservasssss', N'12345', 3, 3, CAST(N'2023-10-09T15:46:42.620' AS DateTime), NULL, 1)
INSERT [dbo].[Tarjeta] ([TarjetaId], [TipoTarjetaId], [ClienteId], [Banco], [NumeroTarjeta], [MesVence], [AnioVence], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (5, 1, 10, N'Asociacion Nacionar de ahorros y prestamos', N'87424258', 3, 2024, CAST(N'2023-10-09T18:20:03.443' AS DateTime), NULL, 1)
INSERT [dbo].[Tarjeta] ([TarjetaId], [TipoTarjetaId], [ClienteId], [Banco], [NumeroTarjeta], [MesVence], [AnioVence], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (6, 2, 1, N'Banco santa cruz', N'123457', 8, 2024, CAST(N'2023-10-09T19:43:15.090' AS DateTime), NULL, 1)
INSERT [dbo].[Tarjeta] ([TarjetaId], [TipoTarjetaId], [ClienteId], [Banco], [NumeroTarjeta], [MesVence], [AnioVence], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (7, 1, 12, N'Ban reservas', N'32112125524', 11, 2030, CAST(N'2023-10-09T20:48:02.440' AS DateTime), NULL, 1)
INSERT [dbo].[Tarjeta] ([TarjetaId], [TipoTarjetaId], [ClienteId], [Banco], [NumeroTarjeta], [MesVence], [AnioVence], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (8, 1, 11, N'BHD Leon', N'32112125527', 7, 2024, CAST(N'2023-10-09T22:22:06.830' AS DateTime), NULL, 1)
INSERT [dbo].[Tarjeta] ([TarjetaId], [TipoTarjetaId], [ClienteId], [Banco], [NumeroTarjeta], [MesVence], [AnioVence], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (9, 1, 13, N'BHD Leon', N'123541782', 5, 2024, CAST(N'2023-10-09T22:38:18.880' AS DateTime), NULL, 1)
INSERT [dbo].[Tarjeta] ([TarjetaId], [TipoTarjetaId], [ClienteId], [Banco], [NumeroTarjeta], [MesVence], [AnioVence], [FechaRegistro], [FechaModificacion], [Estado]) VALUES (10, 1, 5, N'Ban reservas', N'39852177', 8, 2024, CAST(N'2023-10-09T22:43:36.390' AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[Tarjeta] OFF
SET IDENTITY_INSERT [dbo].[TipoTarjeta] ON 

INSERT [dbo].[TipoTarjeta] ([TipoTarjetaId], [Tipo], [FechaRegistro], [FechaModificacion]) VALUES (1, N'Debito', CAST(N'2023-10-09T08:52:32.150' AS DateTime), NULL)
INSERT [dbo].[TipoTarjeta] ([TipoTarjetaId], [Tipo], [FechaRegistro], [FechaModificacion]) VALUES (2, N'Credito', CAST(N'2023-10-09T08:52:32.150' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[TipoTarjeta] OFF
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Tarjeta] ADD  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  StoredProcedure [dbo].[SPC_GUARDAR_CLIENTE]    Script Date: 10/9/2023 10:53:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SPC_GUARDAR_CLIENTE]
(	
 @ClienteId INT,
 @Nombre VARCHAR(50),
 @Apellido VARCHAR(50),
 @NumeroContacto VARCHAR(15),
 @Ocupacion VARCHAR(75) NULL,
 @Estado bit NULL
 )

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF @ClienteId <= 0

	
INSERT INTO [dbo].[Cliente]
           ([Nombre]
           ,[Apellido]
           ,[NumeroContacto]
           ,[Ocupacion]
		   ,Estado 
           ,[FechaRegistro]
           )
     VALUES
           (@Nombre
           ,@Apellido
           ,@NumeroContacto
           ,@Ocupacion
		   ,@Estado
           ,GETDATE()
           )    
ELSE

UPDATE [dbo].[Cliente] 
  SET  Nombre = @Nombre,
       Apellido = @Apellido,
	   NumeroContacto = @NumeroContacto,
	   Estado = @Estado,
	   FechaModificacion = GETDATE()
	  WHERE ClienteId = @ClienteId
	    

END

GO
/****** Object:  StoredProcedure [dbo].[SPC_GUARDAR_TARJETA]    Script Date: 10/9/2023 10:53:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,JESUS SORIANO>
-- Create date: <Create 09-10-2023>
-- Description:	<Description, Registro y actualizacion de tarjetas>
-- =============================================
CREATE PROCEDURE [dbo].[SPC_GUARDAR_TARJETA]
(	
 @TarjetaId INT,
 @TipoTarjetaId INT,
 @ClienteId INT,
 @Banco  VARCHAR(50),
 @Numero VARCHAR(15),
 @MesVence INT,
 @AnioVence INT
 )

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF @TarjetaId <= 0

    
INSERT INTO [dbo].[Tarjeta]
           ([TipoTarjetaId]
           ,[ClienteId]
           ,[Banco]
           ,[NumeroTarjeta]
           ,[MesVence]
           ,[AnioVence]
           ,[FechaRegistro]
           ,[FechaModificacion]
           )
     VALUES
           (@TipoTarjetaId
           ,@ClienteId
           ,@Banco
           ,@Numero
           ,@MesVence
           ,@AnioVence
           ,GETDATE()
           ,NULL
           )	


ELSE

UPDATE [dbo].[Tarjeta] 
  SET       [TipoTarjetaId] = @TipoTarjetaId           
           ,[Banco] = @Banco
           ,[NumeroTarjeta] = @Numero
           ,[MesVence] = @MesVence
           ,[AnioVence] = @AnioVence
	  WHERE TarjetaId = @TarjetaId
	    

END

GO
/****** Object:  StoredProcedure [dbo].[SPC_PAGINACION_CLIENTE]    Script Date: 10/9/2023 10:53:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Author:  <Jesus Soriano>        
-- Create date: <08/10/2023>        
-- Description: <Busca los clientes de forma paginada>   
CREATE  PROCEDURE [dbo].[SPC_PAGINACION_CLIENTE]  
   @CampoBusqueda VARCHAR(50) = NULL,      
   @LengthPagina INT,        
   @NumPagina INT       
AS        
BEGIN        
 -- SET NOCOUNT ON added to prevent extra result sets from        
 -- interfering with SELECT statements.        
 SET NOCOUNT ON;        
         
  DECLARE @TotalRegistro INT    
  --Busco el total de registro    
  SELECT  @TotalRegistro = COUNT( DISTINCT ClienteId)        
      FROM Cliente      
     WHERE (Nombre LIKE '%'+@CampoBusqueda+'%' OR @CampoBusqueda IS NULL)      
        OR (Apellido LIKE '%'+@CampoBusqueda+'%' OR @CampoBusqueda IS NULL);          
         
     --Busco los datos en general    
WITH paginacion as         
 (      
      
 SELECT        
          ROW_NUMBER() OVER(ORDER BY clienteid) as Num,      
          clienteid,
		  Nombre,       
	      Apellido,       
	      NumeroContacto,            
	      Ocupacion,
		  Estado,	      
	     @TotalRegistro AS TotaCount    
 FROM    Cliente             
 WHERE  (Nombre LIKE '%'+@CampoBusqueda+'%' OR @CampoBusqueda IS NULL)      
     OR (Apellido LIKE '%'+@CampoBusqueda+'%' OR @CampoBusqueda IS NULL)   
               
 )    --Selecciono los datos paginados    
   SELECT num,        
          clienteid AS Codigo,
		  Nombre,       
	      Apellido,       
	      NumeroContacto,            
	      Ocupacion,   
		  Estado,	
          TotaCount AS TotalRegistro                
   FROM paginacion        
   WHERE         
         Num BETWEEN (@NumPagina -1)* (@LengthPagina) + 1         
            AND @NumPagina * @LengthPagina         
   ORDER BY clienteid        
         
END   
GO
USE [master]
GO
ALTER DATABASE [MiBanco] SET  READ_WRITE 
GO
