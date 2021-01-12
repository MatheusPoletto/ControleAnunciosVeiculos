using ControleVeicular.Domain.Entities;

namespace ControleVeicular.Application.Interfaces
{
    public interface IUsuarioAppService : IAppServiceBase<Usuario>
    {
        bool Autenticar(Usuario usuarioAutenticando);
        Usuario BuscarPorLogin(string login);
    }
}
