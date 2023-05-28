using WebAppHectorMite.Models;

namespace WebAppHectorMite.Services
{
    public interface IWebAPI
    {
        List<Cliente>? GetClientes();
        Cliente? GetCliente(long IdCliente);
        Cliente? CreateCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);

        List<Producto>? GetProductos();
        Producto? GetProducto(long IdProducto);
        void CreateProducto(Producto producto);
        void UpdateProducto(Producto producto);

        List<Factura>? GetFacturas();
        Factura? GetFactura(long IdFactura);
        Factura? CreateFactura(Factura factura);
    }
}
