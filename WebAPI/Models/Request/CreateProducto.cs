namespace WebAPI.Models.Request
{
    public class CreateProducto
    {
        public long IdProducto { get; set; }

        public string Codigo { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public string Categoria { get; set; } = null!;

        public string UnidadMedida { get; set; } = null!;

        public decimal Precio { get; set; }
    }
}
