using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Database;

public partial class Cliente
{
    public Cliente()
    {
        Factura = new HashSet<Factura>();
    }

    [Key]
    public long IdCliente { get; set; }

    public string Identificacion { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public virtual ICollection<Factura> Factura { get; set; }
}
