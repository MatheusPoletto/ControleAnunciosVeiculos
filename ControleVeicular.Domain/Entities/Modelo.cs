using System;

namespace ControleVeicular.Domain.Entities
{
    public class Modelo
    {
        public int ModeloId { get; set; }
        public string Nome { get; private set; }

        public Modelo(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O Nome do Modelo deve ser informado");

            Nome = nome;
        }
    }
}
