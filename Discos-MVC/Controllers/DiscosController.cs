using System.ComponentModel;
using dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using negocio;

namespace Discos_MVC.Controllers
{
    public class DiscosController : Controller
    {
        // GET: DiscosController
        public ActionResult Index()
        {
            DiscoNegocio negocio = new DiscoNegocio();
            var lista = negocio.listar();
            
            return View(lista);
        }

        // GET: DiscosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DiscosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiscosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DiscosController/Edit/5
        public ActionResult Edit(int id)
        {
            EstiloNegocio estiloNegocio = new EstiloNegocio();
            TipoEdicionNegocio tipoEdicionNegocio = new TipoEdicionNegocio();
            DiscoNegocio discoNegocio = new DiscoNegocio();
            var disco = discoNegocio.listar().Find(p => p.Id == id);
            if (disco != null)
            {
                var listaEst = estiloNegocio.listar();
                var listaEdi = tipoEdicionNegocio.listar();
                ViewBag.estilos = new SelectList(listaEst, "Id", "Descripcion", disco.Estilo.Id);
                ViewBag.edicion = new SelectList(listaEdi, "Id", "Descripcion", disco.TipoEdicion.Id);


                return View(disco);
            }
            return View("Index");
        }

        // POST: DiscosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Disco disco)
        {
            try
            {
                DiscoNegocio negocio = new DiscoNegocio();
                negocio.modificar(disco);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DiscosController/Delete/5
        public ActionResult Delete(int id)
        {
            DiscoNegocio discoNegocio = new DiscoNegocio();
            var disco = discoNegocio.listar().Find(x => x.Id == id);
            return View(disco);
        }

        // POST: DiscosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                DiscoNegocio discoNegocio = new DiscoNegocio();
                discoNegocio.eliminar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Index");
            }
        }
    }
}
