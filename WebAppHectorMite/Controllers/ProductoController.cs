using Microsoft.AspNetCore.Mvc;
using WebAppHectorMite.Models;
using WebAppHectorMite.Services;

namespace WebAppHectorMite.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IWebAPI webAPI;

        public ProductoController(IWebAPI webAPI) => this.webAPI = webAPI;

        // GET: ProductoController
        public ActionResult Index()
        {
            return View(webAPI.GetProductos());
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto producto)
        {
            try
            {
                webAPI.CreateProducto(producto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(long IdProducto)
        {
            return View(webAPI.GetProducto(IdProducto));
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Producto producto)
        {
            try
            {
                webAPI.UpdateProducto(producto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
