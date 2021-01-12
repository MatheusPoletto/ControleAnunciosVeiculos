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
    public class ModelosController : Controller
    {
        private readonly IModeloAppService _modeloApp;
        private readonly IMapper _mapper;

        public ModelosController(IMapper mapper, IModeloAppService modeloApp)
        {
            _mapper = mapper;
            _modeloApp = modeloApp;
        }

        // GET: ModelosController
        public ActionResult Index()
        {
            var modeloViewModel = _mapper.Map<IEnumerable<Modelo>, IEnumerable<ModeloViewModel>>(_modeloApp.GetAll());

            return View(modeloViewModel);
        }

        // GET: ModelosController/Details/5
        public ActionResult Details(int id)
        {
            var modelo = _modeloApp.GetById(id);
            var modeloViewModel = _mapper.Map<Modelo, ModeloViewModel>(modelo);

            return View(modeloViewModel);
        }

        // GET: ModelosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Modelos/Listar
        [HttpGet]
        public JsonResult Listar()
        {
            return Json(_modeloApp.GetAll());
        }

        // POST: ModelosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModeloViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var modeloDomain = _mapper.Map<ModeloViewModel, Modelo>(modelo);
                _modeloApp.Add(modeloDomain);

                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: ModelosController/Edit/5
        public ActionResult Edit(int id)
        {
            var modelo = _modeloApp.GetById(id);
            var modeloViewModel = _mapper.Map<Modelo, ModeloViewModel>(modelo);

            return View(modeloViewModel);
        }

        // POST: ModelosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModeloViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var modeloDomain = _mapper.Map<ModeloViewModel, Modelo>(modelo);
                _modeloApp.Update(modeloDomain);

                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: ModelosController/Delete/5
        public ActionResult Delete(int id)
        {
            var modelo = _modeloApp.GetById(id);
            var modeloViewModel = _mapper.Map<Modelo, ModeloViewModel>(modelo);

            return View(modeloViewModel);
        }

        // POST: ModelosController/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var modelo = _modeloApp.GetById(id);
            _modeloApp.Remove(modelo);
            return RedirectToAction("Index");
        }
    }
}
