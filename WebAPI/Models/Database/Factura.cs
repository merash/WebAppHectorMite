using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.Database;

public partial class Factura
{
    public Factura()
    {
        FacturaDetalle = new HashSet<FacturaDetalle>();
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long IdFactura { get; set; }

    public string Establecimiento { get; set; } = null!;

    public string PuntoEmision { get; set; } = null!;

    public string NumeroFactura { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public long IdCliente { get; set; }

    public decimal Subtotal { get; set; }

    public decimal TotalIVA { get; set; }

    public decimal Total { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<FacturaDetalle> FacturaDetalle { get; set; }
}
