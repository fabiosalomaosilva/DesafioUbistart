using System.ComponentModel.DataAnnotations;

namespace DesafioUbistart.ViewModels
{
    public class TaskViewModel
    {
        public int ClientId { get; set; }

        [MaxLength(255, ErrorMessage = "Campo E-mail pode ter no máximo {0} caracteres")]
        [Required(ErrorMessage = "O campo E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo deve ser um e-mail")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public string Role { get; set; }
    }
}
