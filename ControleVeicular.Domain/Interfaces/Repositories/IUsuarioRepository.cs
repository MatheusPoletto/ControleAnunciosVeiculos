using ControleVeicular.Domain.Entities;

namespace ControleVeicular.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario BuscarPorLogin(string login);
    }
}
