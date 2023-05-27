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
            return View();
        }

        // POST: FacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Factura factura)
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
