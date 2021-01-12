using ControleVeicular.Domain.Entities;
using ControleVeicular.Domain.Interfaces.Repositories;
using ControleVeicular.Domain.Interfaces.Services;
using System.Linq;

namespace ControleVeicular.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void Add(Usuario obj)
        {
            if (GetAll().ToList().Where(u => u.Login.Equals(obj.Login)).Count() > 0)
                return;

            obj.SetSenhaCriptografada(obj.Senha);
            _usuarioRepository.Add(obj);
        }

        public void Update(Usuario obj)
        {
            var usuario = GetById(obj.UsuarioId);
            if (string.IsNullOrEmpty(obj.Login))
                obj.Login = usuario.Login;
            if (string.IsNullOrEmpty(obj.Senha))
                obj.Senha = usuario.Senha;
            else
                obj.SetSenhaCriptografada(obj.Senha);

            _usuarioRepository.Update(obj);
        }

        public bool Autenticar(Usuario usuarioAutenticando)
        {
            usuarioAutenticando.SetSenhaCriptografada(usuarioAutenticando.Senha);
            var usuario = BuscarPorLogin(usuarioAutenticando.Login);
            if (usuario == null)
                return false;

            return usuario.Comparar(usuario, usuarioAutenticando);
        }

        public Usuario BuscarPorLogin(string login)
        {
            return _usuarioRepository.BuscarPorLogin(login);
        }
    }
}
