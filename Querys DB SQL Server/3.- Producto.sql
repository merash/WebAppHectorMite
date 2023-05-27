USE [DatabaseHectorMite]
GO

/****** Object:  Table [dbo].[Producto]    Script Date: 27/05/2023 12:59:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Producto](
	[IdProducto] [bigint] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](15) NOT NULL,
	[Descripcion] [varchar](300) NOT NULL,
	[Categoria] [varchar](50) NOT NULL,
	[UnidadMedida] [varchar](50) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


