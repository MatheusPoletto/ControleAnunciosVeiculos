using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControleVeicular.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }

        public string Senha { get; set; }

        public Usuario(string nome, string login, string senha)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
        }

        public void SetSenhaCriptografada(string senha)
        {
            Senha = GerarHashSenha(senha);
        }

        public bool Comparar(Usuario usuarioA, Usuario usuarioB)
        {
            return usuarioA.Login.Equals(usuarioB.Login)
                && usuarioA.Senha.Equals(usuarioB.Senha);
        }

        private string GerarHashSenha(string senha)
        {
            using (var provider = System.Security.Cryptography.MD5.Create())
            {
                StringBuilder builder = new StringBuilder();

                foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(senha)))
                    builder.Append(b.ToString("x2").ToLower());

                return builder.ToString();
            }
        }
    }
}
