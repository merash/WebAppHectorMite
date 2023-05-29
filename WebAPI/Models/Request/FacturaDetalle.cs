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
}
