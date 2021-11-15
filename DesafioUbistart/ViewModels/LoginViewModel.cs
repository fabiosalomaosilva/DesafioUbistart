using System.ComponentModel.DataAnnotations;

namespace DesafioUbistart.ViewModels
{
    public class LoginViewModel
    {
        [MaxLength(255, ErrorMessage = "Campo E-mail pode ter no máximo {0} caracteres")]
        [Required(ErrorMessage = "O campo E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo deve ser um e-mail")]
        public string Email { get; set; }

        [MaxLength(60, ErrorMessage = "Campo Senha pode ter no máximo {0} caracteres")]
        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        public string Password { get; set; }
    }
}
