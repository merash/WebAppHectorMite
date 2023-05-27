using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Database;

public partial class Producto
{
    public Producto()
    {
        FacturaDetalle = new HashSet<FacturaDetalle>();
    }

    [Key]
    public long IdProducto { get; set; }

    public string Codigo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public string UnidadMedida { get; set; } = null!;

    public decimal Precio { get; set; }

    public virtual ICollection<FacturaDetalle> FacturaDetalle { get; set; }
}