using ControleVeicular.Domain.Entities;

namespace ControleVeicular.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Usuario BuscarPorLogin(string login);

        bool Autenticar(Usuario usuario);

    }
}
