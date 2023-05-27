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
        modelBuilder.Entity<Cliente>().HasMany(e => e.Factura).WithOne(e => e.Cliente).HasForeignKey(e => e.IdCliente).HasPrincipalKey(e => e.IdCliente);
        modelBuilder.Entity<FacturaDetalle>().HasKey(e => new { e.IdFactura, e.IdDetalle });
        modelBuilder.Entity<Producto>().HasMany(e => e.FacturaDetalle).WithOne(e => e.Producto).HasForeignKey(e => e.IdProducto).HasPrincipalKey(e => e.IdProducto);
    }
}