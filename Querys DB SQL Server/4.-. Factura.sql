USE [DatabaseHectorMite]
GO

/****** Object:  Table [dbo].[Factura]    Script Date: 27/05/2023 12:59:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Factura](
	[IdFactura] [bigint] IDENTITY(1,1) NOT NULL,
	[Establecimiento] [varchar](10) NOT NULL,
	[PuntoEmision] [varchar](10) NOT NULL,
	[NumeroFactura] [varchar](50) NOT NULL,
	[Fecha] [date] NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[Subtotal] [decimal](18, 2) NOT NULL,
	[TotalIVA] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Factura] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO

ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Cliente_Factura]
GO


