namespace WebAPI.Models.Response
{
    public class FacturaDetalle
    {
        public Producto Producto { get; set; } = null!;

        public decimal Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal IVA { get; set; }

        public decimal Subtotal { get; set; }
    }
}
