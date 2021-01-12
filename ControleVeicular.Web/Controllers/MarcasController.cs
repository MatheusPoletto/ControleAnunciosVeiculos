using AutoMapper;
using ControleVeicular.Application.Interfaces;
using ControleVeicular.Domain.Entities;
using ControleVeicular.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace ControleVeicular.Web.Controllers
{
    [Authorize]
    public class MarcasController : Controller
    {
        private readonly IMarcaAppService _marcaApp;
        private readonly IMapper _mapper;

        public MarcasController(IMapper mapper, IMarcaAppService marcaApp)
        {
            _mapper = mapper;
            _marcaApp = marcaApp;
        }

        // GET: MarcasController
        public ActionResult Index()
        {
            var marcaViewModel = _mapper.Map<IEnumerable<Marca>, IEnumerable<MarcaViewModel>>(_marcaApp.GetAll());

            return View(marcaViewModel);
        }

        // GET: MarcasController/Details/5
        public ActionResult Details(int id)
        {
            var marca = _marcaApp.GetById(id);
            var marcaViewModel = _mapper.Map<Marca, MarcaViewModel>(marca);

            return View(marcaViewModel);
        }

        // GET: MarcasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Marcas/Listar
        [HttpGet]
        public JsonResult Listar()
        {
            return Json(_marcaApp.GetAll());
        }

        // POST: MarcasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MarcaViewModel marca)
        {
            if (ModelState.IsValid)
            {
                var marcaDomain = _mapper.Map<MarcaViewModel, Marca>(marca);
                _marcaApp.Add(marcaDomain);

                return RedirectToAction("Index");
            }

            return View(marca);
        }

        // GET: MarcasController/Edit/5
        public ActionResult Edit(int id)
        {
            var marca = _marcaApp.GetById(id);
            var marcaViewModel = _mapper.Map<Marca, MarcaViewModel>(marca);

            return View(marcaViewModel);
        }

        // POST: MarcasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MarcaViewModel marca)
        {
            if (ModelState.IsValid)
            {
                var marcaDomain = _mapper.Map<MarcaViewModel, Marca>(marca);
                _marcaApp.Update(marcaDomain);

                return RedirectToAction("Index");
            }

            return View(marca);
        }

        // GET: MarcasController/Delete/5
        public ActionResult Delete(int id)
        {
            var marca = _marcaApp.GetById(id);
            var marcaViewModel = _mapper.Map<Marca, MarcaViewModel>(marca);

            return View(marcaViewModel);
        }

        // POST: MarcasController/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var marca = _marcaApp.GetById(id);
            _marcaApp.Remove(marca);

            return RedirectToAction("Index");
        }
    }
}
