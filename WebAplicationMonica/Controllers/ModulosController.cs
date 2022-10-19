using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAplicationMonica.Models;
using WebAplicationMonica.Services;

namespace WebAplicationMonica.Controllers
{
    public class ModulosController : Controller
    {
        private readonly IRepositorioModulo _repositorioModulo;

        public ModulosController(IRepositorioModulo repositorioModulo)
        {
            _repositorioModulo = repositorioModulo;
        }

        // GET: HomeController
        public ActionResult Index()
        {
            return View("Index",_repositorioModulo.ListaModulos());
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View("Details",_repositorioModulo.TomaModulo(id));
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection,string name, int cursoid)
        {
            try
            {
                _repositorioModulo.AddModulo(new Modulo() { Name = name , CursoId = cursoid });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}