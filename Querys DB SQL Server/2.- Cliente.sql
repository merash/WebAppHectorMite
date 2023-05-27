USE [DatabaseHectorMite]
GO

/****** Object:  Table [dbo].[Cliente]    Script Date: 27/05/2023 12:59:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cliente](
	[IdCliente] [bigint] IDENTITY(1,1) NOT NULL,
	[Identificacion] [varchar](13) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Direccion] [varchar](300) NOT NULL,
	[Telefono] [varchar](10) NOT NULL,
	[Correo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


