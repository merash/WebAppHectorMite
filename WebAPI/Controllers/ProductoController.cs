using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models.Request;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly DatabaseHectorMiteContext context;
        private IMapper mapper { get; }

        public ProductoController(DatabaseHectorMiteContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProductos()
        {
            return Ok(this.mapper.Map<List<Models.Response.Producto>>(this.context.Producto.ToList()));
        }

        [HttpGet]
        [Route("{IdProducto:long}")]
        public IActionResult GetProducto([FromRoute] long IdProducto)
        {
            var producto = this.mapper.Map<Models.Response.Producto>(this.context.Producto.Find(IdProducto));

            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        [HttpPost]
        public IActionResult CreateCliente(Producto producto)
        {
            var newProducto = this.mapper.Map<Models.Database.Producto>(producto);

            this.context.Producto.Add(newProducto);
            this.context.SaveChanges();

            return Ok(this.mapper.Map<Models.Response.Producto>(newProducto));
        }

        [HttpPut]
        [Route("{IdProducto:long}")]
        public IActionResult UpdateCliente([FromRoute] long IdProducto, Producto updateProducto)
        {
            var producto = this.context.Producto.Find(IdProducto);

            if (producto != null)
            {
                producto.Codigo = updateProducto.Codigo;
                producto.Descripcion = updateProducto.Descripcion;
                producto.Categoria = updateProducto.Categoria;
                producto.UnidadMedida = updateProducto.UnidadMedida;
                producto.Precio = updateProducto.Precio;

                this.context.SaveChanges();

                return Ok(this.mapper.Map<Models.Response.Producto>(producto));
            }

            return NotFound();
        }
    }
}
