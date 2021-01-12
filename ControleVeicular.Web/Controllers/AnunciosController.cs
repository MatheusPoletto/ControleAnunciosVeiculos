using AutoMapper;
using ControleVeicular.Application.Interfaces;
using ControleVeicular.Domain.Entities;
using ControleVeicular.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControleVeicular.Web.Controllers
{
    [Authorize]
    public class AnunciosController : Controller
    {
        private readonly IAnuncioAppService _anuncioApp;
        private readonly IMapper _mapper;

        public AnunciosController(IMapper mapper, IAnuncioAppService anuncioApp)
        {
            _mapper = mapper;
            _anuncioApp = anuncioApp;
        }

        // GET: AnunciosController
        public ActionResult Index()
        {
            var anuncios = _anuncioApp.GetAll();
            var anuncioViewModel = _mapper.Map<IEnumerable<Anuncio>, IEnumerable<AnuncioViewModel>>(anuncios);

            return View(anuncioViewModel);
        }

        // GET: AnunciosController/Details/5
        public ActionResult Details(int id)
        {
            var anuncio = _anuncioApp.GetById(id);
            var anuncioViewModel = _mapper.Map<Anuncio, AnuncioViewModel>(anuncio);

            return View(anuncioViewModel);
        }

        // GET: AnunciosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnunciosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnuncioViewModel anuncio)
        {
            if (ModelState.IsValid)
            {
                var anuncioDomain = _mapper.Map<AnuncioViewModel, Anuncio>(anuncio);
                _anuncioApp.Add(anuncioDomain);

                return RedirectToAction("Index");
            }

            return View(anuncio);
        }

        // GET: AnunciosController/Edit/5
        public ActionResult Edit(int id)
        {
            var anuncio = _anuncioApp.GetById(id);
            var anuncioViewModel = _mapper.Map<Anuncio, AnuncioViewModel>(anuncio);

            return View(anuncioViewModel);
        }

        // POST: AnunciosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AnuncioViewModel anuncio)
        {
            if (ModelState.IsValid)
            {
                var anuncioDomain = _mapper.Map<AnuncioViewModel, Anuncio>(anuncio);
                _anuncioApp.Update(anuncioDomain);

                return RedirectToAction("Index");
            }

            return View(anuncio);
        }

        // GET: AnunciosController/Delete/5
        public ActionResult Delete(int id)
        {
            var anuncio = _anuncioApp.GetById(id);
            var anuncioViewModel = _mapper.Map<Anuncio, AnuncioViewModel>(anuncio);

            return View(anuncioViewModel);
        }

        // POST: AnunciosController/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var anuncio = _anuncioApp.GetById(id);
            _anuncioApp.Remove(anuncio);
            return RedirectToAction("Index");
        }
    }
}
