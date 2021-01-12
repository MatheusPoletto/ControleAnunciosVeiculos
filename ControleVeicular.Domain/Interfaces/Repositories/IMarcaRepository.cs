using ControleVeicular.Domain.Entities;
using System.Collections.Generic;

namespace ControleVeicular.Domain.Interfaces.Repositories
{
    public interface IMarcaRepository : IRepositoryBase<Marca>
    {
        IEnumerable<Marca> BuscarPorNome(string nome);
    }
}
