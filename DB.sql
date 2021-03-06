USE [master]
GO
/****** Object:  Database [SistemaParqueo]    Script Date: 5/21/2018 11:06:11 AM ******/
CREATE DATABASE [SistemaParqueo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SistemaParqueo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SistemaParqueo.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SistemaParqueo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SistemaParqueo_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SistemaParqueo] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SistemaParqueo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SistemaParqueo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SistemaParqueo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SistemaParqueo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SistemaParqueo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SistemaParqueo] SET ARITHABORT OFF 
GO
ALTER DATABASE [SistemaParqueo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SistemaParqueo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SistemaParqueo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SistemaParqueo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SistemaParqueo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SistemaParqueo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SistemaParqueo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SistemaParqueo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SistemaParqueo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SistemaParqueo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SistemaParqueo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SistemaParqueo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SistemaParqueo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SistemaParqueo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SistemaParqueo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SistemaParqueo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SistemaParqueo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SistemaParqueo] SET RECOVERY FULL 
GO
ALTER DATABASE [SistemaParqueo] SET  MULTI_USER 
GO
ALTER DATABASE [SistemaParqueo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SistemaParqueo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SistemaParqueo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SistemaParqueo] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SistemaParqueo] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SistemaParqueo]
GO
/****** Object:  Table [dbo].[EMPRESA]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMPRESA](
	[id_empresa] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL CONSTRAINT [DF_EMPRESA_nombre]  DEFAULT ('Nombre empresa'),
	[direccion] [varchar](200) NULL CONSTRAINT [DF_EMPRESA_direccion]  DEFAULT ('Direccion empresa'),
	[telefono] [varchar](11) NULL CONSTRAINT [DF_EMPRESA_telefono]  DEFAULT ('Telefono'),
	[correo] [varchar](50) NULL CONSTRAINT [DF_EMPRESA_correo]  DEFAULT ('correo'),
 CONSTRAINT [PK_EMPRESA] PRIMARY KEY CLUSTERED 
(
	[id_empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ENT_MENUDO]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ENT_MENUDO](
	[id_cambio] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[id_usuario] [int] NOT NULL,
	[id_turno] [int] NOT NULL,
	[monto] [float] NOT NULL,
 CONSTRAINT [PK_ENTRADA_MENUDO] PRIMARY KEY CLUSTERED 
(
	[id_cambio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ENTSAL]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ENTSAL](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[estacion_ent] [varchar](5) NULL,
	[fecha_ent] [date] NULL,
	[hora_ent] [time](0) NULL,
	[estacion_sal] [varchar](5) NULL,
	[fecha_sal] [date] NULL,
	[hora_sal] [time](0) NULL,
	[codigo_barra] [varchar](15) NULL,
	[id_usuario] [int] NULL,
	[estado] [bit] NULL CONSTRAINT [DF_ENTSAL_estado]  DEFAULT ((0)),
	[id_turno] [tinyint] NULL,
	[monto] [float] NULL CONSTRAINT [DF_ENTSAL_monto]  DEFAULT ((0)),
	[img] [varbinary](max) NULL,
	[tiempo] [int] NULL CONSTRAINT [DF_ENTSAL_tiempo]  DEFAULT ((0)),
	[tipo_ticket] [varchar](1) NULL CONSTRAINT [DF_ENTSAL_tipo_ticket]  DEFAULT ('A'),
 CONSTRAINT [PK_ENTSAL] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ESTACION]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ESTACION](
	[id_estacion] [tinyint] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_ESTACION] PRIMARY KEY CLUSTERED 
(
	[id_estacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_LOGIN]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_LOGIN](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NULL,
	[user_break] [tinyint] NULL CONSTRAINT [DF_LOG_LOGIN_user_break]  DEFAULT ((0)),
	[session_close] [tinyint] NULL CONSTRAINT [DF_LOG_LOGIN_session_close]  DEFAULT ((0)),
	[estacion] [varchar](50) NULL,
	[session_started] [datetime] NULL CONSTRAINT [DF_LOG_LOGIN_session_started]  DEFAULT (CONVERT([datetime2](0),getdate())),
	[session_finished] [datetime] NULL,
	[total_automatic] [float] NULL CONSTRAINT [DF_LOG_LOGIN_total_automatic]  DEFAULT ((0)),
	[total_manual] [float] NULL CONSTRAINT [DF_LOG_LOGIN_total_manual]  DEFAULT ((0)),
	[total_lost] [float] NULL CONSTRAINT [DF_LOG_LOGIN_total_lost]  DEFAULT ((0)),
	[total] [float] NULL CONSTRAINT [DF_LOG_LOGIN_total]  DEFAULT ((0)),
 CONSTRAINT [PK_LOG_LOGIN] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOST_TICKET]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOST_TICKET](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NULL,
	[nombre] [varchar](100) NULL,
	[cedula] [varchar](20) NULL,
	[placa] [varchar](50) NULL,
	[id_turno] [int] NULL,
	[id_usuario] [int] NULL,
	[monto] [float] NULL CONSTRAINT [DF_LOST_TICKET_monto]  DEFAULT ((0)),
	[estacion] [varchar](5) NULL,
 CONSTRAINT [PK_LOST_TICKET] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SETTINGS_ADM]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SETTINGS_ADM](
	[precioTicketPerdido] [float] NOT NULL CONSTRAINT [DF_SETTINGS_ADM_precioTicketPerdido]  DEFAULT ((0)),
	[promocion] [varchar](200) NULL,
	[activated] [bit] NOT NULL CONSTRAINT [DF_SETTINGS_ADM_activated]  DEFAULT ((0))
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SETTINGS_ENT]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SETTINGS_ENT](
	[defaultPrinter] [varchar](100) NULL,
	[byPassLoopEntrada] [bit] NOT NULL CONSTRAINT [DF_SETTINGS_ENT_byPassLoopEntrada]  DEFAULT ((0)),
	[byPassAdam] [bit] NOT NULL CONSTRAINT [DF_SETTINGS_ENT_byPassAdam]  DEFAULT ((0)),
	[byPassBrazoEntrada] [bit] NOT NULL CONSTRAINT [DF_SETTINGS_ENT_byPassBrazoEntrada]  DEFAULT ((0)),
	[AdamIp] [varchar](50) NOT NULL CONSTRAINT [DF_SETTINGS_ENT_AdamIp]  DEFAULT ('10.0.0.12'),
	[AdamPort] [int] NOT NULL CONSTRAINT [DF_SETTINGS_ENT_AdamPort]  DEFAULT ((502)),
	[EstacionNombre] [varchar](50) NOT NULL CONSTRAINT [DF_SETTINGS_ENT_EstacionNombre]  DEFAULT ('Nombre Estación'),
	[EstacionNumero] [varchar](50) NOT NULL,
	[SuperUserPass] [varchar](50) NOT NULL CONSTRAINT [DF_SETTINGS_ENT_SuperUserPass]  DEFAULT ('LEAPARKING'),
	[InputLoopEntrada] [varchar](50) NOT NULL CONSTRAINT [DF_SETTINGS_ENT_InputLoopEntrada]  DEFAULT ((1)),
	[InputPushButton] [varchar](50) NOT NULL CONSTRAINT [DF_SETTINGS_ENT_InputPushButton]  DEFAULT ((2)),
	[InputLoopBrazo] [varchar](50) NOT NULL CONSTRAINT [DF_SETTINGS_ENT_InputLoopBrazo]  DEFAULT ((3)),
	[OutputAbrirBrazo] [varchar](50) NOT NULL CONSTRAINT [DF_SETTINGS_ENT_OutputAbrirBrazo]  DEFAULT ((1)),
	[byPassPaperPresenter] [bit] NOT NULL CONSTRAINT [DF_SETTINGS_ENT_byPassPaperPresenter]  DEFAULT ((0)),
 CONSTRAINT [EstacionUnique] UNIQUE NONCLUSTERED 
(
	[EstacionNumero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SETTINGS_SAL]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SETTINGS_SAL](
	[defaultPrinter] [varchar](100) NOT NULL CONSTRAINT [DF_SETTINGS_SAL_defaultPrinter]  DEFAULT (''),
	[byPassLoopSalida] [bit] NOT NULL CONSTRAINT [DF_SETTINGS_SAL_byPassLoopSalida]  DEFAULT ((0)),
	[byPassAdam] [bit] NOT NULL CONSTRAINT [DF_SETTINGS_SAL_byPassAdam]  DEFAULT ((0)),
	[AdamIp] [varchar](50) NOT NULL CONSTRAINT [DF_SETTINGS_SAL_AdamIp]  DEFAULT ('10.0.0.12'),
	[AdamPort] [int] NOT NULL CONSTRAINT [DF_SETTINGS_SAL_AdamPort]  DEFAULT ((502)),
	[EstacionNombre] [varchar](100) NOT NULL CONSTRAINT [DF_SETTINGS_SAL_EstacionNombre]  DEFAULT ('Nombre Estacion'),
	[EstacionNumero] [varchar](50) NOT NULL,
	[SuperUserPass] [varchar](50) NOT NULL CONSTRAINT [DF_SETTINGS_SAL_SuperUserPass]  DEFAULT ('LEAPARKING'),
	[InputLoopSalida] [varchar](50) NOT NULL CONSTRAINT [DF_SETTINGS_SAL_InputLoopSalida]  DEFAULT ((1)),
	[OutputAbrirBrazo] [varchar](50) NOT NULL CONSTRAINT [DF_SETTINGS_SAL_OutputAbrirBrazo]  DEFAULT ((1)),
 CONSTRAINT [EstacionUniqueSal] UNIQUE NONCLUSTERED 
(
	[EstacionNumero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[STATUS_ENT]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STATUS_ENT](
	[printerOffline] [bit] NOT NULL CONSTRAINT [DF_STATUS_ENT_printerOffline]  DEFAULT ((1)),
	[printerPaperJammed] [bit] NOT NULL CONSTRAINT [DF_STATUS_ENT_printerPaperJammed]  DEFAULT ((1)),
	[printerOutOfPaper] [bit] NOT NULL CONSTRAINT [DF_STATUS_ENT_printerOutOfPaper]  DEFAULT ((1)),
	[printerDoorOpened] [bit] NOT NULL CONSTRAINT [DF_STATUS_ENT_printerDoorOpened]  DEFAULT ((1)),
	[printerError] [bit] NOT NULL CONSTRAINT [DF_STATUS_ENT_printerPrinting]  DEFAULT ((0)),
	[adamOnline] [bit] NOT NULL CONSTRAINT [DF_STATUS_ENT_adamOnline]  DEFAULT ((0)),
	[adamInput1] [bit] NOT NULL CONSTRAINT [DF_STATUS_ENT_adamInput1]  DEFAULT ((0)),
	[adamInput2] [bit] NOT NULL CONSTRAINT [DF_STATUS_ENT_adamInput2]  DEFAULT ((0)),
	[adamInput3] [bit] NOT NULL CONSTRAINT [DF_STATUS_ENT_adamInput3]  DEFAULT ((0)),
	[adamInput4] [bit] NOT NULL CONSTRAINT [DF_STATUS_ENT_adamInput4]  DEFAULT ((0)),
	[adamInput5] [bit] NOT NULL CONSTRAINT [DF_STATUS_ENT_adamInput5]  DEFAULT ((0)),
	[adamInput6] [bit] NOT NULL CONSTRAINT [DF_STATUS_ENT_adamInput6]  DEFAULT ((0)),
	[updateDate] [datetime] NOT NULL CONSTRAINT [DF_STATUS_ENT_updateDate]  DEFAULT (getdate())
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIEMP_PREC]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIEMP_PREC](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[posicion] [int] NOT NULL CONSTRAINT [DF_TIEMP_PREC_rango]  DEFAULT ((0)),
	[tiempo] [int] NULL CONSTRAINT [DF_TIEMP_PREC_tiempo]  DEFAULT ((0)),
	[precio] [float] NULL CONSTRAINT [DF_TIEMP_PREC_precio]  DEFAULT ((0)),
	[estado] [bit] NULL CONSTRAINT [DF_TIEMP_PREC_estado]  DEFAULT ((1)),
 CONSTRAINT [PK_TIEMP_PREC] PRIMARY KEY CLUSTERED 
(
	[posicion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIPO_TICKETS]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TIPO_TICKETS](
	[id_tipo] [varchar](1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_TIPO_TICKETS] PRIMARY KEY CLUSTERED 
(
	[id_tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TIPO_USUARIO]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TIPO_USUARIO](
	[id_tipo] [tinyint] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](30) NULL,
	[menu_ent_status] [bit] NULL CONSTRAINT [DF_TIPO_menu_ent_status]  DEFAULT ((0)),
	[menu_ent_configuracion] [bit] NULL CONSTRAINT [DF_TIPO_menu_ent_configuracion]  DEFAULT ((0)),
	[menu_ent_salir] [bit] NULL CONSTRAINT [DF_TIPO_menu_ent_salir]  DEFAULT ((0)),
	[menu_sal_tiempoprecio] [bit] NULL CONSTRAINT [DF_TIPO_menu_sal_tiempoprecio]  DEFAULT ((0)),
	[menu_sal_salir] [bit] NULL CONSTRAINT [DF_TIPO_USUARIO_menu_sal_salir]  DEFAULT ((0)),
	[menu_sal_configuracion] [bit] NULL CONSTRAINT [DF_TIPO_menu_sal_configuracion]  DEFAULT ((0)),
	[btn_sal_ticketp] [bit] NULL CONSTRAINT [DF_TIPO_btn_sal_ticketp]  DEFAULT ((0)),
	[btn_sal_ticketm] [bit] NULL CONSTRAINT [DF_TIPO_btn_sal_ticketm]  DEFAULT ((0)),
	[generar_reportes] [bit] NULL CONSTRAINT [DF_TIPO_USUARIO_generar_reportes]  DEFAULT ((0)),
	[agregar_usuario] [bit] NULL CONSTRAINT [DF_TIPO_USUARIO_agreagar_usuario]  DEFAULT ((0)),
 CONSTRAINT [PK_TIPO] PRIMARY KEY CLUSTERED 
(
	[id_tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USUARIO](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](80) NULL,
	[usuario] [varchar](40) NULL,
	[clave] [varchar](100) NULL,
	[id_tipo] [tinyint] NULL,
	[estado] [bit] NULL CONSTRAINT [DF_USUARIO_estado]  DEFAULT ((1)),
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[ACT_DESCT]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ACT_DESCT]
@id varchar(30), @valor bit, @table varchar(50), @campo varchar(50), @mensaje varchar(50) output
as
set nocount on
begin
if(@valor=1)
begin
Exec('update ' +@table+ ' set estado=0 where '+@campo+' = '+@id)
set @mensaje='Desactivado!'
end
else
begin
Exec('update ' +@table+ ' set estado=1 where '+@campo+' = '+@id)
set @mensaje='Activado!'
end
end














GO
/****** Object:  StoredProcedure [dbo].[ACTIVATE_SOFTWARE]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[ACTIVATE_SOFTWARE]
@mensaje bit output
AS
set @mensaje = 0
BEGIN

	Update SETTINGS_ADM set activated = 1
	
	if exists (select * from SETTINGS_ADM where activated = 1)
		begin 
			set @mensaje = 1
		end
END






GO
/****** Object:  StoredProcedure [dbo].[CHECK_TICKET]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CHECK_TICKET]
@barcode varchar(15), @mensaje varchar(1) output
as
begin
set nocount on
	if exists (select * from ENTSAL where codigo_barra=@barcode and estado=0)
		begin
			set @mensaje='1'
		end
	else
		begin
			set @mensaje='0'
		end
end


















GO
/****** Object:  StoredProcedure [dbo].[CIERRE_DIARIO]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CIERRE_DIARIO]
@idturno int,@idusuario int
as
begin
DECLARE @totala int=(select count(id) from ENTSAL where id_turno=@idturno and id_usuario=@idusuario and tipo_ticket='A')
DECLARE @totalm int=(select count(id) from ENTSAL where id_turno=@idturno and id_usuario=@idusuario and tipo_ticket='M')
DECLARE @totale int=(select count(id) from ENTSAL where id_turno=@idturno and id_usuario=@idusuario and tipo_ticket='E')
DECLARE @totall int=(select count(id) from LOST_TICKET where id_turno=@idturno and id_usuario=@idusuario)
DECLARE @fechain date=(select session_started from LOG_LOGIN where id=@idturno)
DECLARE @horain time=(select FORMAT(session_started,'HH:mm:ss') from LOG_LOGIN where id=@idturno)
DECLARE @horaout time=(select FORMAT(session_finished,'HH:mm:ss') from LOG_LOGIN where id=@idturno)
DECLARE @totalin int=(select count(id) from ENTSAL where fecha_ent=@fechain and hora_ent  between @horain and @horaout)
--DECLARE @totalad int=(select sum(monto) from ENTSAL where id_turno=@idturno and id_usuario=@idusuario and tipo_ticket='A')
--DECLARE @totalmd int=(select sum(monto) from ENTSAL where id_turno=@idturno and id_usuario=@idusuario and tipo_ticket='M')
--DECLARE @totalld int=(select sum(monto) from LOST_TICKET where id_turno=@idturno and id_usuario=@idusuario)
--declare @totalcaja int=@totalad+@totalmd+@totalld
--if @totalad is null
--set @totalad=0
--if @totalmd is null
--set @totalmd=0
--if @totalld is null
--set @totalld=0
--if @totalcaja is null
--set @totalcaja=0
declare @StartDate datetime =(select session_started from LOG_LOGIN where id_user=@idusuario and id=@idturno)
declare @EndDate datetime=(select session_finished from LOG_LOGIN where id_user=@idusuario and id=@idturno)
declare @duracion varchar(20)=(select convert(varchar(5),DateDiff(s, @startDate, @EndDate)/3600)+' Hrs '+convert(varchar(5),DateDiff(s, @startDate, @EndDate)%3600/60)+' Mins' as [hh:mm])
SELECT L.id,L.session_finished,l.session_started,L.total_automatic,L.total_lost,L.total_manual,
L.total,U.nombre,U.usuario,U.id_usuario,@totala as Totala,@totall as Totalp,@totalm as Totalm,@duracion as duracion,@totale as Totale,
@totalin as TotalIn
--,@totalad as Totalad,@totalmd as Totalmd,@totalld as Totalld,@totalcaja as TotalCaja
FROM LOG_LOGIN L JOIN
USUARIO U ON U.id_usuario=L.id_user
where l.id_user=@idusuario and l.id=@idturno
END

GO
/****** Object:  StoredProcedure [dbo].[CLOSE_SESSION]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[CLOSE_SESSION]
@idUser int, @estacion varchar(20), @mensaje varchar(20) output
as
declare @idlog int=(select id from LOG_LOGIN where id_user=@idUser and session_close=0)
declare @totala float = (select sum(monto) from ENTSAL where id_turno=@idlog and tipo_ticket='A')
declare @totalm float = (select sum(monto) from ENTSAL where id_turno=@idlog and tipo_ticket='M')
declare @totalp float = (select sum(monto) from LOST_TICKET where id_turno=@idlog AND id_usuario=@idUser)

if @totala is null
begin
set @totala=0
end
if @totalm is null
begin
set @totalm=0
end
if @totalp is null
begin
set @totalp=0
end

declare @total float =@totala + @totalm+@totalp
if @total is null
begin
set @total=0
end
begin 
	if exists (select * from LOG_LOGIN where id_user =@idUser and estacion = @estacion and session_close = 0)
		begin
			update LOG_LOGIN set user_break= 0, session_close = 1, session_finished = convert(datetime2(0) , getdate()),
			total=@total,total_automatic=@totala,total_manual=@totalm,total_lost=@totalp
			where id_user =@idUser and estacion = @estacion and session_close = 0			
			set @mensaje = '1'

		end
	else
		set @mensaje = '0'
		
end














GO
/****** Object:  StoredProcedure [dbo].[CLOSE_USER_SESSION_AFTER_LOGIN]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CLOSE_USER_SESSION_AFTER_LOGIN]
@idUser int, @estacion varchar(20), @mensaje varchar(20) output
as

begin 
	if exists (select * from LOG_LOGIN where id_user =@idUser and estacion = @estacion and session_close = 0)
		begin
			update LOG_LOGIN set user_break= 0, session_close = 1, session_finished = convert(datetime2(0) , getdate())
			where id_user =@idUser and estacion = @estacion and session_close = 0
			insert into LOG_LOGIN (id_user, estacion) Values (@idUser, @estacion)
			set @mensaje = '1'

		end
	else
		set @mensaje = '0'
end













GO
/****** Object:  StoredProcedure [dbo].[FIND_CLOSE_SESSIONS]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FIND_CLOSE_SESSIONS]
@fechai date,@fechaf date
as
begin
set nocount on
SELECT FORMAT(l.session_finished,'dd/MM/yyyy'),U.id_usuario,U.usuario,L.id FROM USUARIO U 
JOIN LOG_LOGIN L ON  L.id_user=U.id_usuario
WHERE L.session_close=1 AND FORMAT(l.session_finished,'yyyy-MM-dd') BETWEEN @fechai and @fechaf
end

GO
/****** Object:  StoredProcedure [dbo].[FIND_TICKETS]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[FIND_TICKETS]
@fechai date,@fechaf date
as
begin
set nocount on
	select codigo_barra,monto,tiempo,descripcion,estacion_sal 
	from ENTSAL left join TIPO_TICKETS on id_tipo=tipo_ticket
	where fecha_sal between @fechai and @fechaf 
end

GO
/****** Object:  StoredProcedure [dbo].[FIRST_LOGIN]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[FIRST_LOGIN]
@mensaje varchar(50) output
as
begin
	if (not exists (select 1 from TIPO_USUARIO) or not exists (select 1 from USUARIO))  
		begin
			
			set @mensaje='1'
		end
	else
		begin
			set @mensaje='2'
		end
end














GO
/****** Object:  StoredProcedure [dbo].[GET_EMPRESA]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GET_EMPRESA]
as
begin
set nocount on
	select * from EMPRESA
end















GO
/****** Object:  StoredProcedure [dbo].[GET_ESTACIONES]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GET_ESTACIONES]
@entrada_salida varchar(10)
as

begin
	if @entrada_salida = 'ent'
		begin
			if exists (select 1 from SETTINGS_ENT)
				begin
					select EstacionNumero from SETTINGS_ENT
					
				end
		end

	if @entrada_salida = 'sal'
		begin
			if exists (select 1 from SETTINGS_SAL)
				begin
					select EstacionNumero from SETTINGS_SAL
					
				end
		end
end









GO
/****** Object:  StoredProcedure [dbo].[GET_IF_SOFTWARE_ACTIVATED]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[GET_IF_SOFTWARE_ACTIVATED]
@mensaje bit output
AS
set @mensaje = 0
BEGIN
	if not exists (select 1 from SETTINGS_ADM)
		begin
			insert into SETTINGS_ADM (precioTicketPerdido) values (0)
		end
	else
		begin
			if exists (select * from SETTINGS_ADM where activated = 1)
				begin
					set @mensaje = 1
				end
		end

END






GO
/****** Object:  StoredProcedure [dbo].[GET_IF_USER_ON_BREAK]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GET_IF_USER_ON_BREAK]
@userId int, @estacion varchar(50), @mensaje varchar(20) output, @idturno int output
as
begin
	if(exists( select id from LOG_LOGIN where id_user = @userId and estacion = @estacion and session_close = 0))
		begin
			set @mensaje = '1'
			set @idturno=(select id from LOG_LOGIN where id_user=@userId and session_close=0)
		end
	else
		begin
			insert into LOG_LOGIN (id_user, estacion) Values (@userId, @estacion)
			set @mensaje = '0'
			set @idturno=(select max(id) from LOG_LOGIN)
		end
end













GO
/****** Object:  StoredProcedure [dbo].[GET_SETTINGS]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE Procedure [dbo].[GET_SETTINGS]
@entrada_salida varchar(10), @estacion varchar(10)
as
begin
	if (@entrada_salida = 'ent')
		begin
			if (not exists (select 1 from SETTINGS_ENT))
				begin
					insert into SETTINGS_ENT(EstacionNumero)
					Values ('01')

					select * from SETTINGS_ENT
				end
			else
				begin
					select * from SETTINGS_ENT where EstacionNumero = @estacion
				end
		end
	if (@entrada_salida = 'sal')
		begin
			if (not exists (select 1 from SETTINGS_SAL))
				begin
					insert into SETTINGS_SAL(EstacionNumero)
					Values ('01')

					select * from SETTINGS_SAL 
				end
			else
				begin
					select * from SETTINGS_SAL where EstacionNumero = @estacion
				end
		end
end











GO
/****** Object:  StoredProcedure [dbo].[GET_SETTINGS_ADM]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create Procedure [dbo].[GET_SETTINGS_ADM]

as
begin
	select * from SETTINGS_ADM
end











GO
/****** Object:  StoredProcedure [dbo].[GET_TIME_PRICE]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GET_TIME_PRICE]

as
begin
set nocount on
	select * from TIEMP_PREC order by posicion asc
end




















GO
/****** Object:  StoredProcedure [dbo].[GET_TIPO_USUARIO]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_TIPO_USUARIO]
as
begin
set nocount on
	select * from TIPO_USUARIO order by id_tipo asc
end















GO
/****** Object:  StoredProcedure [dbo].[GET_USER_PERMISSIONS]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GET_USER_PERMISSIONS]
@user_id int
as
begin
    declare @tipo_id int
	select @tipo_id = id_tipo from USUARIO where id_usuario = @user_id

	select * from TIPO_USUARIO where id_tipo = @tipo_id
end













GO
/****** Object:  StoredProcedure [dbo].[GET_USUARIO]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_USUARIO]
@estado bit
as
begin
set nocount on
	select u.id_usuario,u.nombre,u.usuario,u.clave,t.descripcion,u.estado
	 from USUARIO u join TIPO_USUARIO t on
	t.id_tipo=u.id_tipo where u.estado=@estado 
	order by nombre asc
end















GO
/****** Object:  StoredProcedure [dbo].[getStatusEntrada]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getStatusEntrada]
as
begin
	select *, GETDATE() as actualDate from STATUS_ENT
end























GO
/****** Object:  StoredProcedure [dbo].[INS_MANUAL_TICKET]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[INS_MANUAL_TICKET]
@estacion varchar(50),@fecha date, @hora time(0),@fecha_sal date, @hora_sal time(0), @barcode varchar(15),@image varbinary(max), @tipoTicket varchar(1),@idusuario int,@estado int,
@monto float,@tiempo float
as
begin
if not exists (select * from ENTSAL where codigo_barra=@barcode)
	begin
		insert into ENTSAL(estacion_ent,fecha_ent,hora_ent,codigo_barra,img, tipo_ticket,fecha_sal,hora_sal,id_usuario,estado) 
		values (@estacion,@fecha,@hora,@barcode,@image, @tipoTicket,@fecha_sal,@hora_sal,@idusuario,@estado)
	end

end























GO
/****** Object:  StoredProcedure [dbo].[INS_TICKET]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[INS_TICKET]
@estacion varchar(50),@fecha date, @hora time(0), @barcode varchar(15),@image varbinary(max), @tipoTicket varchar(1)
as
begin
if not exists (select * from ENTSAL where codigo_barra=@barcode)
	begin
		insert into ENTSAL(estacion_ent,fecha_ent,hora_ent,codigo_barra,img, tipo_ticket) 
		values (@estacion,@fecha,@hora,@barcode,@image, @tipoTicket)
	end

end























GO
/****** Object:  StoredProcedure [dbo].[REG_EMPRESA]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[REG_EMPRESA]
@id int=0,@nombre varchar(50),@direccion varchar(200),@telefono varchar(11),@correo varchar(50),@mensaje varchar(1) output
as
begin
set @mensaje=0
set nocount on
	if @id=0
		begin
			insert into EMPRESA (nombre,direccion,telefono,correo)
			values (@nombre,@direccion,@telefono,@correo)
			set @mensaje=1
		end
	else
		begin
			update EMPRESA set nombre=@nombre,direccion=@direccion,telefono=@telefono,correo=@correo
			where id_empresa=@id
			set @mensaje=1
		end
end

GO
/****** Object:  StoredProcedure [dbo].[REG_FIRST_USER]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[REG_FIRST_USER]
@nombre varchar(80), @usuario varchar(15), @clave varchar(100), @mensaje varchar(10) output, @idUser int output
as

begin
	declare @id_tipo int

	if (not exists (select 1 from TIPO_USUARIO where descripcion='Administrador'))
		begin
			insert into TIPO_USUARIO(descripcion, menu_ent_status, menu_ent_salir, menu_sal_tiempoprecio, btn_sal_ticketp, btn_sal_ticketm, generar_reportes, agregar_usuario, menu_sal_salir)
			values ('Administrador', 1, 1, 1, 1, 1, 1, 1, 1)
			 
		end
	select @id_tipo = id_tipo from TIPO_USUARIO where descripcion='Administrador'
	if not exists (select * from USUARIO where usuario=@usuario)
		begin
			insert into USUARIO(nombre, usuario, clave, id_tipo) 
					Values(@nombre, @usuario, @clave, @id_tipo)
			
			set @mensaje = '1'
			select @idUser = id_usuario from USUARIO where usuario = @usuario
		end
	else
		begin
			set @mensaje = '2'
		end
end













GO
/****** Object:  StoredProcedure [dbo].[REG_LOST_TICKET]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[REG_LOST_TICKET]
@nombre varchar(100),@cedula varchar(30),@idturno int,@iduser int,@monto float,@estacion varchar(5),@placa varchar(30)
as
begin

insert into LOST_TICKET (fecha,nombre,cedula,id_turno,id_usuario,monto,estacion,placa)
values (getdate(),@nombre,@cedula,@idturno,@iduser,@monto,@estacion,@placa)

end

GO
/****** Object:  StoredProcedure [dbo].[REG_TIME_PRICE]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[REG_TIME_PRICE]
@posicion int, @tiempo int, @precio float, @mensaje varchar(50) output
as
begin
set nocount on
	if not exists (select * from TIEMP_PREC where posicion=@posicion)
		begin
			insert into TIEMP_PREC (posicion,tiempo,precio)
			values (@posicion,@tiempo,@precio)
			set @mensaje='1'
		end
	else
		begin
			set @mensaje='2'
		end
end




















GO
/****** Object:  StoredProcedure [dbo].[REG_TIPO_USUARIO]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[REG_TIPO_USUARIO]
@description varchar(30), @men_ent_status bit, @men_ent_salir bit, @men_tiempo_precio bit, @men_sal_salir bit, 
@ticket_perdido bit, @ticket_manual bit, @reportes bit, @agregar_usuario bit ,  @mensaje varchar(50) output
as
begin

	if not exists (select * from TIPO_USUARIO where descripcion=@description)
		begin
			insert into TIPO_USUARIO(descripcion, menu_ent_status, menu_ent_salir, menu_sal_tiempoprecio, btn_sal_ticketp, btn_sal_ticketm, generar_reportes, agregar_usuario, menu_sal_salir)
							values (@description, @men_ent_status, @men_ent_salir, @men_tiempo_precio, @ticket_perdido, @ticket_manual, @reportes, @agregar_usuario, @men_sal_salir)
			set @mensaje='1'
		end
	else
		begin
			set @mensaje='2'
		end

end















GO
/****** Object:  StoredProcedure [dbo].[REG_USUARIO]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[REG_USUARIO]
@nombre varchar(60),@usuario varchar(25),@clave varchar(50),@idtipo tinyint,@mensaje varchar(50) output
as
begin
set nocount on
	if not exists(select * from USUARIO where usuario=@usuario)
		begin
			insert into USUARIO(nombre,usuario,clave,id_tipo)
			values (@nombre,@usuario,@clave,@idtipo)
			set @mensaje='1'
		end
	else
		set @mensaje='0'
	end














GO
/****** Object:  StoredProcedure [dbo].[RPT_DET_LOST_TICKETS]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RPT_DET_LOST_TICKETS]
@fechai date, @fechaf date
as
begin
SELECT fecha,L.nombre,cedula,placa,monto,estacion,id_turno,U.usuario
FROM LOST_TICKET L join USUARIO U on U.id_usuario=U.id_usuario
WHERE fecha BETWEEN @fechai AND @fechaf
end

GO
/****** Object:  StoredProcedure [dbo].[RPT_DETALLE_CIERRE]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RPT_DETALLE_CIERRE]
@fechai date, @fechaf date
as
begin
select id_turno,e.codigo_barra,(CONVERT(varchar(10),e.fecha_ent,121)+' '+FORMAT(CAST(e.hora_ent AS datetime),'hh:mm:tt'))as Entrada,
(CONVERT(varchar(10),e.fecha_sal,121)+' '+FORMAT(CAST(e.hora_sal AS datetime),'hh:mm:tt'))as Salida,
(convert(varchar(5),e.tiempo/60)+' Hrs '+convert(varchar(5),(e.tiempo)%60)+' Mins') as Duracion,
E.monto,T.descripcion,U.usuario,e.estacion_sal
from ENTSAL E join USUARIO U on
E.id_usuario=U.id_usuario join TIPO_TICKETS T on T.id_tipo=E.tipo_ticket
where fecha_sal between @fechai and @fechaf 
order by e.fecha_ent,hora_ent asc
end

GO
/****** Object:  StoredProcedure [dbo].[SAVE_SETTINGS]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SAVE_SETTINGS]
@entrada_salida varchar(10), @defaultPrinter varchar(100), @byPassAdam bit, @byPassLoop bit, @byPassBrazo bit, @adamIp varchar(50),
	@adamPort int, @estacionNombre varchar(50), @estacionNumero varchar(50), @mensaje bit output, @estacionAnterior varchar(10), @inputLoop varchar (10), @inputPushButton varchar(10), @inputLoopBrazo varchar(10), @outputAbrirBrazo varchar(10), @byPassPaperPresenter bit
as
set @mensaje = 0
begin
	if (@entrada_salida = 'ent')
		begin
			if (not exists (select 1 from SETTINGS_ENT where EstacionNumero=@estacionNumero))
				begin
					Insert into SETTINGS_ENT (defaultPrinter, byPassLoopEntrada, byPassAdam, byPassBrazoEntrada, AdamIp, AdamPort, EstacionNombre, EstacionNumero, InputLoopEntrada, InputPushButton, InputLoopBrazo, OutputAbrirBrazo, byPassPaperPresenter)
					VALUES (@defaultPrinter, @byPassLoop, @byPassAdam, @byPassBrazo, @adamIp, @adamPort, @estacionNombre, @estacionNumero, @inputLoop, @inputPushButton, @inputLoopBrazo, @outputAbrirBrazo, @byPassPaperPresenter)
					set @mensaje = 1
				end
			else
				begin
					Update SETTINGS_ENT set defaultPrinter = @defaultPrinter, byPassLoopEntrada = @byPassLoop, byPassAdam = @byPassAdam, byPassBrazoEntrada = @byPassBrazo, InputLoopEntrada = @inputLoop, InputPushButton = @inputPushButton, InputLoopBrazo = @inputLoopBrazo, OutputAbrirBrazo = @outputAbrirBrazo,
					AdamIp = @adamIp, AdamPort = @adamPort, EstacionNombre = @estacionNombre, EstacionNumero = @estacionNumero, byPassPaperPresenter = @byPassPaperPresenter where EstacionNumero = @estacionNumero
					set @mensaje = 1 
				end
		end
	if (@entrada_salida = 'sal')
		begin
			if (not exists (select 1 from SETTINGS_SAL where EstacionNumero=@estacionNumero))
				begin
					Insert into SETTINGS_SAL (defaultPrinter, byPassLoopSalida, byPassAdam, AdamIp, AdamPort, EstacionNombre, EstacionNumero, InputLoopSalida, OutputAbrirBrazo)
					VALUES (@defaultPrinter, @byPassLoop, @byPassAdam, @adamIp, @adamPort, @estacionNombre, @estacionNumero, @inputLoop, @outputAbrirBrazo )
					set @mensaje = 1
				end
			else
				begin
					Update SETTINGS_SAL set defaultPrinter = @defaultPrinter, byPassLoopSalida = @byPassLoop, byPassAdam = @byPassAdam, InputLoopSalida = @inputLoop, OutputAbrirBrazo = @outputAbrirBrazo,
					AdamIp = @adamIp, AdamPort = @adamPort, EstacionNombre = @estacionNombre, EstacionNumero = @estacionNumero where EstacionNumero = @estacionNumero
					set @mensaje = 1
				end
		end

end











GO
/****** Object:  StoredProcedure [dbo].[SEL_TICKET]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SEL_TICKET]
@barcode varchar(15)=''
as
begin
declare @id int
if @barcode!=''
	begin
		if exists (select * from ENTSAL where codigo_barra=@barcode)
			begin
				select estacion_ent,fecha_ent,FORMAT(CAST(hora_ent AS DATETIME),'hh:mm tt') as hora,img, codigo_barra, promocion
				from ENTSAL, SETTINGS_ADM where codigo_barra=@barcode
				
			end
	end
else
	begin
		set @id=(select max(id) from ENTSAL)
		select estacion_ent,fecha_ent,FORMAT(CAST(hora_ent AS DATETIME),'hh:mm tt') as hora,img, codigo_barra, promocion
		from ENTSAL, SETTINGS_ADM where id=@id 
		
	end
end























GO
/****** Object:  StoredProcedure [dbo].[SET_USER_ON_BREAK]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SET_USER_ON_BREAK]
@userId int, @estacion varchar(50), @mensaje varchar(20) output
as
begin
	if(exists( select id from LOG_LOGIN where id_user = @userId and estacion = @estacion and session_close = 0))
		begin
			Update LOG_LOGIN set user_break = 1 where id_user = @userId and estacion = @estacion and session_close = 0
			set @mensaje = '1'
		end
	else
		begin
			
			set @mensaje = '0'
		end
end













GO
/****** Object:  StoredProcedure [dbo].[UPD_SETTINGS_ADM]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create Procedure [dbo].[UPD_SETTINGS_ADM]
@mensaje bit output, @precioTicket float, @promocion varchar(200)
as
set @mensaje = 0
begin
	Update SETTINGS_ADM set precioTicketPerdido = @precioTicket, promocion = @promocion
	set @mensaje = 1
end











GO
/****** Object:  StoredProcedure [dbo].[UPD_TICKET]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[UPD_TICKET]
@fechasal date, @horasal time(0),
@barcode varchar(15),@monto float,@tiempo int,@idusuario int, @estacion varchar(50),@idlog int
as
begin
declare @tipoticket varchar(1)='A' --ticket automatico
IF @monto=0
begin
	set @tipoticket='E' --identificar si ticket es exonerado de pagar
end
if exists (select * from ENTSAL where codigo_barra=@barcode and estado = 0)
	begin
		update ENTSAL set fecha_sal=@fechasal,hora_sal=@horasal,monto=@monto,id_usuario=@idusuario,
		 tiempo=@tiempo, estado=1, estacion_sal=@estacion,id_turno=@idlog,tipo_ticket=@tipoticket
		where codigo_barra=@barcode
	end

end























GO
/****** Object:  StoredProcedure [dbo].[UPD_TIME_PRICE]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UPD_TIME_PRICE]
@id int,@posicion int, @tiempo int, @precio float, @mensaje varchar(50) output
as
begin
set nocount on
	if exists (select * from TIEMP_PREC where id=@id)
		begin
			update TIEMP_PREC set posicion=@posicion,tiempo=@tiempo,precio=@precio
			where id=@id
			set @mensaje='1'
		end
	else
		begin
			set @mensaje='2'
		end
end




















GO
/****** Object:  StoredProcedure [dbo].[UPD_TIPO_USUARIO]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UPD_TIPO_USUARIO]
@id int, @description varchar(30), @men_ent_status bit, @men_ent_salir bit, @men_tiempo_precio bit, @men_sal_salir bit, 
@ticket_perdido bit, @ticket_manual bit, @reportes bit, @agregar_usuario bit ,  @mensaje varchar(50) output
as
begin
set nocount on
	if exists (select * from TIPO_USUARIO where id_tipo=@id)
		begin
			update TIPO_USUARIO set descripcion=@description,menu_ent_status=@men_ent_status, menu_ent_salir=@men_ent_salir, menu_sal_tiempoprecio = @men_tiempo_precio,
			menu_sal_salir = @men_sal_salir, btn_sal_ticketp = @ticket_perdido, btn_sal_ticketm = @ticket_manual, generar_reportes = @reportes, agregar_usuario = @agregar_usuario
			where id_tipo=@id
			set @mensaje='1'
		end
	else
		begin
			set @mensaje='2'
		end
end
















GO
/****** Object:  StoredProcedure [dbo].[UPD_USUARIO]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UPD_USUARIO]
@idusuario int,@nombre varchar(60),@usuario varchar(25),@clave varchar(50),@idtipo tinyint,@mensaje varchar(50) output, @value int
as
begin
set nocount on
	if @value = 1
	begin
	
		if exists(select * from USUARIO where id_usuario=@idusuario)
			begin
				update USUARIO set nombre=@nombre,usuario=@usuario,clave=@clave,id_tipo=@idtipo
				where id_usuario=@idusuario
				set @mensaje='1'
			end
		else
			begin
				set @mensaje='0'
			end
	end

	if @value = 2
	begin
	
		if exists(select * from USUARIO where id_usuario=@idusuario)
			begin
				update USUARIO set nombre=@nombre,usuario=@usuario,id_tipo=@idtipo
				where id_usuario=@idusuario
				set @mensaje='1'
			end
		else
			begin
				set @mensaje='0'
			end
	end
end














GO
/****** Object:  StoredProcedure [dbo].[updateStatusEntrada]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[updateStatusEntrada]
@p_offline bit, @p_paperjammed bit, @p_outofpaper bit, @p_dooropened bit, @p_error bit, @a_online bit, 
@a_input1 bit, @a_input2 bit, @a_input3 bit, @a_input4 bit, @a_input5 bit, @a_input6 bit, @dateupdated datetime
as
begin
	if (not exists (select 1 from STATUS_ENT))
		Insert Into STATUS_ENT (printerOffline, printerPaperJammed, printerOutOfPaper, printerDoorOpened, printerError, adamOnline,
		adamInput1, adamInput2, adamInput3, adamInput4, adamInput5, adamInput6, updateDate)
		Values
		(@p_offline, @p_paperjammed, @p_outofpaper, @p_dooropened, @p_error, @a_online, @a_input1, @a_input2, @a_input3,
		@a_input4, @a_input5, @a_input6, @dateupdated)
	else	
		update STATUS_ENT SET printerOffline = @p_offline, printerPaperJammed = @p_paperjammed, printerOutOfPaper = @p_outofpaper,
		printerDoorOpened = @p_dooropened, printerError = @p_error, adamOnline = @a_online, adamInput1 = @a_input1, adamInput2 = @a_input2,
		adamInput3 = @a_input3, adamInput4 = @a_input4, adamInput5 = @a_input5, adamInput6 = @a_input6, updateDate = @dateupdated;
end























GO
/****** Object:  StoredProcedure [dbo].[USER_LOGIN]    Script Date: 5/21/2018 11:06:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USER_LOGIN] 
@usuario varchar(15), @clave varchar(100), @mensaje varchar(50) output, @idUser int output
as
begin

	if exists (select * from USUARIO where usuario = @usuario and clave=@clave and estado = 1)
		begin
			set @mensaje = '1'
			select @idUser = id_usuario from USUARIO where usuario = @usuario
		end
		
	else
		begin
			set @mensaje = '2'
		end
end













GO
USE [master]
GO
ALTER DATABASE [SistemaParqueo] SET  READ_WRITE 
GO
