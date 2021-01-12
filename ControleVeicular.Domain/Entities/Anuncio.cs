using System;
using System.ComponentModel.DataAnnotations;

namespace ControleVeicular.Domain.Entities
{
    public class Anuncio
    {
        public int AnuncioId { get; set; }
        public int ModeloId { get; set; }
        public virtual Modelo Modelo { get; set; }
        public int MarcaId { get; set; }
        public virtual Marca Marca { get; set; }
        public string Ano { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal ValorCompra { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal ValorVenda { get; set; }
        public string Cor { get; set; }
        public string TipoCombustivel { get; set; }
        public DateTime? DataVenda { get; set; }
    }
}
