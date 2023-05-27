using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models.Database;
using WebAPI.Models.Request;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly DatabaseHectorMiteContext context;

        public ClienteController(DatabaseHectorMiteContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetClientes()
        {
            return Ok(this.context.Cliente.ToList());
        }

        [HttpGet]
        [Route("{IdCliente:long}")]
        public IActionResult GetCliente([FromRoute] long IdCliente)
        {
            var cliente = this.context.Cliente.Find(IdCliente);

            if(cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult CreateCliente(CreateCliente createCliente)
        {
            var newCliente = new Cliente()
            {
                Identificacion = createCliente.Identificacion,
                Nombre = createCliente.Nombre,
                Direccion = createCliente.Direccion,
                Telefono = createCliente.Telefono,
                Correo = createCliente.Correo
            };

            this.context.Cliente.Add(newCliente);
            this.context.SaveChanges();
            
            return Ok(newCliente);
        }

        [HttpPut]
        [Route("{IdCliente:long}")]
        public IActionResult UpdateCliente([FromRoute] long IdCliente, UpdateCliente updateCliente)
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

                return Ok(cliente);
            }

            return NotFound();
        }
    }
}