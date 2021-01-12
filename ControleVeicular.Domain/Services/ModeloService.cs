using ControleVeicular.Domain.Entities;
using ControleVeicular.Domain.Interfaces.Repositories;
using ControleVeicular.Domain.Interfaces.Services;

namespace ControleVeicular.Domain.Services
{
    public class ModeloService : ServiceBase<Modelo>, IModeloService
    {
        private readonly IModeloRepository _modeloRepository;

        public ModeloService(IModeloRepository modeloRepository) : base(modeloRepository)
        {
            _modeloRepository = modeloRepository;
        }

    }
}
