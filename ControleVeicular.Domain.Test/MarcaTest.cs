using ControleVeicular.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ControleVeicular.Domain.Test
{
    [TestClass]
    public class MarcaTest
    {
        [TestMethod]
        public void Marca_CriarMarca_RetornaMarca()
        {
            var marcaEsperado = new
            {
                Nome = "Ford",
            };

            var marca = new Marca(marcaEsperado.Nome);

            Assert.AreEqual(marcaEsperado.Nome, marca.Nome);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Marca_CriarMarca_NaoPermitirMarcaEmBranco()
        {
            var marca = new Marca(null);
        }
    }
}
