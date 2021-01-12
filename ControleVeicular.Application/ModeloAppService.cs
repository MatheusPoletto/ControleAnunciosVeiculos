using ControleVeicular.Application.Interfaces;
using ControleVeicular.Domain.Entities;
using ControleVeicular.Domain.Interfaces.Services;

namespace ControleVeicular.Application
{
    public class ModeloAppService : AppServiceBase<Modelo>, IModeloAppService
    {
        private readonly IModeloService _modeloService;

        public ModeloAppService(IModeloService modeloService) : base(modeloService)
        {
            _modeloService = modeloService;
        }
    }
}
