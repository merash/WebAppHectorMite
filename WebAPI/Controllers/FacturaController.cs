using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models.Database;
using WebAPI.Models.Request;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly DatabaseHectorMiteContext context;

        public FacturaController(DatabaseHectorMiteContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult CreateCliente(CreateFactura createFactura)
        {
            var newFactura = new Factura()
            {
                Establecimiento = createFactura.Establecimiento,
                PuntoEmision = createFactura.PuntoEmision,
                NumeroFactura = createFactura.NumeroFactura,
                Fecha = createFactura.Fecha,
                IdCliente = createFactura.IdCliente,
                Subtotal = createFactura.Subtotal,
                TotalIVA = createFactura.TotalIVA,
                Total = createFactura.Total
            };

            createFactura.Detalles.ForEach(x => newFactura.FacturaDetalle.Add(new FacturaDetalle { IdProducto = x.IdProducto, Cantidad = x.Cantidad, Precio = x.Precio, IVA = x.IVA, Subtotal = x.Subtotal }));

            this.context.Factura.Add(newFactura);
            this.context.SaveChanges();

            createFactura.IdFactura = newFactura.IdFactura;

            return Ok(createFactura);
        }
    }
}
