using ControleVeicular.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleVeicular.Domain.Test
{
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void Usuario_CriarUsuario_RetornaUsuario()
        {
            var usuarioEsperado = new
            {
                Nome = "Matheus Otavio Poletto",
                Login = "MATHEUS.POLETTO",
                Senha = "123"
            };

            var usuario = new Usuario(usuarioEsperado.Nome, usuarioEsperado.Login, usuarioEsperado.Senha);

            Assert.AreEqual(usuarioEsperado.Nome, usuario.Nome);
            Assert.AreEqual(usuarioEsperado.Login, usuario.Login);
            Assert.AreEqual(usuarioEsperado.Senha, usuario.Senha);

        }

        [TestMethod]
        public void Usuario_CriarUsuario_RetornaSenhaCriptograda()
        {
            var usuarioEsperado = new
            {
                Nome = "Matheus Otavio Poletto",
                Login = "MATHEUS.POLETTO",
                Senha = "123"
            };

            var senhaEsperada = "202cb962ac59075b964b07152d234b70";

            var usuario = new Usuario(usuarioEsperado.Nome, usuarioEsperado.Login, usuarioEsperado.Senha);
            usuario.SetSenhaCriptografada(usuarioEsperado.Senha);

            Assert.AreEqual(usuarioEsperado.Nome, usuario.Nome);
            Assert.AreEqual(usuarioEsperado.Login, usuario.Login);
            Assert.AreEqual(senhaEsperada, usuario.Senha);

        }
    }
}
