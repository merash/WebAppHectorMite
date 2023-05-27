USE [DatabaseHectorMite]
GO

/****** Object:  Table [dbo].[FacturaDetalle]    Script Date: 27/05/2023 12:59:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FacturaDetalle](
	[IdFactura] [bigint] NOT NULL,
	[IdDetalle] [bigint] IDENTITY(1,1) NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[Cantidad] [decimal](18, 2) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[IVA] [decimal](18, 2) NOT NULL,
	[Subtotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_FacturaDetalle] PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC,
	[IdDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FacturaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_Factura_FacturaDetalle] FOREIGN KEY([IdFactura])
REFERENCES [dbo].[Factura] ([IdFactura])
GO

ALTER TABLE [dbo].[FacturaDetalle] CHECK CONSTRAINT [FK_Factura_FacturaDetalle]
GO

ALTER TABLE [dbo].[FacturaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_Producto_FacturaDetalle] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO

ALTER TABLE [dbo].[FacturaDetalle] CHECK CONSTRAINT [FK_Producto_FacturaDetalle]
GO


