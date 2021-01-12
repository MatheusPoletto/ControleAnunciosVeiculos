using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ControleVeicular.Web.ViewModels
{
    public class UsuarioLoginViewModel
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Preencha o Login")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [MinLength(10, ErrorMessage = "Mínimo de 10 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Preencha a Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
