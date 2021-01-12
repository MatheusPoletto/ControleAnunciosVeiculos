using System;

namespace ControleVeicular.Domain.Entities
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string Nome { get; private set; }

        public Marca(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O Nome da Marca deve ser informado");

            Nome = nome;
        }
    }
}
