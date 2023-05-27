using Microsoft.AspNetCore.Mvc;
using WebAppHectorMite.Models;
using WebAppHectorMite.Services;

namespace WebAppHectorMite.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IWebAPI webAPI;

        public ClienteController(IWebAPI webAPI) => this.webAPI = webAPI;

        // GET: ClienteController
        public ActionResult Index()
        {
            return View(webAPI.GetClientes());
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                webAPI.CreateCliente(cliente);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(long IdCliente)
        {
            return View(webAPI.GetCliente(IdCliente));
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                webAPI.UpdateCliente(cliente);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
