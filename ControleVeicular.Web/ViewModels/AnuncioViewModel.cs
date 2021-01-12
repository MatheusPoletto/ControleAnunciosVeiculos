using ControleVeicular.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleVeicular.Web.ViewModels
{
    public class AnuncioViewModel
    {
        [Key]       
        public int AnuncioId { get; set; }

        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "Selecione o Modelo")]
        public int ModeloId { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "Selecione a Marca")]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "Preencha o Ano")]
        [MaxLength(4, ErrorMessage = "Máximo de 4 caracteres")]
        public string Ano { get; set; }
        [Required(ErrorMessage = "Preencha o Valor de Compra")]
        public decimal ValorCompra { get; set; }
        [Required(ErrorMessage = "Preencha o Valor de Venda")]
        public decimal ValorVenda { get; set; }

        [Required(ErrorMessage = "Preencha a Cor")]
        [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "Preencha o Tipo de Combustível")]
        [MaxLength(15, ErrorMessage = "Máximo de 15 caracteres")]
        [Display(Name = "Tipo de Combustível")]
        public string TipoCombustivel { get; set; }
        public DateTime? DataVenda { get; set; }
    }
}
