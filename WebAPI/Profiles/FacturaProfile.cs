using AutoMapper;

namespace WebAPI.Profiles
{
    public class FacturaProfile : Profile
    {
        public FacturaProfile()
        {
            CreateMap<Models.Request.Factura, Models.Database.Factura>();

            CreateMap<Models.Database.Factura, Models.Response.Factura>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => GetCliente(src.Cliente)))
                .ForMember(dest => dest.FacturaDetalle, opt => opt.MapFrom(src => GetFacturasDetalle(src.FacturaDetalle.ToList())));

            CreateMap<Models.Response.Factura, Models.Database.Factura>();
        }

        static Models.Response.Cliente GetCliente(Models.Database.Cliente cliente)
        {
            return new Models.Response.Cliente { IdCliente = cliente.IdCliente, Identificacion = cliente.Identificacion, Nombre = cliente.Nombre, Direccion = cliente.Direccion, Telefono = cliente.Telefono, Correo = cliente.Correo };
        }

        static List<Models.Response.FacturaDetalle> GetFacturasDetalle(List<Models.Database.FacturaDetalle> facturasDetalle)
        {
            List<Models.Response.FacturaDetalle> Detalles = new List<Models.Response.FacturaDetalle>();

            facturasDetalle.ForEach(facturaDetalle =>
            {
                Detalles.Add(new Models.Response.FacturaDetalle { Producto = new Models.Response.Producto { IdProducto = facturaDetalle.Producto.IdProducto, Codigo = facturaDetalle.Producto.Codigo, Descripcion = facturaDetalle.Producto.Descripcion, Categoria = facturaDetalle.Producto.Categoria, UnidadMedida = facturaDetalle.Producto.UnidadMedida, Precio = facturaDetalle.Producto.Precio }, Cantidad = facturaDetalle.Cantidad, Precio = facturaDetalle.Precio, IVA = facturaDetalle.IVA, Subtotal = facturaDetalle.Subtotal });
            });

            return Detalles;
        }
    }
}
