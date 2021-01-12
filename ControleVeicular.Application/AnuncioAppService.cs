using ControleVeicular.Application.Interfaces;
using ControleVeicular.Domain.Entities;
using ControleVeicular.Domain.Interfaces.Services;

namespace ControleVeicular.Application
{
    public class AnuncioAppService : AppServiceBase<Anuncio>, IAnuncioAppService
    {
        private readonly IAnuncioService _anuncioService;

        public AnuncioAppService(IAnuncioService anuncioService) : base(anuncioService)
        {
            _anuncioService = anuncioService;
        }
    }
}
