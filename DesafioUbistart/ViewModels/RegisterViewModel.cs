using System.ComponentModel.DataAnnotations;

namespace DesafioUbistart.ViewModels
{
    public class RegisterViewModel
    {
        [MaxLength(255, ErrorMessage = "Campo E-mail pode ter no máximo {0} caracteres")]
        [Required(ErrorMessage = "O campo E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo deve ser um e-mail")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [MaxLength(60, ErrorMessage = "Campo Senha pode ter no máximo {0} caracteres")]
        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [Display(Name = "Senha")]
        public string Password { get; set; }
    
        [Required(ErrorMessage = "O campo Role é obrigatório")]
        public int RoleId { get; set; }
    }
}
