using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Database;

namespace WebAPI.Data;

public partial class DatabaseHectorMiteContext : DbContext
{

    public DatabaseHectorMiteContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Cliente> Cliente { get; set; }
    public virtual DbSet<Factura> Factura { get; set; }
    public virtual DbSet<FacturaDetalle> FacturaDetalle { get; set; }
    public virtual DbSet<Producto> Producto { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FacturaDetalle>().HasKey(m => new { m.IdFactura, m.IdDetalle });
    }
}