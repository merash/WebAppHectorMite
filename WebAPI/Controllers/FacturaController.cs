using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
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
        public IActionResult CreateFactura(Factura factura)
        {
            var newFactura = this.mapper.Map<Models.Database.Factura>(factura);

            this.context.Factura.Add(newFactura);
            this.context.SaveChanges();

            return Ok(this.mapper.Map<Models.Response.Factura>(factura));
        }
    }
}