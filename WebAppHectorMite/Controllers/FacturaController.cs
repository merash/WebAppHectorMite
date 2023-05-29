using Microsoft.AspNetCore.Mvc;
using WebAppHectorMite.Models;
using WebAppHectorMite.Services;

namespace WebAppHectorMite.Controllers
{
    public class FacturaController : Controller
    {
        private readonly IWebAPI webAPI;

        public FacturaController(IWebAPI webAPI) => this.webAPI = webAPI;

        // GET: FacturaController
        public ActionResult Index()
        {
            return View(webAPI.GetFacturas());
        }

        // GET: FacturaController/Details/5
        public ActionResult Details(long IdFactura)
        {
            return View(webAPI.GetFactura(IdFactura));
        }

        // GET: FacturaController/Create
        public ActionResult Create()
        {
            var clientes = webAPI.GetClientes();
            if (clientes != null) clientes.Insert(0, new Cliente { IdCliente = 0, Identificacion = string.Empty, Nombre = "--Seleccione cliente--" });

            var productos = webAPI.GetProductos();
            if (productos != null) productos.Insert(0, new Producto { IdProducto = 0, Descripcion = "--Seleccione producto--", Precio = 0 });

            ViewBag.clientes = clientes;
            ViewBag.productos = productos;

            Factura factura = new Factura { Detalles = new List<FacturaDetalle> { } };

            return View(factura);
        }

        // POST: FacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromBody] Factura factura)
        {
            try
            {
                webAPI.CreateFactura(factura);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
