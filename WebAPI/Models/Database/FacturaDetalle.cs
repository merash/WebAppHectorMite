using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.Database;

public partial class FacturaDetalle
{
    [Key]
    [Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long IdFactura { get; set; }

    [Key]
    [Column(Order = 1)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long IdDetalle { get; set; }

    public long IdProducto { get; set; }

    public decimal Cantidad { get; set; }

    public decimal Precio { get; set; }

    public decimal IVA { get; set; }

    public decimal Subtotal { get; set; }

    public virtual Factura Factura { get; set; } = null!;
}