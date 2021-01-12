using ControleVeicular.Domain.Entities;
using ControleVeicular.Domain.Interfaces.Repositories;
using ControleVeicular.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ControleVeicular.Domain.Services
{
    public class MarcaService : ServiceBase<Marca>, IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository) :base(marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public IEnumerable<Marca> BuscarPorNome(string nome)
        {
            return _marcaRepository.BuscarPorNome(nome);
        }
    }
}
