USE [master]
GO
/****** Object:  Database [PortalUpskill_DB]    Script Date: 19/05/2026 16:17:30 ******/
CREATE DATABASE [PortalUpskill_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PortalUpskill_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL17.MSSQLSERVER\MSSQL\DATA\PortalUpskill_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PortalUpskill_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL17.MSSQLSERVER\MSSQL\DATA\PortalUpskill_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PortalUpskill_DB] SET COMPATIBILITY_LEVEL = 170
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PortalUpskill_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PortalUpskill_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PortalUpskill_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PortalUpskill_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PortalUpskill_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PortalUpskill_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PortalUpskill_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PortalUpskill_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PortalUpskill_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PortalUpskill_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PortalUpskill_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PortalUpskill_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PortalUpskill_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PortalUpskill_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PortalUpskill_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PortalUpskill_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PortalUpskill_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PortalUpskill_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PortalUpskill_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PortalUpskill_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PortalUpskill_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PortalUpskill_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PortalUpskill_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PortalUpskill_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [PortalUpskill_DB] SET  MULTI_USER 
GO
ALTER DATABASE [PortalUpskill_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PortalUpskill_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PortalUpskill_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PortalUpskill_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PortalUpskill_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PortalUpskill_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PortalUpskill_DB] SET OPTIMIZED_LOCKING = OFF 
GO
ALTER DATABASE [PortalUpskill_DB] SET QUERY_STORE = ON
GO
ALTER DATABASE [PortalUpskill_DB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PortalUpskill_DB]
GO
/****** Object:  Table [dbo].[AnoLetivo]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnoLetivo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](20) NOT NULL,
 CONSTRAINT [PK_ANOLETIVO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Aula]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aula](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sumario] [varchar](2000) NULL,
	[DuracaoHoras] [decimal](6, 2) NULL,
	[HoraInicio] [datetime] NULL,
	[HoraFim] [datetime] NULL,
	[SalaId] [int] NULL,
	[TurmaId] [int] NULL,
	[FormadorId] [int] NULL,
	[ModuloId] [int] NULL,
 CONSTRAINT [PK_AULA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AvaliacaoFinal]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AvaliacaoFinal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FormandoId] [int] NULL,
	[CursoId] [int] NULL,
	[NotaFinal] [decimal](6, 2) NULL,
	[Validou] [bit] NULL,
 CONSTRAINT [PK_AVALIACAOFINAL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AvaliacaoModular]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AvaliacaoModular](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FormandoId] [int] NULL,
	[NotaFinal] [decimal](6, 2) NULL,
	[Comentarios] [varchar](max) NULL,
	[ModuloId] [int] NULL,
	[Validou] [bit] NULL,
	[FormadorId] [int] NULL,
	[CursoId] [int] NULL,
 CONSTRAINT [PK_AVALIACAOMODULAR] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CNAEF]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CNAEF](
	[AreaFormacao] [varchar](300) NULL,
	[CodigoCNAEF] [varchar](300) NOT NULL,
 CONSTRAINT [PK_CNAEF] PRIMARY KEY CLUSTERED 
(
	[CodigoCNAEF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NULL,
	[DuracaoHoras] [decimal](6, 2) NULL,
	[Objetivos] [varchar](max) NULL,
 CONSTRAINT [PK_CURSO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CursoCoordenador]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CursoCoordenador](
	[CursoId] [int] NULL,
	[PessoalId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CursoModulo]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CursoModulo](
	[CursoId] [int] NULL,
	[ModuloId] [int] NULL,
	[Horas] [decimal](6, 2) NULL,
	[Ordem] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoFormador]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoFormador](
	[PessoaId] [int] NOT NULL,
	[ListaEstadoId] [int] NULL,
	[Data] [date] NULL,
	[Observacoes] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoFormando]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoFormando](
	[PessoaId] [int] NOT NULL,
	[ListaEstadoId] [int] NULL,
	[Data] [date] NULL,
	[Observacoes] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Falta]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Falta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AulaId] [int] NULL,
	[FormandoId] [int] NULL,
	[HoraInicio] [datetime] NULL,
	[HoraFim] [datetime] NULL,
	[Justificada] [bit] NULL,
	[Anexo] [nvarchar](max) NULL,
	[Duracao] [int] NULL,
 CONSTRAINT [PK_Falta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Formador]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Formador](
	[PessoaId] [int] NOT NULL,
	[CCP] [bit] NULL,
	[DocenteEnsSuperior] [bit] NULL,
	[EstadoId] [int] NULL,
UNIQUE NONCLUSTERED 
(
	[PessoaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormadorModulo]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormadorModulo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FormadorId] [int] NULL,
	[ModuloId] [int] NULL,
 CONSTRAINT [PK_FormadorModulo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormadorModuloTurma]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormadorModuloTurma](
	[TurmaId] [int] NULL,
	[FormadorModuloId] [int] NULL,
	[Horas] [decimal](6, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Formando]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Formando](
	[PessoaId] [int] NOT NULL,
	[IBAN] [varchar](255) NULL,
	[Bolsa] [bit] NULL,
	[EstadoId] [int] NULL,
UNIQUE NONCLUSTERED 
(
	[PessoaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Funcoes]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcoes](
	[Nome] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Habilitacoes]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Habilitacoes](
	[Codigo] [int] NOT NULL,
	[HabilitacoesLiterarias] [varchar](255) NULL,
 CONSTRAINT [PK_HABILITACOES] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListaEstadosFormador]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListaEstadosFormador](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NULL,
 CONSTRAINT [PK_LISTAESTADOSFORMADOR] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListaEstadosFormando]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListaEstadosFormando](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NULL,
 CONSTRAINT [PK_LISTAESTADOSFORMANDO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Local]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Local](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocalSala]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalSala](
	[LocalId] [int] NULL,
	[SalaId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modulo]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modulo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NULL,
	[Horas] [decimal](6, 2) NULL,
	[Objetivos] [varchar](max) NULL,
	[ConteudosProgramaticos] [varchar](max) NULL,
	[SistemaAvaliacao] [varchar](max) NULL,
	[Bibliografia] [varchar](max) NULL,
	[SoftwareHardware] [varchar](300) NULL,
 CONSTRAINT [PK_MODULO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paises]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paises](
	[iso] [varchar](10) NOT NULL,
	[iso3] [varchar](10) NULL,
	[numcode] [varchar](10) NULL,
	[nome] [varchar](255) NULL,
 CONSTRAINT [PK_PAISES] PRIMARY KEY CLUSTERED 
(
	[iso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NULL,
 CONSTRAINT [PK_PERFIL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pessoa]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pessoa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NULL,
	[DataNascimento] [date] NULL,
	[Email] [varchar](100) NULL,
	[Password] [varchar](max) NULL,
	[Sexo] [varchar](75) NULL,
	[NIF] [varchar](75) NULL,
	[CC] [varchar](50) NULL,
	[ContactoTelemovel] [varchar](50) NULL,
	[ContactoTelefone] [varchar](50) NULL,
	[Morada] [varchar](500) NULL,
	[CP] [varchar](20) NULL,
	[CodigoCNAEF] [int] NULL,
	[HabilitacoesLiterarias] [varchar](100) NULL,
	[Nacionalidade] [varchar](75) NULL,
	[Foto] [nvarchar](max) NULL,
	[PerfilId] [int] NULL,
	[CV] [nvarchar](max) NULL,
 CONSTRAINT [PK_PESSOA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pessoal]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pessoal](
	[PessoaId] [int] NOT NULL,
	[Funcao] [varchar](100) NULL,
UNIQUE NONCLUSTERED 
(
	[PessoaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sala]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sala](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NULL,
	[LocalId] [int] NULL,
 CONSTRAINT [PK_SALA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turma]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turma](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NULL,
	[DataInicioCurso] [date] NULL,
	[DataFimCurso] [date] NULL,
	[CursoId] [int] NULL,
	[HorarioSincronoInicio] [datetime] NULL,
	[HorarioSincronoFim] [datetime] NULL,
	[HorarioAssincronoInicio] [datetime] NULL,
	[HorarioAssincronoFim] [datetime] NULL,
	[TempoLectivo] [int] NULL,
	[AnoLetivoId] [int] NULL,
 CONSTRAINT [PK_TURMA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TurmaFormando]    Script Date: 19/05/2026 16:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TurmaFormando](
	[FormandoId] [int] NULL,
	[TurmaId] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Aula]  WITH CHECK ADD  CONSTRAINT [Aula_fk0] FOREIGN KEY([SalaId])
REFERENCES [dbo].[Sala] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Aula] CHECK CONSTRAINT [Aula_fk0]
GO
ALTER TABLE [dbo].[Aula]  WITH NOCHECK ADD  CONSTRAINT [Aula_fk1] FOREIGN KEY([TurmaId])
REFERENCES [dbo].[Turma] ([Id])
ON UPDATE CASCADE
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Aula] NOCHECK CONSTRAINT [Aula_fk1]
GO
ALTER TABLE [dbo].[Aula]  WITH CHECK ADD  CONSTRAINT [FK_Aula_Formador] FOREIGN KEY([FormadorId])
REFERENCES [dbo].[Formador] ([PessoaId])
GO
ALTER TABLE [dbo].[Aula] CHECK CONSTRAINT [FK_Aula_Formador]
GO
ALTER TABLE [dbo].[Aula]  WITH NOCHECK ADD  CONSTRAINT [FK_Aula_Modulo] FOREIGN KEY([ModuloId])
REFERENCES [dbo].[Modulo] ([Id])
GO
ALTER TABLE [dbo].[Aula] NOCHECK CONSTRAINT [FK_Aula_Modulo]
GO
ALTER TABLE [dbo].[AvaliacaoFinal]  WITH CHECK ADD  CONSTRAINT [AvaliacaoFinal_fk0] FOREIGN KEY([FormandoId])
REFERENCES [dbo].[Formando] ([PessoaId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[AvaliacaoFinal] CHECK CONSTRAINT [AvaliacaoFinal_fk0]
GO
ALTER TABLE [dbo].[AvaliacaoFinal]  WITH NOCHECK ADD  CONSTRAINT [AvaliacaoFinal_fk1] FOREIGN KEY([CursoId])
REFERENCES [dbo].[Curso] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[AvaliacaoFinal] NOCHECK CONSTRAINT [AvaliacaoFinal_fk1]
GO
ALTER TABLE [dbo].[AvaliacaoModular]  WITH CHECK ADD  CONSTRAINT [AvaliacaoModular_fk0] FOREIGN KEY([FormandoId])
REFERENCES [dbo].[Formando] ([PessoaId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[AvaliacaoModular] CHECK CONSTRAINT [AvaliacaoModular_fk0]
GO
ALTER TABLE [dbo].[AvaliacaoModular]  WITH CHECK ADD  CONSTRAINT [AvaliacaoModular_fk1] FOREIGN KEY([ModuloId])
REFERENCES [dbo].[Modulo] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[AvaliacaoModular] CHECK CONSTRAINT [AvaliacaoModular_fk1]
GO
ALTER TABLE [dbo].[AvaliacaoModular]  WITH NOCHECK ADD  CONSTRAINT [AvaliacaoModular_fk3] FOREIGN KEY([CursoId])
REFERENCES [dbo].[Curso] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[AvaliacaoModular] NOCHECK CONSTRAINT [AvaliacaoModular_fk3]
GO
ALTER TABLE [dbo].[CursoCoordenador]  WITH CHECK ADD  CONSTRAINT [CursoCoordenador_fk0] FOREIGN KEY([CursoId])
REFERENCES [dbo].[Curso] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[CursoCoordenador] CHECK CONSTRAINT [CursoCoordenador_fk0]
GO
ALTER TABLE [dbo].[CursoCoordenador]  WITH NOCHECK ADD  CONSTRAINT [CursoCoordenador_fk1] FOREIGN KEY([PessoalId])
REFERENCES [dbo].[Pessoal] ([PessoaId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[CursoCoordenador] CHECK CONSTRAINT [CursoCoordenador_fk1]
GO
ALTER TABLE [dbo].[CursoModulo]  WITH NOCHECK ADD  CONSTRAINT [CursoModulo_fk0] FOREIGN KEY([CursoId])
REFERENCES [dbo].[Curso] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[CursoModulo] CHECK CONSTRAINT [CursoModulo_fk0]
GO
ALTER TABLE [dbo].[CursoModulo]  WITH NOCHECK ADD  CONSTRAINT [CursoModulo_fk1] FOREIGN KEY([ModuloId])
REFERENCES [dbo].[Modulo] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[CursoModulo] NOCHECK CONSTRAINT [CursoModulo_fk1]
GO
ALTER TABLE [dbo].[EstadoFormador]  WITH CHECK ADD  CONSTRAINT [EstadoFormador_fk0] FOREIGN KEY([ListaEstadoId])
REFERENCES [dbo].[ListaEstadosFormador] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[EstadoFormador] CHECK CONSTRAINT [EstadoFormador_fk0]
GO
ALTER TABLE [dbo].[EstadoFormador]  WITH CHECK ADD  CONSTRAINT [FK_EstadoFormador_Formador] FOREIGN KEY([PessoaId])
REFERENCES [dbo].[Formador] ([PessoaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EstadoFormador] CHECK CONSTRAINT [FK_EstadoFormador_Formador]
GO
ALTER TABLE [dbo].[EstadoFormando]  WITH CHECK ADD  CONSTRAINT [EstadoFormando_fk0] FOREIGN KEY([ListaEstadoId])
REFERENCES [dbo].[ListaEstadosFormando] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[EstadoFormando] CHECK CONSTRAINT [EstadoFormando_fk0]
GO
ALTER TABLE [dbo].[EstadoFormando]  WITH CHECK ADD  CONSTRAINT [FK_EstadoFormando_Formando] FOREIGN KEY([PessoaId])
REFERENCES [dbo].[Formando] ([PessoaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EstadoFormando] CHECK CONSTRAINT [FK_EstadoFormando_Formando]
GO
ALTER TABLE [dbo].[Falta]  WITH CHECK ADD  CONSTRAINT [Falta_fk0] FOREIGN KEY([AulaId])
REFERENCES [dbo].[Aula] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Falta] CHECK CONSTRAINT [Falta_fk0]
GO
ALTER TABLE [dbo].[Falta]  WITH CHECK ADD  CONSTRAINT [Falta_fk1] FOREIGN KEY([FormandoId])
REFERENCES [dbo].[Formando] ([PessoaId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Falta] CHECK CONSTRAINT [Falta_fk1]
GO
ALTER TABLE [dbo].[Formador]  WITH CHECK ADD  CONSTRAINT [Formador_fk0] FOREIGN KEY([PessoaId])
REFERENCES [dbo].[Pessoa] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Formador] CHECK CONSTRAINT [Formador_fk0]
GO
ALTER TABLE [dbo].[FormadorModulo]  WITH CHECK ADD  CONSTRAINT [FK_FormadorModulo_Formador] FOREIGN KEY([FormadorId])
REFERENCES [dbo].[Formador] ([PessoaId])
GO
ALTER TABLE [dbo].[FormadorModulo] CHECK CONSTRAINT [FK_FormadorModulo_Formador]
GO
ALTER TABLE [dbo].[FormadorModulo]  WITH NOCHECK ADD  CONSTRAINT [FK_FormadorModulo_Modulo] FOREIGN KEY([ModuloId])
REFERENCES [dbo].[Modulo] ([Id])
GO
ALTER TABLE [dbo].[FormadorModulo] NOCHECK CONSTRAINT [FK_FormadorModulo_Modulo]
GO
ALTER TABLE [dbo].[FormadorModuloTurma]  WITH NOCHECK ADD  CONSTRAINT [FK_FormadorModuloTurma_FormadorModulo] FOREIGN KEY([FormadorModuloId])
REFERENCES [dbo].[FormadorModulo] ([Id])
GO
ALTER TABLE [dbo].[FormadorModuloTurma] NOCHECK CONSTRAINT [FK_FormadorModuloTurma_FormadorModulo]
GO
ALTER TABLE [dbo].[FormadorModuloTurma]  WITH NOCHECK ADD  CONSTRAINT [FK_FormadorModuloTurma_Turma] FOREIGN KEY([TurmaId])
REFERENCES [dbo].[Turma] ([Id])
GO
ALTER TABLE [dbo].[FormadorModuloTurma] NOCHECK CONSTRAINT [FK_FormadorModuloTurma_Turma]
GO
ALTER TABLE [dbo].[Formando]  WITH CHECK ADD  CONSTRAINT [Formando_fk0] FOREIGN KEY([PessoaId])
REFERENCES [dbo].[Pessoa] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Formando] CHECK CONSTRAINT [Formando_fk0]
GO
ALTER TABLE [dbo].[Pessoa]  WITH CHECK ADD  CONSTRAINT [Pessoa_fk0] FOREIGN KEY([PerfilId])
REFERENCES [dbo].[Perfil] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pessoa] CHECK CONSTRAINT [Pessoa_fk0]
GO
ALTER TABLE [dbo].[Turma]  WITH CHECK ADD  CONSTRAINT [FK_Turma_AnoLetivo] FOREIGN KEY([AnoLetivoId])
REFERENCES [dbo].[AnoLetivo] ([Id])
GO
ALTER TABLE [dbo].[Turma] CHECK CONSTRAINT [FK_Turma_AnoLetivo]
GO
ALTER TABLE [dbo].[Turma]  WITH NOCHECK ADD  CONSTRAINT [FK_TurmaCurso] FOREIGN KEY([CursoId])
REFERENCES [dbo].[Curso] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Turma] NOCHECK CONSTRAINT [FK_TurmaCurso]
GO
ALTER TABLE [dbo].[TurmaFormando]  WITH CHECK ADD  CONSTRAINT [TurmaFormando_fk0] FOREIGN KEY([FormandoId])
REFERENCES [dbo].[Formando] ([PessoaId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[TurmaFormando] CHECK CONSTRAINT [TurmaFormando_fk0]
GO
ALTER TABLE [dbo].[TurmaFormando]  WITH NOCHECK ADD  CONSTRAINT [TurmaFormando_fk1] FOREIGN KEY([TurmaId])
REFERENCES [dbo].[Turma] ([Id])
ON UPDATE CASCADE
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TurmaFormando] NOCHECK CONSTRAINT [TurmaFormando_fk1]
GO
USE [master]
GO
ALTER DATABASE [PortalUpskill_DB] SET  READ_WRITE 
GO
