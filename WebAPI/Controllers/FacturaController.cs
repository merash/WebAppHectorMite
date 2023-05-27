using AutoMapper;
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
        private IMapper mapper { get; }

        public FacturaController(DatabaseHectorMiteContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetFacturas()
        {
            return Ok(this.mapper.Map<List<Models.Response.Factura>>(this.context.Factura.ToList()));
        }

        [HttpGet]
        [Route("{IdFactura:long}")]
        public IActionResult GetFactura([FromRoute] long IdFactura)
        {
            var factura = this.mapper.Map<Models.Response.Factura>(this.context.Factura.Find(IdFactura));

            if (factura == null)
                return NotFound();

            return Ok(factura);
        }

        [HttpPost]
        public IActionResult CreateFactura(CreateFactura createFactura)
        {
            var newFactura = new Factura()
            {
                Establecimiento = createFactura.Establecimiento,
                PuntoEmision = createFactura.PuntoEmision,
                NumeroFactura = createFactura.NumeroFactura,
                Fecha = createFactura.Fecha,
                IdCliente = createFactura.Cliente.IdCliente,
                Subtotal = createFactura.Subtotal,
                TotalIVA = createFactura.TotalIVA,
                Total = createFactura.Total
            };

            createFactura.Detalles.ForEach(x => newFactura.FacturaDetalle.Add(new Models.Database.FacturaDetalle { IdProducto = x.IdProducto, Cantidad = x.Cantidad, Precio = x.Precio, IVA = x.IVA, Subtotal = x.Subtotal }));

            this.context.Factura.Add(newFactura);
            this.context.SaveChanges();

            createFactura.IdFactura = newFactura.IdFactura;

            return Ok(createFactura);
        }
    }
}
