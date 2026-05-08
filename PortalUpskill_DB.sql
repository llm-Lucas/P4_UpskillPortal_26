CREATE DATABASE [PortalUpskill_DB]
GO
USE [PortalUpskill_DB]
GO
/****** Object:  Table [dbo].[Aula]    Script Date: 29/04/2021 23:08:13 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AvaliacaoFinal]    Script Date: 29/04/2021 23:08:14 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AvaliacaoModular]    Script Date: 29/04/2021 23:08:14 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CNAEF]    Script Date: 29/04/2021 23:08:14 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 29/04/2021 23:08:14 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CursoCoordenador]    Script Date: 29/04/2021 23:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CursoCoordenador](
	[CursoId] [int] NULL,
	[PessoalId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CursoModulo]    Script Date: 29/04/2021 23:08:14 ******/
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
/****** Object:  Table [dbo].[EstadoFormador]    Script Date: 29/04/2021 23:08:14 ******/
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
/****** Object:  Table [dbo].[EstadoFormando]    Script Date: 29/04/2021 23:08:14 ******/
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
/****** Object:  Table [dbo].[Falta]    Script Date: 29/04/2021 23:08:14 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Formador]    Script Date: 29/04/2021 23:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Formador](
	[PessoaId] [int] NOT NULL,
	[CCP] [bit] NULL,
	[DocenteEnsSuperior] [bit] NULL,
	[EstadoId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormadorModulo]    Script Date: 29/04/2021 23:08:14 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormadorModuloTurma]    Script Date: 29/04/2021 23:08:14 ******/
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
/****** Object:  Table [dbo].[Formando]    Script Date: 29/04/2021 23:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Formando](
	[PessoaId] [int] NOT NULL,
	[IBAN] [varchar](255) NULL,
	[Bolsa] [bit] NULL,
	[EstadoId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Funcoes]    Script Date: 29/04/2021 23:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcoes](
	[Nome] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Habilitacoes]    Script Date: 29/04/2021 23:08:14 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListaEstadosFormador]    Script Date: 29/04/2021 23:08:14 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListaEstadosFormando]    Script Date: 29/04/2021 23:08:14 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Local]    Script Date: 29/04/2021 23:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Local](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocalSala]    Script Date: 29/04/2021 23:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalSala](
	[LocalId] [int] NULL,
	[SalaId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modulo]    Script Date: 29/04/2021 23:08:14 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paises]    Script Date: 29/04/2021 23:08:14 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 29/04/2021 23:08:14 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pessoa]    Script Date: 29/04/2021 23:08:14 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pessoal]    Script Date: 29/04/2021 23:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pessoal](
	[PessoaId] [int] NOT NULL,
	[Funcao] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sala]    Script Date: 29/04/2021 23:08:14 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turma]    Script Date: 29/04/2021 23:08:14 ******/
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
 CONSTRAINT [PK_TURMA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TurmaFormando]    Script Date: 29/04/2021 23:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TurmaFormando](
	[FormandoId] [int] NULL,
	[TurmaId] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Aula] ON 
GO
INSERT [dbo].[Aula] ([Id], [Sumario], [DuracaoHoras], [HoraInicio], [HoraFim], [SalaId], [TurmaId], [FormadorId], [ModuloId]) VALUES (71, N'Aula de Exemplo', CAST(3.50 AS Decimal(6, 2)), CAST(N'2021-02-01T14:30:00.000' AS DateTime), CAST(N'2021-02-01T18:00:00.000' AS DateTime), NULL, 890, 200, 4)
GO
INSERT [dbo].[Aula] ([Id], [Sumario], [DuracaoHoras], [HoraInicio], [HoraFim], [SalaId], [TurmaId], [FormadorId], [ModuloId]) VALUES (72, N'Introdução a base de fundamentos de programação', CAST(3.50 AS Decimal(6, 2)), CAST(N'2020-02-03T14:30:00.000' AS DateTime), CAST(N'2020-02-03T18:00:00.000' AS DateTime), NULL, 890, 200, 22)
GO
INSERT [dbo].[Aula] ([Id], [Sumario], [DuracaoHoras], [HoraInicio], [HoraFim], [SalaId], [TurmaId], [FormadorId], [ModuloId]) VALUES (74, N'Introdução aos conceitos de Base de Dados', CAST(3.50 AS Decimal(6, 2)), CAST(N'2021-02-02T14:30:00.000' AS DateTime), CAST(N'2021-02-02T18:00:00.000' AS DateTime), NULL, 890, 200, 4)
GO
INSERT [dbo].[Aula] ([Id], [Sumario], [DuracaoHoras], [HoraInicio], [HoraFim], [SalaId], [TurmaId], [FormadorId], [ModuloId]) VALUES (76, N'Conceitos de BD.', CAST(3.75 AS Decimal(6, 2)), CAST(N'2021-05-24T14:15:00.000' AS DateTime), CAST(N'2021-05-24T18:00:00.000' AS DateTime), NULL, 894, 200, 3)
GO
INSERT [dbo].[Aula] ([Id], [Sumario], [DuracaoHoras], [HoraInicio], [HoraFim], [SalaId], [TurmaId], [FormadorId], [ModuloId]) VALUES (78, N'Introdução a html', CAST(3.50 AS Decimal(6, 2)), CAST(N'2020-02-04T14:30:00.000' AS DateTime), CAST(N'2020-02-04T18:00:00.000' AS DateTime), NULL, 890, 200, 22)
GO
INSERT [dbo].[Aula] ([Id], [Sumario], [DuracaoHoras], [HoraInicio], [HoraFim], [SalaId], [TurmaId], [FormadorId], [ModuloId]) VALUES (79, N'Continuação da aula anterior de html', CAST(3.50 AS Decimal(6, 2)), CAST(N'2020-02-05T14:30:00.000' AS DateTime), CAST(N'2020-02-05T18:00:00.000' AS DateTime), NULL, 890, 200, 22)
GO
INSERT [dbo].[Aula] ([Id], [Sumario], [DuracaoHoras], [HoraInicio], [HoraFim], [SalaId], [TurmaId], [FormadorId], [ModuloId]) VALUES (80, N'Continuação da aula anterior de html', CAST(3.50 AS Decimal(6, 2)), CAST(N'2020-02-06T14:30:00.000' AS DateTime), CAST(N'2020-02-06T18:00:00.000' AS DateTime), NULL, 890, 200, 22)
GO
SET IDENTITY_INSERT [dbo].[Aula] OFF
GO
SET IDENTITY_INSERT [dbo].[AvaliacaoFinal] ON 
GO
INSERT [dbo].[AvaliacaoFinal] ([Id], [FormandoId], [CursoId], [NotaFinal], [Validou]) VALUES (5, 195, 59, CAST(15.80 AS Decimal(6, 2)), NULL)
GO
INSERT [dbo].[AvaliacaoFinal] ([Id], [FormandoId], [CursoId], [NotaFinal], [Validou]) VALUES (6, 196, 59, CAST(11.80 AS Decimal(6, 2)), NULL)
GO
INSERT [dbo].[AvaliacaoFinal] ([Id], [FormandoId], [CursoId], [NotaFinal], [Validou]) VALUES (7, 197, 59, CAST(19.20 AS Decimal(6, 2)), NULL)
GO
INSERT [dbo].[AvaliacaoFinal] ([Id], [FormandoId], [CursoId], [NotaFinal], [Validou]) VALUES (8, 198, 59, CAST(14.40 AS Decimal(6, 2)), NULL)
GO
INSERT [dbo].[AvaliacaoFinal] ([Id], [FormandoId], [CursoId], [NotaFinal], [Validou]) VALUES (9, 199, 59, CAST(11.60 AS Decimal(6, 2)), NULL)
GO
SET IDENTITY_INSERT [dbo].[AvaliacaoFinal] OFF
GO
SET IDENTITY_INSERT [dbo].[AvaliacaoModular] ON 
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (8, 195, CAST(13.00 AS Decimal(6, 2)), NULL, 3, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (9, 196, CAST(16.00 AS Decimal(6, 2)), NULL, 3, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (10, 197, CAST(20.00 AS Decimal(6, 2)), NULL, 3, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (11, 198, CAST(17.00 AS Decimal(6, 2)), NULL, 3, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (12, 199, CAST(11.00 AS Decimal(6, 2)), NULL, 3, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (13, 195, CAST(17.00 AS Decimal(6, 2)), N'bom desempenho', 4, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (14, 196, CAST(11.00 AS Decimal(6, 2)), N'Precisa de estudar um pouco mais algoritmia', 4, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (15, 197, CAST(17.00 AS Decimal(6, 2)), N'bom desempenho', 4, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (16, 198, CAST(14.00 AS Decimal(6, 2)), NULL, 4, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (17, 199, CAST(9.00 AS Decimal(6, 2)), N'Desceu o desempenho', 4, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (18, 195, CAST(14.00 AS Decimal(6, 2)), NULL, 5, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (19, 196, CAST(8.00 AS Decimal(6, 2)), N'Sentiu dificuldades neste modulo', 5, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (20, 197, CAST(19.00 AS Decimal(6, 2)), NULL, 5, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (21, 198, CAST(9.00 AS Decimal(6, 2)), N'Sentiu dificuldades neste modulo', 5, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (22, 199, CAST(11.00 AS Decimal(6, 2)), NULL, 5, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (23, 195, CAST(17.00 AS Decimal(6, 2)), NULL, 6, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (24, 196, CAST(11.00 AS Decimal(6, 2)), NULL, 6, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (25, 197, CAST(20.00 AS Decimal(6, 2)), NULL, 6, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (26, 198, CAST(15.00 AS Decimal(6, 2)), NULL, 6, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (27, 199, CAST(12.00 AS Decimal(6, 2)), NULL, 6, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (28, 195, CAST(18.00 AS Decimal(6, 2)), NULL, 22, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (29, 196, CAST(13.00 AS Decimal(6, 2)), NULL, 22, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (30, 197, CAST(20.00 AS Decimal(6, 2)), NULL, 22, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (31, 198, CAST(17.00 AS Decimal(6, 2)), NULL, 22, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (32, 199, CAST(15.00 AS Decimal(6, 2)), NULL, 22, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (33, 205, CAST(16.00 AS Decimal(6, 2)), NULL, 3, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (34, 206, CAST(17.00 AS Decimal(6, 2)), NULL, 3, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (35, 207, CAST(19.00 AS Decimal(6, 2)), NULL, 3, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (36, 208, CAST(17.00 AS Decimal(6, 2)), NULL, 3, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (37, 209, CAST(19.00 AS Decimal(6, 2)), N'Excelente aluno', 3, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (38, 205, CAST(17.00 AS Decimal(6, 2)), NULL, 22, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (39, 206, CAST(14.00 AS Decimal(6, 2)), NULL, 22, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (40, 207, CAST(15.00 AS Decimal(6, 2)), NULL, 22, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (41, 208, CAST(16.00 AS Decimal(6, 2)), NULL, 22, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (42, 209, CAST(16.00 AS Decimal(6, 2)), NULL, 22, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (43, 221, CAST(16.00 AS Decimal(6, 2)), NULL, 3, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (44, 222, CAST(15.00 AS Decimal(6, 2)), NULL, 3, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (45, 223, CAST(17.00 AS Decimal(6, 2)), NULL, 3, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (46, 224, CAST(18.00 AS Decimal(6, 2)), NULL, 3, NULL, 200, 59)
GO
INSERT [dbo].[AvaliacaoModular] ([Id], [FormandoId], [NotaFinal], [Comentarios], [ModuloId], [Validou], [FormadorId], [CursoId]) VALUES (47, 225, CAST(18.00 AS Decimal(6, 2)), NULL, 3, NULL, 200, 59)
GO
SET IDENTITY_INSERT [dbo].[AvaliacaoModular] OFF
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Programas de base', N'10')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Ciências da educação', N'142')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Formação de educadores de infância', N'143')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Formação de professores do ensino básico (1º e 2º ciclos)', N'144')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Formação de professores de áreas disciplinares específicas', N'145')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Formação de professores e formadores de áreas tecnológicas', N'146')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Formação de professores/formadores e ciências da educação - programas não classificados noutra área de formação', N'149')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Belas-Artes', N'211')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Artes do espetáculo', N'212')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Audio-visuais e produção dos media', N'213')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Design', N'214')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Artesanato', N'215')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Artes - programas não classificados noutra área de formação', N'219')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Religião e teologia', N'221')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Línguas e literaturas estrangeiras', N'222')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Língua e literatura materna', N'223')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'História e arqueologia', N'225')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Filosofia e ética', N'226')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Humanidades - programas não classificados noutra área de formação', N'229')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Psicologia', N'311')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Sociologia e outros estudos', N'312')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Ciência política e cidadania', N'313')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Economia', N'314')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Ciências sociais e do comportamento - programas não classificados noutra área de formação', N'319')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Jornalismo e reportagem', N'321')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Biblioteconomia, arquivo e documentação', N'322')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Informação e jornalismo - programas não classificados noutra área de formação', N'329')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Comércio', N'341')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Marketing e publicidade', N'342')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Finanças, banca e seguros', N'343')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Contabilidade e fiscalidade', N'344')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Gestão e administração', N'345')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Secretariado e trabalho administrativo', N'346')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Enquadramento na organização/empresa', N'347')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Ciências empresariais - programas não classificados noutra área de formação', N'349')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Direito', N'380')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Biologia e bioquímica', N'421')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Ciências do ambiente', N'422')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Ciências da vida - programas não classificados noutra área de formação', N'429')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Física', N'441')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Química', N'442')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Ciências da terra', N'443')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Ciências físicas - programas não classificados noutra área de formação', N'449')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Matemática', N'461')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Estatística', N'462')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Matemática e estatística - programas não classificados noutra área de formação', N'469')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Ciências informáticas', N'481')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Informática na óptica do utilizador', N'482')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Informática - programas não classificados noutra área de formação', N'489')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Metalurgia e metalomecânica', N'521')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Electricidade e energia', N'522')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Electrónica e automação', N'523')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Tecnologia dos processos químicos', N'524')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Construção e reparação de veículos a motor', N'525')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Engenharia e técnicas afins - programas não classificados noutra área de formação', N'529')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Indústrias alimentares', N'541')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Indústrias do têxtil, vestuário, calçado e couro', N'542')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Materiais (indústrias da madeira, cortiça, papel, plástico, vidro e outros)', N'543')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Indústrias extractivas', N'544')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Indústrias transformadoras - programas não classificados noutra área de formação', N'549')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Arquitectura e urbanismo', N'581')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Construção civil e engenharia civil', N'582')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Arquitectura e construção - programas não classificados noutra área de formação', N'589')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Produção agrícola e animal', N'621')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Floricultura e jardinagem', N'622')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Silvicultura e caça', N'623')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Pescas', N'624')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Agricultura, silvicultura e pescas - programas não classificados noutra área de formação', N'629')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Ciências veterinárias', N'640')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Medicina', N'721')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Enfermagem', N'723')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Ciências dentárias', N'724')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'tecnologias de diagnóstico e terapêuticas', N'725')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Terapia e reabilitação', N'726')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Ciências farmacêuticas', N'727')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Saúde - programas não classificados noutra área de formação', N'729')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Serviço de apoio a crianças e jovens', N'761')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Trabalho social e orientação', N'762')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Serviços sociais - programas não classificados noutra área de formação', N'769')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Alfabetização', N'80')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Hotelaria e restauração', N'811')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Turismo e lazer', N'812')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Desporto', N'813')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Serviços domésticos', N'814')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Cuidados de beleza', N'815')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Serviços pessoais - programas não classificados noutra área de formação', N'819')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Serviços de transporte', N'840')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Tecnologia e proteção do ambiente', N'851')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Ambientes naturais e vida selvagem', N'852')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Serviços de saúde pública', N'853')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Protecção do ambiente - programas não classificados noutra área de formação', N'859')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Protecçao de pessoas e bens', N'861')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Segurança e higiene no trabalho', N'862')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Segurança militar', N'863')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Serviços de segurança - programas não classificados noutra área de formação', N'869')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Desenvolvimento pessoal', N'90')
GO
INSERT [dbo].[CNAEF] ([AreaFormacao], [CodigoCNAEF]) VALUES (N'Desconhecido ou não especificado', N'999')
GO
SET IDENTITY_INSERT [dbo].[Curso] ON 
GO
INSERT [dbo].[Curso] ([Id], [Nome], [DuracaoHoras], [Objetivos]) VALUES (59, N'.NET', CAST(750.00 AS Decimal(6, 2)), N'No final do curso, os formandos deverão ser capazes de:
- Modelar e inquirir informação numa base de dados relacional;
- Identificar e realizar as fases constituintes do Processo de Desenvolvimento de Software iterativo e incremental, em particular em sistemas Web;
- Realizar as fases da Engenharia de Requisitos;
- Analisar e estruturar algoritmicamente problemas computacionais e codificá-los recorrendo à Linguagem de programação C# utilizando o paradigma Orientado a Objetos;
- Entender e definir arquiteturas Cliente-Servidor, em particular em cenários Web;
- Estruturar e programar uma interface web recorrendo a HTML e Javascript;
- Estruturar aplicações e serviços em ASP.NET Core;
- Planear e trabalhar em equipa utilizando uma metodologia ágil no desenvolvimento de uma aplicação informática de média complexidade.')
GO
SET IDENTITY_INSERT [dbo].[Curso] OFF
GO
INSERT [dbo].[CursoCoordenador] ([CursoId], [PessoalId]) VALUES (59, 202)
GO
INSERT [dbo].[CursoModulo] ([CursoId], [ModuloId], [Horas], [Ordem]) VALUES (59, 22, CAST(100.00 AS Decimal(6, 2)), 1)
GO
INSERT [dbo].[CursoModulo] ([CursoId], [ModuloId], [Horas], [Ordem]) VALUES (59, 3, CAST(75.00 AS Decimal(6, 2)), 2)
GO
INSERT [dbo].[CursoModulo] ([CursoId], [ModuloId], [Horas], [Ordem]) VALUES (59, 5, CAST(225.00 AS Decimal(6, 2)), 3)
GO
INSERT [dbo].[CursoModulo] ([CursoId], [ModuloId], [Horas], [Ordem]) VALUES (59, 4, CAST(300.00 AS Decimal(6, 2)), 4)
GO
INSERT [dbo].[CursoModulo] ([CursoId], [ModuloId], [Horas], [Ordem]) VALUES (59, 6, CAST(50.00 AS Decimal(6, 2)), 5)
GO
INSERT [dbo].[EstadoFormador] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (200, 1, CAST(N'2021-04-27' AS Date), N'Inserção')
GO
INSERT [dbo].[EstadoFormador] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (201, 1, CAST(N'2021-04-27' AS Date), N'Inserção')
GO
INSERT [dbo].[EstadoFormador] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (3, 1, CAST(N'2021-04-07' AS Date), N'Alterado')
GO
INSERT [dbo].[EstadoFormador] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (2, 1, CAST(N'2021-04-13' AS Date), N'Inserção')
GO
INSERT [dbo].[EstadoFormador] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (202, 1, CAST(N'2021-04-27' AS Date), N'Inserção')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (195, 1, CAST(N'2021-04-27' AS Date), N'Inserção')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (196, 1, CAST(N'2021-04-27' AS Date), N'Inserção')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (197, 1, CAST(N'2021-04-27' AS Date), N'Inserção')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (198, 1, CAST(N'2021-04-27' AS Date), N'Inserção')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (199, 1, CAST(N'2021-04-27' AS Date), N'Inserção')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (199, 2, CAST(N'2021-04-27' AS Date), N'T1')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (196, 2, CAST(N'2021-04-27' AS Date), N'T1')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (195, 2, CAST(N'2021-04-27' AS Date), N'T1')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (197, 2, CAST(N'2021-04-27' AS Date), N'T1')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (198, 2, CAST(N'2021-04-27' AS Date), N'T1')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (198, 2, CAST(N'2021-04-27' AS Date), N'T1')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (205, 1, CAST(N'2021-04-27' AS Date), N'Inserção')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (206, 1, CAST(N'2021-04-27' AS Date), N'Inserção')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (220, 1, CAST(N'2021-04-28' AS Date), N'Inserção')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (221, 1, CAST(N'2021-04-28' AS Date), N'Inserção')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (222, 1, CAST(N'2021-04-28' AS Date), N'Inserção')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (223, 1, CAST(N'2021-04-28' AS Date), N'Inserção')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (224, 1, CAST(N'2021-04-28' AS Date), N'Inserção')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (225, 1, CAST(N'2021-04-28' AS Date), N'Inserção')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (207, 1, CAST(N'2021-04-27' AS Date), N'Inserção')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (208, 1, CAST(N'2021-04-27' AS Date), N'Inserção')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (209, 1, CAST(N'2021-04-27' AS Date), N'Inserção')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (207, 2, CAST(N'2021-04-27' AS Date), N'T2')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (208, 2, CAST(N'2021-04-27' AS Date), N'T2')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (206, 2, CAST(N'2021-04-27' AS Date), N'T2')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (205, 2, CAST(N'2021-04-27' AS Date), N'T2')
GO
INSERT [dbo].[EstadoFormando] ([PessoaId], [ListaEstadoId], [Data], [Observacoes]) VALUES (209, 2, CAST(N'2021-04-27' AS Date), N'T2')
GO
SET IDENTITY_INSERT [dbo].[Falta] ON 
GO
INSERT [dbo].[Falta] ([Id], [AulaId], [FormandoId], [HoraInicio], [HoraFim], [Justificada], [Anexo], [Duracao]) VALUES (34, 72, 199, CAST(N'2020-02-03T14:30:00.000' AS DateTime), CAST(N'2020-02-03T18:00:00.000' AS DateTime), 0, NULL, 210)
GO
INSERT [dbo].[Falta] ([Id], [AulaId], [FormandoId], [HoraInicio], [HoraFim], [Justificada], [Anexo], [Duracao]) VALUES (35, 72, 196, CAST(N'2020-02-03T14:30:00.000' AS DateTime), CAST(N'2020-02-03T18:00:00.000' AS DateTime), 0, NULL, 210)
GO
INSERT [dbo].[Falta] ([Id], [AulaId], [FormandoId], [HoraInicio], [HoraFim], [Justificada], [Anexo], [Duracao]) VALUES (36, 72, 195, CAST(N'2020-02-03T14:30:00.000' AS DateTime), CAST(N'2020-02-03T18:00:00.000' AS DateTime), 0, NULL, 210)
GO
INSERT [dbo].[Falta] ([Id], [AulaId], [FormandoId], [HoraInicio], [HoraFim], [Justificada], [Anexo], [Duracao]) VALUES (39, 80, 196, CAST(N'2020-02-06T14:30:00.000' AS DateTime), CAST(N'2020-02-06T18:00:00.000' AS DateTime), 0, NULL, 210)
GO
INSERT [dbo].[Falta] ([Id], [AulaId], [FormandoId], [HoraInicio], [HoraFim], [Justificada], [Anexo], [Duracao]) VALUES (40, 80, 195, CAST(N'2020-02-06T14:30:00.000' AS DateTime), CAST(N'2020-02-06T18:00:00.000' AS DateTime), 1, NULL, 210)
GO
SET IDENTITY_INSERT [dbo].[Falta] OFF
GO
INSERT [dbo].[Formador] ([PessoaId], [CCP], [DocenteEnsSuperior], [EstadoId]) VALUES (200, 1, 1, 1)
GO
INSERT [dbo].[Formador] ([PessoaId], [CCP], [DocenteEnsSuperior], [EstadoId]) VALUES (202, 1, 1, 1)
GO
INSERT [dbo].[Formador] ([PessoaId], [CCP], [DocenteEnsSuperior], [EstadoId]) VALUES (3, 1, 1, 1)
GO
INSERT [dbo].[Formador] ([PessoaId], [CCP], [DocenteEnsSuperior], [EstadoId]) VALUES (2, 1, 1, 1)
GO
INSERT [dbo].[Formador] ([PessoaId], [CCP], [DocenteEnsSuperior], [EstadoId]) VALUES (201, 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[FormadorModulo] ON 
GO
INSERT [dbo].[FormadorModulo] ([Id], [FormadorId], [ModuloId]) VALUES (43, 200, 3)
GO
INSERT [dbo].[FormadorModulo] ([Id], [FormadorId], [ModuloId]) VALUES (44, 200, 4)
GO
INSERT [dbo].[FormadorModulo] ([Id], [FormadorId], [ModuloId]) VALUES (45, 200, 5)
GO
INSERT [dbo].[FormadorModulo] ([Id], [FormadorId], [ModuloId]) VALUES (46, 200, 6)
GO
INSERT [dbo].[FormadorModulo] ([Id], [FormadorId], [ModuloId]) VALUES (47, 200, 22)
GO
INSERT [dbo].[FormadorModulo] ([Id], [FormadorId], [ModuloId]) VALUES (50, 201, 3)
GO
INSERT [dbo].[FormadorModulo] ([Id], [FormadorId], [ModuloId]) VALUES (51, 201, 5)
GO
INSERT [dbo].[FormadorModulo] ([Id], [FormadorId], [ModuloId]) VALUES (52, 201, 4)
GO
INSERT [dbo].[FormadorModulo] ([Id], [FormadorId], [ModuloId]) VALUES (54, 201, 22)
GO
INSERT [dbo].[FormadorModulo] ([Id], [FormadorId], [ModuloId]) VALUES (55, 201, 6)
GO
SET IDENTITY_INSERT [dbo].[FormadorModulo] OFF
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (890, 50, CAST(77.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (890, 44, CAST(301.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (890, 46, CAST(49.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (890, 47, CAST(91.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (892, 43, CAST(77.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (892, 52, CAST(301.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (892, 45, CAST(224.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (892, 55, CAST(49.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (892, 47, CAST(91.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (894, 43, CAST(77.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (894, 52, CAST(301.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (894, 45, CAST(224.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (894, 55, CAST(49.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (894, 54, CAST(91.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (890, 45, CAST(224.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (891, 43, CAST(77.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (891, 52, CAST(350.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (891, 45, CAST(225.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (891, 55, CAST(49.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (891, 54, CAST(107.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (893, 43, CAST(77.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (893, 44, CAST(301.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (893, 51, CAST(224.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (893, 55, CAST(49.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[FormadorModuloTurma] ([TurmaId], [FormadorModuloId], [Horas]) VALUES (893, 54, CAST(91.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Formando] ([PessoaId], [IBAN], [Bolsa], [EstadoId]) VALUES (195, N'PT50000788573535801987712', 1, 2)
GO
INSERT [dbo].[Formando] ([PessoaId], [IBAN], [Bolsa], [EstadoId]) VALUES (196, N'PT50000788573535801987712', 1, 2)
GO
INSERT [dbo].[Formando] ([PessoaId], [IBAN], [Bolsa], [EstadoId]) VALUES (197, N'PT50000788573535801987712', 1, 2)
GO
INSERT [dbo].[Formando] ([PessoaId], [IBAN], [Bolsa], [EstadoId]) VALUES (198, N'PT50000788573535801987712', 1, 2)
GO
INSERT [dbo].[Formando] ([PessoaId], [IBAN], [Bolsa], [EstadoId]) VALUES (199, N'PT50000788573535801987712', 1, 2)
GO
INSERT [dbo].[Formando] ([PessoaId], [IBAN], [Bolsa], [EstadoId]) VALUES (205, N'PT50000788573535801987712', 1, 2)
GO
INSERT [dbo].[Formando] ([PessoaId], [IBAN], [Bolsa], [EstadoId]) VALUES (206, N'PT50000788573535801987712', 1, 2)
GO
INSERT [dbo].[Formando] ([PessoaId], [IBAN], [Bolsa], [EstadoId]) VALUES (207, N'PT50000788573535801987712', 1, 2)
GO
INSERT [dbo].[Formando] ([PessoaId], [IBAN], [Bolsa], [EstadoId]) VALUES (208, N'PT50000788573535801987712', 1, 2)
GO
INSERT [dbo].[Formando] ([PessoaId], [IBAN], [Bolsa], [EstadoId]) VALUES (209, N'PT50000788573535801987712', 1, 2)
GO
INSERT [dbo].[Formando] ([PessoaId], [IBAN], [Bolsa], [EstadoId]) VALUES (220, N'PT50000788573535801987712', 1, 1)
GO
INSERT [dbo].[Formando] ([PessoaId], [IBAN], [Bolsa], [EstadoId]) VALUES (221, N'PT50000788573535801987712', 1, 1)
GO
INSERT [dbo].[Formando] ([PessoaId], [IBAN], [Bolsa], [EstadoId]) VALUES (222, N'PT50000788573535801987712', 1, 1)
GO
INSERT [dbo].[Formando] ([PessoaId], [IBAN], [Bolsa], [EstadoId]) VALUES (223, N'PT50000788573535801987712', 1, 1)
GO
INSERT [dbo].[Formando] ([PessoaId], [IBAN], [Bolsa], [EstadoId]) VALUES (224, N'PT50000788573535801987712', 1, 1)
GO
INSERT [dbo].[Formando] ([PessoaId], [IBAN], [Bolsa], [EstadoId]) VALUES (225, N'PT50000788573535801987712', 1, 1)
GO
INSERT [dbo].[Formando] ([PessoaId], [IBAN], [Bolsa], [EstadoId]) VALUES (219, N'PT50000788573535801987712', 1, 7)
GO
INSERT [dbo].[Funcoes] ([Nome]) VALUES (N'Administrador')
GO
INSERT [dbo].[Funcoes] ([Nome]) VALUES (N'Coordenador')
GO
INSERT [dbo].[Funcoes] ([Nome]) VALUES (N'Secretariado')
GO
INSERT [dbo].[Funcoes] ([Nome]) VALUES (N'Formador e Coordenador')
GO
INSERT [dbo].[Funcoes] ([Nome]) VALUES (N'Formador')
GO
INSERT [dbo].[Habilitacoes] ([Codigo], [HabilitacoesLiterarias]) VALUES (1, N'Menos de 4 anos de Escolaridade')
GO
INSERT [dbo].[Habilitacoes] ([Codigo], [HabilitacoesLiterarias]) VALUES (2, N'1º ciclo do Ensino Básico')
GO
INSERT [dbo].[Habilitacoes] ([Codigo], [HabilitacoesLiterarias]) VALUES (3, N'2º ciclo do Ensino Básico')
GO
INSERT [dbo].[Habilitacoes] ([Codigo], [HabilitacoesLiterarias]) VALUES (4, N'3º ciclo do Ensino Básico')
GO
INSERT [dbo].[Habilitacoes] ([Codigo], [HabilitacoesLiterarias]) VALUES (5, N'11º Ano')
GO
INSERT [dbo].[Habilitacoes] ([Codigo], [HabilitacoesLiterarias]) VALUES (6, N'12º Ano (Ensino Secundário)')
GO
INSERT [dbo].[Habilitacoes] ([Codigo], [HabilitacoesLiterarias]) VALUES (7, N'Curso tecnológico/profissional/outros (Nível III)')
GO
INSERT [dbo].[Habilitacoes] ([Codigo], [HabilitacoesLiterarias]) VALUES (8, N'Bacharelato')
GO
INSERT [dbo].[Habilitacoes] ([Codigo], [HabilitacoesLiterarias]) VALUES (9, N'Licenciatura pré-Bolonha')
GO
INSERT [dbo].[Habilitacoes] ([Codigo], [HabilitacoesLiterarias]) VALUES (10, N'Licenciatura (1º ciclo)')
GO
INSERT [dbo].[Habilitacoes] ([Codigo], [HabilitacoesLiterarias]) VALUES (11, N'Mestrado pré-Bolonha')
GO
INSERT [dbo].[Habilitacoes] ([Codigo], [HabilitacoesLiterarias]) VALUES (12, N'Mestrado Integrado')
GO
INSERT [dbo].[Habilitacoes] ([Codigo], [HabilitacoesLiterarias]) VALUES (13, N'Mestrado (2º ciclo)')
GO
INSERT [dbo].[Habilitacoes] ([Codigo], [HabilitacoesLiterarias]) VALUES (14, N'Doutoramento')
GO
INSERT [dbo].[Habilitacoes] ([Codigo], [HabilitacoesLiterarias]) VALUES (15, N'Pós-Graduação')
GO
INSERT [dbo].[Habilitacoes] ([Codigo], [HabilitacoesLiterarias]) VALUES (16, N'Curso de Especialização Tecnológica')
GO
INSERT [dbo].[Habilitacoes] ([Codigo], [HabilitacoesLiterarias]) VALUES (99, N'Habilitação ignorada')
GO
SET IDENTITY_INSERT [dbo].[ListaEstadosFormador] ON 
GO
INSERT [dbo].[ListaEstadosFormador] ([Id], [Nome]) VALUES (1, N'Ativo')
GO
INSERT [dbo].[ListaEstadosFormador] ([Id], [Nome]) VALUES (2, N'Inativo')
GO
SET IDENTITY_INSERT [dbo].[ListaEstadosFormador] OFF
GO
SET IDENTITY_INSERT [dbo].[ListaEstadosFormando] ON 
GO
INSERT [dbo].[ListaEstadosFormando] ([Id], [Nome]) VALUES (1, N'Inscrito')
GO
INSERT [dbo].[ListaEstadosFormando] ([Id], [Nome]) VALUES (2, N'A frequentar')
GO
INSERT [dbo].[ListaEstadosFormando] ([Id], [Nome]) VALUES (3, N'A frequentar - nova turma')
GO
INSERT [dbo].[ListaEstadosFormando] ([Id], [Nome]) VALUES (4, N'A frequentar - novo curso')
GO
INSERT [dbo].[ListaEstadosFormando] ([Id], [Nome]) VALUES (5, N'Concluído')
GO
INSERT [dbo].[ListaEstadosFormando] ([Id], [Nome]) VALUES (6, N'Concluído - parcialmente')
GO
INSERT [dbo].[ListaEstadosFormando] ([Id], [Nome]) VALUES (7, N'Desistiu')
GO
INSERT [dbo].[ListaEstadosFormando] ([Id], [Nome]) VALUES (8, N'Rescisão de contrato')
GO
SET IDENTITY_INSERT [dbo].[ListaEstadosFormando] OFF
GO
SET IDENTITY_INSERT [dbo].[Local] ON 
GO
INSERT [dbo].[Local] ([Id], [Nome]) VALUES (19, N'ISCTE - Lisboa')
GO
INSERT [dbo].[Local] ([Id], [Nome]) VALUES (21, N'213')
GO
INSERT [dbo].[Local] ([Id], [Nome]) VALUES (20, N'Startup Sintra - Rio de Mouro')
GO
SET IDENTITY_INSERT [dbo].[Local] OFF
GO
SET IDENTITY_INSERT [dbo].[Modulo] ON 
GO
INSERT [dbo].[Modulo] ([Id], [Nome], [Horas], [Objetivos], [ConteudosProgramaticos], [SistemaAvaliacao], [Bibliografia], [SoftwareHardware]) VALUES (3, N'Conceitos e estrutura de bases de dados', CAST(77.00 AS Decimal(6, 2)), N'Esta unidade de formação visa capacitar os formandos com conhecimentos introdutórios de bases de dados suportadas por modelos relacionais e linguagem SQL. No final desta unidade, os formandos deverão ser capazes de estruturar informação com base no modelo relacional, criar bases de dados, disponibilizar e manipular registos e criar interrogações a partir da linguagem SQL.', N'1.1 Conceitos gerais de Bases de Dados

1.2 Modelo relacional
Relações e chaves primáriasc
Chaves estrangeiras e regras de integridade

1.3 Introdução à linguagem SQL
Comando Select
Manipulação de dados
Junção de tabelas
Funções de agregação', N'Avaliação por projeto', N'Damas, L. (2017). SQL–Structured Query Language. FCA. Isbn: 9789727228294', N'SQL Lite Browser (https://sqlitebrowser.org/dl/)')
GO
INSERT [dbo].[Modulo] ([Id], [Nome], [Horas], [Objetivos], [ConteudosProgramaticos], [SistemaAvaliacao], [Bibliografia], [SoftwareHardware]) VALUES (4, N'Laboratório C#/.Net e ferramentas complementares', CAST(301.00 AS Decimal(6, 2)), N'Esta unidade de formação tem por objetivo a prática de projetos de portefólio de  desenvolvimento aplicacional utilizando os conhecimentos teóricos e práticos obtidos nas  unidades anteriores. Os formandos deverão implementar diversos projetos em pequenas  equipas aplicando o método Agile com Scrum diário e user stories bem documentadas.
', N'3.1 Fundamentos de Programação 
Introdução às boas práticas de Product Ownership 
Modularidade do Produto 
Treino de apresentação de Produto 
Boas práticas de UX UI 

3.2 Dia a dia do Programador 
Introdução à metodologia SCRUM-Agile 
Trabalho em equipa 
Reporte de Problemas 
Boas práticas de código 
TDD - Test-driven development 
BDD - Behavior-driven development 
Open-source 

3.3 Implementação de projetos', N'Avaliação por projeto', N'Robbins, J. Learning Web Design: A Beginner''s Guide to HTML, CSS, JavaScript, and Web  Graphics, O''Reilly, ISBN: 978-1491960202', N'Visual Studio Code (https://code.visualstudio.com/)')
GO
INSERT [dbo].[Modulo] ([Id], [Nome], [Horas], [Objetivos], [ConteudosProgramaticos], [SistemaAvaliacao], [Bibliografia], [SoftwareHardware]) VALUES (5, N'Fundamentos de programação em C#/.net e Angular', CAST(224.00 AS Decimal(6, 2)), N'Esta unidade de formação promove o desenvolvimento de competências de programação, com ênfase no paradigma Orientado a Objetos, através da aprendizagem de C#, ASP.Net Core e Angular 9. No final da unidade é esperado que os formandos demonstrem as competências adquiridas através do desenvolvimento de um projeto.', N'1.1 C#
Introdução à Programação Orientada a Objetos em C# (OOP)
Introdução à Framework .Net Core e ao Visual Studio
Criação de aplicação na consola
Tipos de dados e conversão explícita de dados
Manipulação de strings e datas
Instruções de decisão e operadores lógicos
Estruturas de repetição
Estruturas de Dados
Funções e procedimentos
Debug
Ficheiros
Estruturas de dados
Protocolo HTTP
Sintaxe e regras HTML
Elementos HTML
Sintaxe e Regras CSS
Propriedades CSS
CSS3 Media Queries
Responsive Web Design
Fundamentos de IHM, usabilidade e UX

1.2 ASP.Net Core
Introdução às aplicações ASP. Core
Desenvolvimento de Modelos
Desenvolvimento de Controladores
Desenvolvimento de Views
Teste, Debugging e deployment de aplicações
UX Responsivo com estilos e criação de páginas responsivas com JavaScript e jQuery
Utilização de Azure Web Services
Implementação de APIs

1.3 Angular 9
Introdução a Typescript
Modules
Routing
Components
Directives
Services
Forms
Http
Observables', N'Avaliação por projeto', N'António Trigo, Jorge Henriques (2020) - Aprenda a programar com C#. Lisboa : Sílabo. ISBN: 978-989-561-130-0', N'Visual Studio Code (https://code.visualstudio.com/)')
GO
INSERT [dbo].[Modulo] ([Id], [Nome], [Horas], [Objetivos], [ConteudosProgramaticos], [SistemaAvaliacao], [Bibliografia], [SoftwareHardware]) VALUES (6, N'Competências para o Mercado de Trabalho', CAST(49.00 AS Decimal(6, 2)), N'Esta unidade de formação tem como objetivo promover a compreensão e aquisição de competências iniciais e fundamentais para o mundo do trabalho.', N'Seminário "Gestão de Conflitos"
Seminário "Gestão de Projetos"
Seminário "RGPD: os princípios e a prática"
Seminário "Economia e Emprego"', N'Estudos de Caso', N'N/A', N'N/A')
GO
INSERT [dbo].[Modulo] ([Id], [Nome], [Horas], [Objetivos], [ConteudosProgramaticos], [SistemaAvaliacao], [Bibliografia], [SoftwareHardware]) VALUES (22, N'Princípios de desenvolvimento de programação', CAST(91.00 AS Decimal(6, 2)), N'Esta unidade de formação tem como objetivo promover a compreensão e aquisição de competências iniciais e fundamentais de programação, em particular em HTML5, CSS3 e Javascript. No final da unidade, os formandos deverão ser capazes de produzir um projeto onde demonstrem a aquisição dos conceitos abordados.', N'1.1 HTML5 e CSS3
Conceitos e páginas de Internet
Protocolo HTTP
Sintaxe e regras HTML
Elementos HTML
Sintaxe e Regras CSS
Propriedades CSS
CSS3 Media Queries
Responsive Web Design
Fundamentos de IHM, usabilidade e UX

1.2 Fundamentos de Programação
Conceito básicos de programação
Estrutura lógica de uma aplicação
Variáveis, tipos primitivos de dados e conversões (cast) utilizando Javascript
Expressões e operações
Regras de precedência, ordens de avaliação
Estruturas de decisão
Estruturas cíclicas
Definir e invocar métodos
Modular código usando métodos reutilizáveis', N'Avaliação por projeto', N'Lubbers, P., Albers, B., and Salim, F. (2011). Pro HTML5 Programming (2nd. ed.). Apress, USA. ISBN: 978-1-4302-3864-5
Flanagan, D. (2020). JavaScript: The Definitive Guide (7th. Ed.), O''Reilly Media, Inc. ISBN: 9781491952023
Crockford, D. (2008). JavaScript: The Good Parts, O''Reilly Media, Inc. ISBN: 0596517742', N'Visual Studio Code (https://code.visualstudio.com/)')
GO
SET IDENTITY_INSERT [dbo].[Modulo] OFF
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'AD', N'AND', N'20', N'Andorra')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'AE', N'ARE', N'784', N'Emiratos Árabes Unidos')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'AF', N'AFG', N'4', N'Afeganistão')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'AG', N'ATG', N'28', N'Antigua e Barbuda')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'AI', N'AIA', N'660', N'Anguilla')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'AL', N'ALB', N'8', N'Albânia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'AM', N'ARM', N'51', N'Arménia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'AN', N'ANT', N'530', N'Antilhas Holandesas')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'AO', N'AGO', N'24', N'Angola')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'AQ', N'ATA', N'10', N'Antárctida')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'AR', N'ARG', N'32', N'Argentina')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'AS', N'ASM', N'16', N'Samoa Americana')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'AT', N'AUT', N'40', N'Áustria')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'AU', N'AUS', N'36', N'Austrália')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'AW', N'ABW', N'533', N'Aruba')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'AX', N'ALA', N'248', N'Åland, Ilhas')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'AZ', N'AZE', N'31', N'Azerbeijão')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'BA', N'BIH', N'70', N'Bósnia-Herzegovina')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'BB', N'BRB', N'52', N'Barbados')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'BD', N'BGD', N'50', N'Bangladesh')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'BE', N'BEL', N'56', N'Bélgica')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'BF', N'BFA', N'854', N'Burkina Faso')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'BG', N'BGR', N'100', N'Bulgária')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'BH', N'BHR', N'48', N'Bahrain')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'BI', N'BDI', N'108', N'Burundi')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'BJ', N'BEN', N'204', N'Benin')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'BM', N'BMU', N'60', N'Bermuda')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'BN', N'BRN', N'96', N'Brunei')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'BO', N'BOL', N'68', N'Bolívia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'BR', N'BRA', N'76', N'Brasil')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'BS', N'BHS', N'44', N'Bahamas')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'BT', N'BTN', N'64', N'Butão')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'BV', N'BVT', N'74', N'Bouvet, Ilha')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'BW', N'BWA', N'72', N'Botswana')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'BY', N'BLR', N'112', N'Bielo-Rússia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'BZ', N'BLZ', N'84', N'Belize')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'CA', N'CAN', N'124', N'Canadá')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'CC', N'CCK', N'166', N'Cocos, Ilhas')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'CD', N'COD', N'180', N'Congo, República Democrática do (antigo Zaire)')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'CF', N'CAF', N'140', N'Centro-africana, República')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'CG', N'COG', N'178', N'Congo, República do')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'CH', N'CHE', N'756', N'Suíça')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'CI', N'CIV', N'384', N'Costa do Marfim')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'CK', N'COK', N'184', N'Cook, Ilhas')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'CL', N'CHL', N'152', N'Chile')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'CM', N'CMR', N'120', N'Camarões')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'CN', N'CHN', N'156', N'China')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'CO', N'COL', N'170', N'Colômbia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'CR', N'CRI', N'188', N'Costa Rica')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'CU', N'CUB', N'192', N'Cuba')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'CV', N'CPV', N'132', N'Cabo Verde')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'CX', N'CXR', N'162', N'Christmas, Ilha')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'CY', N'CYP', N'196', N'Chipre')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'CZ', N'CZE', N'203', N'Checa, República')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'DE', N'DEU', N'276', N'Alemanha')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'DJ', N'DJI', N'262', N'Djibouti')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'DK', N'DNK', N'208', N'Dinamarca')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'DM', N'DMA', N'212', N'Dominica')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'DO', N'DOM', N'214', N'Dominicana, República')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'DZ', N'DZA', N'12', N'Argélia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'EC', N'ECU', N'218', N'Equador')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'EE', N'EST', N'233', N'Estónia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'EG', N'EGY', N'818', N'Egipto')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'EH', N'ESH', N'732', N'Saara Ocidental')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'ER', N'ERI', N'232', N'Eritreia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'ES', N'ESP', N'724', N'Espanha')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'ET', N'ETH', N'231', N'Etiópia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'FI', N'FIN', N'246', N'Finlândia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'FJ', N'FJI', N'242', N'Fiji')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'FK', N'FLK', N'238', N'Malvinas, Ilhas (Falkland)')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'FM', N'FSM', N'583', N'Micronésia, Estados Federados da')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'FO', N'FRO', N'234', N'Faroe, Ilhas')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'FR', N'FRA', N'250', N'França')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'GA', N'GAB', N'266', N'Gabão')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'GB', N'GBR', N'826', N'Reino Unido da Grã-Bretanha e Irlanda do Norte')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'GD', N'GRD', N'308', N'Grenada')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'GE', N'GEO', N'268', N'Geórgia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'GF', N'GUF', N'254', N'Guiana Francesa')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'GG', N'GGY', N'831', N'Guernsey')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'GH', N'GHA', N'288', N'Gana')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'GI', N'GIB', N'292', N'Gibraltar')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'GL', N'GRL', N'304', N'Gronelândia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'GM', N'GMB', N'270', N'Gâmbia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'GN', N'GIN', N'324', N'Guiné-Conacri')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'GP', N'GLP', N'312', N'Guadeloupe')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'GQ', N'GNQ', N'226', N'Guiné Equatorial')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'GR', N'GRC', N'300', N'Grécia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'GS', N'SGS', N'239', N'Geórgia do Sul e Sandwich do Sul, Ilhas')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'GT', N'GTM', N'320', N'Guatemala')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'GU', N'GUM', N'316', N'Guam')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'GW', N'GNB', N'624', N'Guiné-Bissau')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'GY', N'GUY', N'328', N'Guiana')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'HK', N'HKG', N'344', N'Hong Kong')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'HM', N'HMD', N'334', N'Heard e Ilhas McDonald, Ilha')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'HN', N'HND', N'340', N'Honduras')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'HR', N'HRV', N'191', N'Croácia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'HT', N'HTI', N'332', N'Haiti')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'HU', N'HUN', N'348', N'Hungria')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'ID', N'IDN', N'360', N'Indonésia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'IE', N'IRL', N'372', N'Irlanda')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'IL', N'ISR', N'376', N'Israel')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'IM', N'IMN', N'833', N'Man, Ilha de')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'IN', N'IND', N'356', N'Índia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'IO', N'IOT', N'86', N'Território Britânico do Oceano Índico')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'IQ', N'IRQ', N'368', N'Iraque')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'IR', N'IRN', N'364', N'Irão')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'IS', N'ISL', N'352', N'Islândia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'IT', N'ITA', N'380', N'Itália')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'JE', N'JEY', N'832', N'Jersey')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'JM', N'JAM', N'388', N'Jamaica')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'JO', N'JOR', N'400', N'Jordânia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'JP', N'JPN', N'392', N'Japão')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'KE', N'KEN', N'404', N'Quénia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'KG', N'KGZ', N'417', N'Quirguistão')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'KH', N'KHM', N'116', N'Cambodja')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'KI', N'KIR', N'296', N'Kiribati')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'KM', N'COM', N'174', N'Comores')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'KN', N'KNA', N'659', N'São Cristóvão e Névis (Saint Kitts e Nevis)')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'KP', N'PRK', N'408', N'Coreia, República Democrática da (Coreia do Norte)')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'KR', N'KOR', N'410', N'Coreia do Sul')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'KW', N'KWT', N'414', N'Kuwait')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'KY', N'CYM', N'136', N'Cayman, Ilhas')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'KZ', N'KAZ', N'398', N'Cazaquistão')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'LA', N'LAO', N'418', N'Laos')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'LB', N'LBN', N'422', N'Líbano')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'LC', N'LCA', N'662', N'Santa Lúcia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'LI', N'LIE', N'438', N'Liechtenstein')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'LK', N'LKA', N'144', N'Sri Lanka')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'LR', N'LBR', N'430', N'Libéria')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'LS', N'LSO', N'426', N'Lesoto')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'LT', N'LTU', N'440', N'Lituânia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'LU', N'LUX', N'442', N'Luxemburgo')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'LV', N'LVA', N'428', N'Letónia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'LY', N'LBY', N'434', N'Líbia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'MA', N'MAR', N'504', N'Marrocos')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'MC', N'MCO', N'492', N'Mónaco')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'MD', N'MDA', N'498', N'Moldávia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'ME', N'MNE', N'499', N'Montenegro')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'MG', N'MDG', N'450', N'Madagáscar')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'MH', N'MHL', N'584', N'Marshall, Ilhas')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'MK', N'MKD', N'807', N'Macedónia, República da')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'ML', N'MLI', N'466', N'Mali')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'MM', N'MMR', N'104', N'Myanmar (antiga Birmânia)')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'MN', N'MNG', N'496', N'Mongólia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'MO', N'MAC', N'446', N'Macau')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'MP', N'MNP', N'580', N'Marianas Setentrionais')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'MQ', N'MTQ', N'474', N'Martinica')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'MR', N'MRT', N'478', N'Mauritânia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'MS', N'MSR', N'500', N'Montserrat')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'MT', N'MLT', N'470', N'Malta')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'MU', N'MUS', N'480', N'Maurícia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'MV', N'MDV', N'462', N'Maldivas')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'MW', N'MWI', N'454', N'Malawi')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'MX', N'MEX', N'484', N'México')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'MY', N'MYS', N'458', N'Malásia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'MZ', N'MOZ', N'508', N'Moçambique')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'NA', N'NAM', N'516', N'Namíbia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'NC', N'NCL', N'540', N'Nova Caledónia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'NE', N'NER', N'562', N'Níger')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'NF', N'NFK', N'574', N'Norfolk, Ilha')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'NG', N'NGA', N'566', N'Nigéria')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'NI', N'NIC', N'558', N'Nicarágua')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'NL', N'NLD', N'528', N'Países Baixos (Holanda)')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'NO', N'NOR', N'578', N'Noruega')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'NP', N'NPL', N'524', N'Nepal')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'NR', N'NRU', N'520', N'Nauru')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'NU', N'NIU', N'570', N'Niue')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'NZ', N'NZL', N'554', N'Nova Zelândia (Aotearoa)')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'OM', N'OMN', N'512', N'Oman')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'PA', N'PAN', N'591', N'Panamá')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'PE', N'PER', N'604', N'Peru')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'PF', N'PYF', N'258', N'Polinésia Francesa')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'PG', N'PNG', N'598', N'Papua-Nova Guiné')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'PH', N'PHL', N'608', N'Filipinas')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'PK', N'PAK', N'586', N'Paquistão')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'PL', N'POL', N'616', N'Polónia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'PM', N'SPM', N'666', N'Saint Pierre et Miquelon')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'PN', N'PCN', N'612', N'Pitcairn')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'PR', N'PRI', N'630', N'Porto Rico')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'PS', N'PSE', N'275', N'Palestina')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'PT', N'PRT', N'620', N'Portugal')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'PW', N'PLW', N'585', N'Palau')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'PY', N'PRY', N'600', N'Paraguai')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'QA', N'QAT', N'634', N'Qatar')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'RE', N'REU', N'638', N'Reunião')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'RO', N'ROU', N'642', N'Roménia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'RS', N'SRB', N'688', N'Sérvia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'RU', N'RUS', N'643', N'Rússia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'RW', N'RWA', N'646', N'Ruanda')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'SA', N'SAU', N'682', N'Arábia Saudita')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'SB', N'SLB', N'90', N'Salomão, Ilhas')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'SC', N'SYC', N'690', N'Seychelles')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'SD', N'SDN', N'736', N'Sudão')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'SE', N'SWE', N'752', N'Suécia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'SG', N'SGP', N'702', N'Singapura')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'SH', N'SHN', N'654', N'Santa Helena')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'SI', N'SVN', N'705', N'Eslovénia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'SJ', N'SJM', N'744', N'Svalbard e Jan Mayen')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'SK', N'SVK', N'703', N'Eslováquia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'SL', N'SLE', N'694', N'Serra Leoa')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'SM', N'SMR', N'674', N'San Marino')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'SN', N'SEN', N'686', N'Senegal')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'SO', N'SOM', N'706', N'Somália')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'SR', N'SUR', N'740', N'Suriname')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'ST', N'STP', N'678', N'São Tomé e Príncipe')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'SV', N'SLV', N'222', N'El Salvador')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'SY', N'SYR', N'760', N'Síria')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'SZ', N'SWZ', N'748', N'Suazilândia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'TC', N'TCA', N'796', N'Turks e Caicos')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'TD', N'TCD', N'148', N'Chade')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'TF', N'ATF', N'260', N'Terras Austrais e Antárticas Francesas (TAAF)')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'TG', N'TGO', N'768', N'Togo')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'TH', N'THA', N'764', N'Tailândia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'TJ', N'TJK', N'762', N'Tajiquistão')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'TK', N'TKL', N'772', N'Toquelau')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'TL', N'TLS', N'626', N'Timor-Leste')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'TM', N'TKM', N'795', N'Turquemenistão')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'TN', N'TUN', N'788', N'Tunísia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'TO', N'TON', N'776', N'Tonga')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'TR', N'TUR', N'792', N'Turquia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'TT', N'TTO', N'780', N'Trindade e Tobago')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'TV', N'TUV', N'798', N'Tuvalu')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'TW', N'TWN', N'158', N'Taiwan')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'TZ', N'TZA', N'834', N'Tanzânia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'UA', N'UKR', N'804', N'Ucrânia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'UG', N'UGA', N'800', N'Uganda')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'UM', N'UMI', N'581', N'Menores Distantes dos Estados Unidos, Ilhas')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'US', N'USA', N'840', N'Estados Unidos da América')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'UY', N'URY', N'858', N'Uruguai')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'UZ', N'UZB', N'860', N'Usbequistão')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'VA', N'VAT', N'336', N'Vaticano')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'VC', N'VCT', N'670', N'São Vicente e Granadinas')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'VE', N'VEN', N'862', N'Venezuela')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'VG', N'VGB', N'92', N'Virgens Britânicas, Ilhas')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'VI', N'VIR', N'850', N'Virgens Americanas, Ilhas')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'VN', N'VNM', N'704', N'Vietname')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'VU', N'VUT', N'548', N'Vanuatu')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'WF', N'WLF', N'876', N'Wallis e Futuna')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'WS', N'WSM', N'882', N'Samoa (Samoa Ocidental)')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'YE', N'YEM', N'887', N'Iémen')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'YT', N'MYT', N'175', N'Mayotte')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'ZA', N'ZAF', N'710', N'África do Sul')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'ZM', N'ZMB', N'894', N'Zâmbia')
GO
INSERT [dbo].[Paises] ([iso], [iso3], [numcode], [nome]) VALUES (N'ZW', N'ZWE', N'716', N'Zimbabwe')
GO
SET IDENTITY_INSERT [dbo].[Perfil] ON 
GO
INSERT [dbo].[Perfil] ([Id], [Nome]) VALUES (1, N'Administrador')
GO
INSERT [dbo].[Perfil] ([Id], [Nome]) VALUES (2, N'Coordenador')
GO
INSERT [dbo].[Perfil] ([Id], [Nome]) VALUES (3, N'Formador')
GO
INSERT [dbo].[Perfil] ([Id], [Nome]) VALUES (4, N'Formando')
GO
INSERT [dbo].[Perfil] ([Id], [Nome]) VALUES (5, N'FormadorCoordenador')
GO
SET IDENTITY_INSERT [dbo].[Perfil] OFF
GO
SET IDENTITY_INSERT [dbo].[Pessoa] ON 
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (2, N'Coordenador', NULL, N'coor', N'$2a$11$.8HMCvr0XPODi7qSFGA6EufZCwzzJepVMvX5ZIiXxESncNbImAIpS', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (3, N'Formador', NULL, N'formador', N'$2a$11$.8HMCvr0XPODi7qSFGA6EufZCwzzJepVMvX5ZIiXxESncNbImAIpS', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (153, N'Raquel Félix', CAST(N'1980-04-20' AS Date), N'secretariado_upskills@iscte-iul.pt', N'$2a$11$rBdV/uN/BBW6klfUCjk5y.4Jcab6DVoGMg/9iZ948zSok7Shtdzu6', N'Feminino', N'291252320', N'16753259 6 ZY7', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-224', 851, N'10', N'PT', NULL, 1, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (182, N'Teresa Evaristo', CAST(N'1970-07-26' AS Date), N'teresa_evaristo@iscte-iul.pt', N'$2a$11$WPOoQ7FdYThnPAhgfMCXreRr9rgyOcy2zS56oAIrRVntZFlrLcbsK', N'Feminino', N'247689130', N'17256783', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-224', 142, N'14', N'PT', NULL, 1, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (183, N'Admin', NULL, N'admin', N'$2a$11$.8HMCvr0XPODi7qSFGA6EufZCwzzJepVMvX5ZIiXxESncNbImAIpS', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (195, N'Juliana Queiroz', CAST(N'1986-07-16' AS Date), N'juliana@mail.com', N'$2a$11$2SDpeRtapnsTeFtpmHNYU.G3DwaM6d392pBZhgXfTTacoR9C8t93O', N'Feminino', N'243906692', N'14687436', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-224 ', 321, N'13', N'PT', NULL, 4, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (196, N'Diogo Freire', CAST(N'1985-06-18' AS Date), N'diogo@mail.com', N'$2a$11$Uf0ZWb/UOwKrJ35RDztpzO4srBjuG.iU1LQuIuNbt1nZfi69TRilG', N'Masculino', N'243906692', N'16995516', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-224', 481, N'10', N'PT', NULL, 4, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (197, N'Nelson Silveira', CAST(N'1978-12-09' AS Date), N'nelson@mail.com', N'$2a$11$6kd3ilsBQYtw9i0AfENEnuea9Kz0ZRcsQsizH79kLnhfsfFDteFIO', N'Masculino', N'243906692', N'16995516', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-224 ', 813, N'7', N'PT', NULL, 4, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (198, N'Xavier Fernandez', CAST(N'1988-04-23' AS Date), N'xavier@mail.com', N'$2a$11$O38380BCMyGu4vhLUl7k2OnAS2SLYMrI01RFjG4.O8IUKMWbRi6Ba', N'Masculino', N'16995516', N'243906692', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-224', 214, N'10', N'PT', NULL, 4, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (199, N'André Ribeiro', CAST(N'1980-09-26' AS Date), N'andre@mail.com', N'$2a$11$epaNnh7ayFu1srjdlNLUMuK4dqUDmAbCoEuKEQSyPkmW/zFTtSC22', N'Masculino', N'243906692', N'16995516', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-224 ', 481, N'12', N'PT', NULL, 4, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (200, N'Paulo Pereira', CAST(N'1960-07-28' AS Date), N'paulo@mail.com', N'$2a$11$49gQdc1k/jFIqPFg5VZnLuLVFI7himUTzSmZzOYQr7x6wCu78Ka.e', N'Masculino', N'243906692', N'16995516', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-224', 481, N'11', N'PT', NULL, 3, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (201, N'Fernando Costa', CAST(N'1980-05-23' AS Date), N'fernand@mail.com', N'$2a$11$f6p/BQyuqbbW9vxcq8/W6efyvi1jcpisS7kKnVVLldz9L7G9mVEl6', N'Masculino', N'243906692', N'16995516', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-224', 481, N'11', N'PT', NULL, 3, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (202, N'Ana Peixoto', CAST(N'1980-09-18' AS Date), N'ana@mail.com', N'$2a$11$h6kpvSdTsuH7zvAqxvxJ5eMIL6aPLJ4fvHYtcX2/qlC.t95Z2C95m', N'Feminino', N'243906692', N'16995516', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-224', 481, N'14', N'PT', NULL, 2, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (205, N'Pedro Alves', CAST(N'1986-08-24' AS Date), N'pedro@mail.com', N'$2a$11$5EA2gKMZDHtCMNfqRhIc9uNaMzb7b3.VnSiWFafUxEdC2q699t/nC', N'Masculino', N'243906692', N'16995516', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-224 ', 145, N'10', N'PT', NULL, 4, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (206, N'Isabel Rocha', CAST(N'1985-07-23' AS Date), N'isabel@mail.com', N'$2a$11$4uozlu9n9LLFyNX8T7TBtun4tdQnOLd58xvF1DtmuHEqwO0asWxgu', N'Feminino', N'243906692', N'16995516', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-225', 146, N'12', N'PT', NULL, 4, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (207, N'Daniel Silva', CAST(N'1980-04-13' AS Date), N'daniel@mail.com', N'$2a$11$IXiB8atPCyTF50EcqysqG.w.b0/CtKEB/0Qg61D2W9EbkPLrMrLrK', N'Masculino', N'243906692', N'16995516', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-226', 214, N'14', N'PT', NULL, 4, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (208, N'Fátima Mota', CAST(N'1984-03-23' AS Date), N'fatima@mail.com', N'$2a$11$lTT6WytIX1P3XroJ/525gOlxky0OheH4nlegzs/MG5vq7Dq7hqdXu', N'Feminino', N'243906692', N'16995516', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-227', 312, N'10', N'PT', NULL, 4, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (209, N'Raquel Miranda', CAST(N'1985-12-18' AS Date), N'raquel@mail.com', N'$2a$11$U/utmKklvYYqZ3usraKE7.asQYZ5ffj8F8y71EW4.zZSfgWbhjCSG', N'Feminino', N'243906692', N'16995516', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-228', 442, N'11', N'PT', NULL, 4, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (210, N'Mariana Rodrigues', CAST(N'1986-07-16' AS Date), N'mariana@mail.com', N'$2a$11$dpLN/cipDQHdayL75AhlU.iea1.3kyxtCGCeb18JVoCc7TdyjdYcm', N'Feminino', N'243906692', N'16995516', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-224 ', 321, N'13', N'PT', NULL, 1, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (219, N'Juju Azevedo', CAST(N'1980-04-23' AS Date), N'juju@mail.com', N'$2a$11$ZVlkQ7CBs4nFiPwa3qf5aucfDNyjmPC4ho2H.PwUK/7S8YU7EFTc6', N'Masculino', N'243906692', N'16995516', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-224 ', 219, N'9', N'PT', NULL, 4, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (220, N'Fatima Sousa', NULL, N'fatima@mail.com', N'$2a$11$1j0vcnAHk1/TP4XgUrmDFewWgzG8WJCNs2D5AbtzQ6piDLj.0/HgW', N'Masculino', N'243906692', N'16995516', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-224 ', 219, N'9', N'PT', NULL, 4, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (221, N'Carlos Linhares', CAST(N'1980-04-23' AS Date), N'carlos@mail.com', N'$2a$11$B2WWS/8UjQrNSHgO/H1.vOKgv9LZT29wU/IAjxUWgspmTvYEFKRs2', N'Masculino', N'243906692', N'16995516', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-224 ', 219, N'9', N'PT', NULL, 4, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (222, N'Magda Diniz', CAST(N'1986-04-12' AS Date), N'magda@mail.com', N'$2a$11$FvEt7Vdiyu9BWH6dHIwFEOF2Z/CvAncUnyFyRt182MD.g4b5lpOom', N'Feminino', N'243906692', N'16995516', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-225', 314, N'12', N'PT', NULL, 4, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (223, N'Rosa Ribeiro', CAST(N'1983-03-25' AS Date), N'rosa@mail.com', N'$2a$11$RbKX2hGf3wxE47YG8zVfgukrifxOIrhOcQoPB9YWhNA4mtgv9MWuO', N'Feminino', N'243906692', N'16995516', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-226', 623, N'15', N'PT', NULL, 4, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (224, N'Artur Coelho', CAST(N'1985-02-15' AS Date), N'artur@mail.com', N'$2a$11$hWBfXR2Zzw4nL9LUCRIh.u0Zn67asyv9OXBi1S4VgiCC7uELFUzI2', N'Masculino', N'243906692', N'16995516', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-227', 346, N'15', N'PT', NULL, 4, NULL)
GO
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [Email], [Password], [Sexo], [NIF], [CC], [ContactoTelemovel], [ContactoTelefone], [Morada], [CP], [CodigoCNAEF], [HabilitacoesLiterarias], [Nacionalidade], [Foto], [PerfilId], [CV]) VALUES (225, N'Bruno Ribeiro', CAST(N'1980-12-20' AS Date), N'bruno@mail.com', N'$2a$11$L0ytAAVB4zc73/LSvlQWwuUT9YpKL6.wb7r.M7uCISYhI6LmBHcyK', N'Masculino', N'243906692', N'16995516', N'912345678', N'213456789', N'Rua Retiro dos Pacatos, 50 - Edf. StartUp Sintra', N'2635-228', 442, N'4', N'PT', NULL, 4, NULL)
GO
SET IDENTITY_INSERT [dbo].[Pessoa] OFF
GO
INSERT [dbo].[Pessoal] ([PessoaId], [Funcao]) VALUES (2, N'Coordenação')
GO
INSERT [dbo].[Pessoal] ([PessoaId], [Funcao]) VALUES (183, N'Administrador')
GO
INSERT [dbo].[Pessoal] ([PessoaId], [Funcao]) VALUES (182, N'Administrador')
GO
INSERT [dbo].[Pessoal] ([PessoaId], [Funcao]) VALUES (200, N'Formador')
GO
INSERT [dbo].[Pessoal] ([PessoaId], [Funcao]) VALUES (153, N'Secretariado')
GO
INSERT [dbo].[Pessoal] ([PessoaId], [Funcao]) VALUES (202, N'Coordenador')
GO
INSERT [dbo].[Pessoal] ([PessoaId], [Funcao]) VALUES (3, N'Formador')
GO
INSERT [dbo].[Pessoal] ([PessoaId], [Funcao]) VALUES (201, N'Formador')
GO
INSERT [dbo].[Pessoal] ([PessoaId], [Funcao]) VALUES (210, N'Administrador')
GO
SET IDENTITY_INSERT [dbo].[Turma] ON 
GO
INSERT [dbo].[Turma] ([Id], [Nome], [DataInicioCurso], [DataFimCurso], [CursoId], [HorarioSincronoInicio], [HorarioSincronoFim], [HorarioAssincronoInicio], [HorarioAssincronoFim], [TempoLectivo]) VALUES (890, N'T1', CAST(N'2020-11-04' AS Date), CAST(N'2021-04-30' AS Date), 59, CAST(N'2021-04-27T14:30:00.000' AS DateTime), CAST(N'2021-04-27T18:00:00.000' AS DateTime), CAST(N'2021-04-27T09:00:00.000' AS DateTime), CAST(N'2021-04-27T12:30:00.000' AS DateTime), 30)
GO
INSERT [dbo].[Turma] ([Id], [Nome], [DataInicioCurso], [DataFimCurso], [CursoId], [HorarioSincronoInicio], [HorarioSincronoFim], [HorarioAssincronoInicio], [HorarioAssincronoFim], [TempoLectivo]) VALUES (892, N'T2', CAST(N'2021-05-03' AS Date), CAST(N'2021-11-30' AS Date), 59, CAST(N'2021-04-27T14:15:00.000' AS DateTime), CAST(N'2021-04-27T18:00:00.000' AS DateTime), CAST(N'2021-04-27T09:00:00.000' AS DateTime), CAST(N'2021-04-27T12:15:00.000' AS DateTime), 30)
GO
INSERT [dbo].[Turma] ([Id], [Nome], [DataInicioCurso], [DataFimCurso], [CursoId], [HorarioSincronoInicio], [HorarioSincronoFim], [HorarioAssincronoInicio], [HorarioAssincronoFim], [TempoLectivo]) VALUES (894, N'T3', CAST(N'2021-05-03' AS Date), CAST(N'2021-11-30' AS Date), 59, CAST(N'2021-04-28T14:15:00.000' AS DateTime), CAST(N'2021-04-28T18:00:00.000' AS DateTime), CAST(N'2021-04-28T09:00:00.000' AS DateTime), CAST(N'2021-04-28T12:15:00.000' AS DateTime), 30)
GO
SET IDENTITY_INSERT [dbo].[Turma] OFF
GO
INSERT [dbo].[TurmaFormando] ([FormandoId], [TurmaId]) VALUES (199, 890)
GO
INSERT [dbo].[TurmaFormando] ([FormandoId], [TurmaId]) VALUES (196, 890)
GO
INSERT [dbo].[TurmaFormando] ([FormandoId], [TurmaId]) VALUES (195, 890)
GO
INSERT [dbo].[TurmaFormando] ([FormandoId], [TurmaId]) VALUES (197, 890)
GO
INSERT [dbo].[TurmaFormando] ([FormandoId], [TurmaId]) VALUES (198, 890)
GO
INSERT [dbo].[TurmaFormando] ([FormandoId], [TurmaId]) VALUES (207, 892)
GO
INSERT [dbo].[TurmaFormando] ([FormandoId], [TurmaId]) VALUES (208, 892)
GO
INSERT [dbo].[TurmaFormando] ([FormandoId], [TurmaId]) VALUES (206, 892)
GO
INSERT [dbo].[TurmaFormando] ([FormandoId], [TurmaId]) VALUES (205, 892)
GO
INSERT [dbo].[TurmaFormando] ([FormandoId], [TurmaId]) VALUES (209, 892)
GO
INSERT [dbo].[TurmaFormando] ([FormandoId], [TurmaId]) VALUES (224, 894)
GO
INSERT [dbo].[TurmaFormando] ([FormandoId], [TurmaId]) VALUES (225, 894)
GO
INSERT [dbo].[TurmaFormando] ([FormandoId], [TurmaId]) VALUES (221, 894)
GO
INSERT [dbo].[TurmaFormando] ([FormandoId], [TurmaId]) VALUES (222, 894)
GO
INSERT [dbo].[TurmaFormando] ([FormandoId], [TurmaId]) VALUES (223, 894)
GO
/****** Object:  Index [UQ__Formador__2F5F55D3CE3F5CBA]    Script Date: 29/04/2021 23:08:39 ******/
ALTER TABLE [dbo].[Formador] ADD UNIQUE NONCLUSTERED 
(
	[PessoaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Formando__2F5F55D34B5EBCB3]    Script Date: 29/04/2021 23:08:39 ******/
ALTER TABLE [dbo].[Formando] ADD UNIQUE NONCLUSTERED 
(
	[PessoaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Pessoal__2F5F55D3A852C664]    Script Date: 29/04/2021 23:08:39 ******/
ALTER TABLE [dbo].[Pessoal] ADD UNIQUE NONCLUSTERED 
(
	[PessoaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
