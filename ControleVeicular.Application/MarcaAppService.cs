using ControleVeicular.Application.Interfaces;
using ControleVeicular.Domain.Entities;
using ControleVeicular.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ControleVeicular.Application
{
    public class MarcaAppService : AppServiceBase<Marca>, IMarcaAppService
    {
        private readonly IMarcaService _marcaService;

        public MarcaAppService(IMarcaService marcaService) : base(marcaService)
        {
            _marcaService = marcaService;
        }

        public IEnumerable<Marca> BuscarPorNome(string nome)
        {
            return _marcaService.BuscarPorNome(nome);
        }
    }
}
