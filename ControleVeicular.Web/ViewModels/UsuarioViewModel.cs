using System.ComponentModel.DataAnnotations;

namespace ControleVeicular.Web.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Preencha o Nome")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [MinLength(10, ErrorMessage = "Mínimo de 10 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o Login")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [MinLength(10, ErrorMessage = "Mínimo de 10 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Preencha a Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Preencha a Confirmação de Senha")]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "Senha e Confirmação de Senha devem ser iguais")]
        [Display(Name = "Confirmação de Senha")]
        public string ConfirmacaoSenha { get; set; }
    }
}
