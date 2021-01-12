using ControleVeicular.Application.Interfaces;
using ControleVeicular.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ControleVeicular.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnunciosController : ControllerBase
    {
        private readonly IAnuncioAppService _anuncioApp;

        public AnunciosController(IAnuncioAppService anuncioApp)
        {
            _anuncioApp = anuncioApp;
        }

        [HttpGet("{id}")]
        public Anuncio GetById(int id)
        {
            var anuncio = _anuncioApp.GetById(id);
            return anuncio;
        }
    }
}
