using ControleVeicular.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ControleVeicular.Domain.Test
{
    [TestClass]
    public class ModeloTest
    {
        [TestMethod]
        public void Modelo_CriarModelo_RetornaModelo()
        {
            var modeloEsperado = new
            {
                Nome = "Kia",
            };

            var modelo = new Modelo(modeloEsperado.Nome);

            Assert.AreEqual(modeloEsperado.Nome, modeloEsperado.Nome);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Modelo_CriarModelo_NaoPermitirModeloEmBranco()
        {
            var modelo = new Modelo(null);
        }
    }
}
