using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models.Database;
using WebAPI.Models.Request;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly DatabaseHectorMiteContext context;

        public ProductoController(DatabaseHectorMiteContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetProductos()
        {
            return Ok(this.context.Producto.ToList());
        }

        [HttpGet]
        [Route("{IdProducto:long}")]
        public IActionResult GetProducto([FromRoute] long IdProducto)
        {
            var producto = this.context.Producto.Find(IdProducto);

            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        [HttpPost]
        public IActionResult CreateCliente(CreateProducto createProducto)
        {
            var newProducto = new Producto()
            {
                Codigo = createProducto.Codigo,
                Descripcion = createProducto.Descripcion,
                Categoria = createProducto.Categoria,
                UnidadMedida = createProducto.UnidadMedida,
                Precio = createProducto.Precio
            };

            this.context.Producto.Add(newProducto);
            this.context.SaveChanges();

            return Ok(newProducto);
        }

        [HttpPut]
        [Route("{IdProducto:long}")]
        public IActionResult UpdateCliente([FromRoute] long IdProducto, UpdateProducto updateProducto)
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

                return Ok(producto);
            }

            return NotFound();
        }
    }
}
