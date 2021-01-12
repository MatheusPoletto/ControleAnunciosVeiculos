using ControleVeicular.Domain.Entities;
using System.Collections.Generic;

namespace ControleVeicular.Domain.Interfaces.Services
{
    public interface IMarcaService : IServiceBase<Marca>
    {
        IEnumerable<Marca> BuscarPorNome(string nome);
    }
}
