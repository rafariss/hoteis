CREATE TABLE [dbo].[bairros](
	[bairro_id] [int] NOT NULL,
	[cidade_id] [int] NOT NULL,
	[desc_bairro] [varchar](45) NOT NULL,
 CONSTRAINT [PK__bairros__B511CCB8877E655B] PRIMARY KEY CLUSTERED 
(
	[bairro_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cidades]    Script Date: 13/08/2018 20:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cidades](
	[cidade_id] [int] NOT NULL,
	[desc_cidade] [varchar](60) NOT NULL,
	[flg_estado] [char](2) NOT NULL,
 CONSTRAINT [PK__cidades__406AF6F88426A792] PRIMARY KEY CLUSTERED 
(
	[cidade_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 13/08/2018 20:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Endereco] [nvarchar](100) NOT NULL,
	[Numero] [int] NOT NULL,
	[Complemento] [nvarchar](20) NOT NULL,
	[Cep] [numeric](8, 0) NOT NULL,
	[Cidade] [varchar](60) NOT NULL,
	[Uf] [char](2) NOT NULL,
	[Ddd] [numeric](2, 0) NOT NULL,
	[Telefone] [numeric](9, 0) NOT NULL,
	[Descricao] [nvarchar](250) NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[logradouros]    Script Date: 13/08/2018 20:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[logradouros](
	[num_cep] [int] NOT NULL,
	[bairro_id] [int] NOT NULL,
	[desc_logradouro] [varchar](45) NOT NULL,
	[desc_tipo] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[num_cep] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quarto]    Script Date: 13/08/2018 20:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quarto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HotelId] [int] NOT NULL,
	[Titulo] [nvarchar](50) NOT NULL,
	[Descricao] [nvarchar](250) NULL,
	[Quantidade] [int] NOT NULL,
	[MaximoOcupantes] [int] NOT NULL,
	[ValorDiaria] [numeric](18, 2) NULL,
	[ValorDiariaCrianca] [numeric](18, 2) NULL,
	[DiariaPorOcupante] [bit] NULL,
 CONSTRAINT [PK_Quarto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 13/08/2018 20:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[Id] [int] NOT NULL,
	[DataReserva] [datetime] NOT NULL,
	[TuristaId] [int] NOT NULL,
	[Chegada] [date] NOT NULL,
	[Partida] [date] NOT NULL,
	[ValorDiaria] [numeric](18, 2) NULL,
	[QuartoId] [int] NOT NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turista]    Script Date: 13/08/2018 20:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turista](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](150) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Sexo] [bit] NOT NULL,
	[DataNascimento] [date] NOT NULL,
	[Cpf] [numeric](9, 0) NOT NULL,
	[Senha] [nchar](50) NULL,
 CONSTRAINT [PK_Turista] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ufs]    Script Date: 13/08/2018 20:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ufs](
	[uf_id] [char](2) NOT NULL,
	[desc_uf] [varchar](60) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[uf_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[bairros]  WITH CHECK ADD  CONSTRAINT [FK_bairros_cidades] FOREIGN KEY([cidade_id])
REFERENCES [dbo].[cidades] ([cidade_id])
GO
ALTER TABLE [dbo].[bairros] CHECK CONSTRAINT [FK_bairros_cidades]
GO
ALTER TABLE [dbo].[cidades]  WITH CHECK ADD  CONSTRAINT [FK_cidades_ufs] FOREIGN KEY([flg_estado])
REFERENCES [dbo].[ufs] ([uf_id])
GO
ALTER TABLE [dbo].[cidades] CHECK CONSTRAINT [FK_cidades_ufs]
GO
ALTER TABLE [dbo].[logradouros]  WITH CHECK ADD  CONSTRAINT [FK_logradouros_bairros] FOREIGN KEY([bairro_id])
REFERENCES [dbo].[bairros] ([bairro_id])
GO
ALTER TABLE [dbo].[logradouros] CHECK CONSTRAINT [FK_logradouros_bairros]
GO
ALTER TABLE [dbo].[Quarto]  WITH CHECK ADD  CONSTRAINT [FK_Quarto_Hotel] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotel] ([Id])
GO
ALTER TABLE [dbo].[Quarto] CHECK CONSTRAINT [FK_Quarto_Hotel]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Quarto] FOREIGN KEY([QuartoId])
REFERENCES [dbo].[Quarto] ([Id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Quarto]
GO
