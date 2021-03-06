﻿using System.ComponentModel.DataAnnotations;

namespace ControleVeicular.Web.ViewModels
{
    public class ModeloViewModel
    {
        [Key]
        public int ModeloId { get; set; }

        [Required(ErrorMessage = "Preencha o Nome")]
        [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [MinLength(1, ErrorMessage = "Mínimo de 1 caracteres")]
        public string Nome { get; set; }
    }
}
