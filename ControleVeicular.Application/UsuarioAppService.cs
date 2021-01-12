using ControleVeicular.Application.Interfaces;
using ControleVeicular.Domain.Entities;
using ControleVeicular.Domain.Interfaces.Services;

namespace ControleVeicular.Application
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService) : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public bool Autenticar(Usuario usuarioAutenticando)
        {
            return _usuarioService.Autenticar(usuarioAutenticando);
        }

        public Usuario BuscarPorLogin(string login)
        {
            return _usuarioService.BuscarPorLogin(login);
        }
    }
}
