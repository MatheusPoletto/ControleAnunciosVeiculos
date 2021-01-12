using ControleVeicular.Domain.Entities;
using ControleVeicular.Domain.Interfaces.Repositories;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ControleVeicular.Infra.Data.Repositories
{
    public class MarcaRepository : RepositoryBase<Marca>, IMarcaRepository
    {
        public IEnumerable<Marca> BuscarPorNome(string nome)
        {
            return Db.Marcas.Where(p => p.Nome.Equals(nome));
        }
    }
}
