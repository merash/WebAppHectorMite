namespace WebAPI.Models.Request
{
    public class FacturaDetalle
    {

        public long IdProducto { get; set; }

        public decimal Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal IVA { get; set; }

        public decimal Subtotal { get; set; }
    }

    public class Factura
    {
        public long IdFactura { get; set; }

        public string Establecimiento { get; set; } = null!;

        public string PuntoEmision { get; set; } = null!;

        public string NumeroFactura { get; set; } = null!;

        public DateTime Fecha { get; set; }

        public Cliente Cliente { get; set; } = null!;

        public List<FacturaDetalle> Detalles { get; set; } = null!;

        public decimal Subtotal { get; set; }

        public decimal TotalIVA { get; set; }

        public decimal Total { get; set; }
    }
}
