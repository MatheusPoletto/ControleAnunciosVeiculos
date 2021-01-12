using ControleVeicular.Domain.Entities;
using ControleVeicular.Domain.Interfaces.Repositories;
using ControleVeicular.Domain.Interfaces.Services;

namespace ControleVeicular.Domain.Services
{
    public class AnuncioService : ServiceBase<Anuncio>, IAnuncioService
    {
        private readonly IAnuncioRepository _anuncioService;

        public AnuncioService(IAnuncioRepository anuncioService) : base(anuncioService)
        {
            _anuncioService = anuncioService;
        }

    }
}
