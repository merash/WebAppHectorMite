using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models.Request;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly DatabaseHectorMiteContext context;
        private IMapper mapper { get; }

        public ClienteController(DatabaseHectorMiteContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetClientes()
        {
            return Ok(this.mapper.Map<List<Models.Response.Cliente>>(this.context.Cliente.ToList()));
        }

        [HttpGet]
        [Route("{IdCliente:long}")]
        public IActionResult GetCliente([FromRoute] long IdCliente)
        {
            var cliente = this.mapper.Map<Models.Response.Cliente>(this.context.Cliente.Find(IdCliente));

            if(cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult CreateCliente(Cliente cliente)
        {
            var newCliente = this.mapper.Map<Models.Database.Cliente>(cliente);

            this.context.Cliente.Add(newCliente);
            this.context.SaveChanges();

            return Ok(this.mapper.Map<Models.Response.Cliente>(newCliente));
        }

        [HttpPut]
        [Route("{IdCliente:long}")]
        public IActionResult UpdateCliente([FromRoute] long IdCliente, Cliente updateCliente)
        {
            var cliente = this.context.Cliente.Find(IdCliente);

            if (cliente != null)
            {
                cliente.Identificacion = updateCliente.Identificacion;
                cliente.Nombre = updateCliente.Nombre;
                cliente.Direccion = updateCliente.Direccion;
                cliente.Telefono = updateCliente.Telefono;
                cliente.Correo = updateCliente.Correo;

                this.context.SaveChanges();

                return Ok(this.mapper.Map<Models.Response.Cliente>(cliente));
            }

            return NotFound();
        }
    }
}