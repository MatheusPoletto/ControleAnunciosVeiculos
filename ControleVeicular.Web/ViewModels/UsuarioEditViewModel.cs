using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ControleVeicular.Web.ViewModels
{
    public class UsuarioEditViewModel
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Preencha o Nome")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [MinLength(10, ErrorMessage = "Mínimo de 10 caracteres")]
        public string Nome { get; set; }

        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "Nova Senha e Confirmação de Nova Senha devem ser iguais")]
        [Display(Name = "Confirmação de Nova Senha")]
        public string ConfirmacaoSenha { get; set; }
    }
}
