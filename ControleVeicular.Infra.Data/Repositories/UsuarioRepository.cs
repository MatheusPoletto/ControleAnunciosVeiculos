using ControleVeicular.Domain.Entities;
using ControleVeicular.Domain.Interfaces.Repositories;
using System.Linq;

namespace ControleVeicular.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public Usuario BuscarPorLogin(string login)
        {
            return Db.Usuarios.Where(u => u.Login.Equals(login)).FirstOrDefault();
        }

        public void Update(Usuario usuario)
        {
            DetachLocal(_ => _.UsuarioId == usuario.UsuarioId);
            base.Update(usuario);
        }
    }
}
