using ControleVeicular.Domain.Entities;
using System.Collections.Generic;

namespace ControleVeicular.Application.Interfaces
{
    public interface IMarcaAppService : IAppServiceBase<Marca>
    {
        IEnumerable<Marca> BuscarPorNome(string nome);
    }
}
