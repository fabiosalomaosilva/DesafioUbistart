using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioUbistart.ViewModels
{
    public class TodoEditViewModel
    {
        [MaxLength(255, ErrorMessage = "Campo Descrição pode ter no máximo {0} caracteres")]
        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Vencimento")]
        public DateTime ExpirationDate { get; set; }

    }
    public class TodoViewModel
    {
        public int Id { get; set; }

        [MaxLength(255, ErrorMessage = "Campo Descrição pode ter no máximo {0} caracteres")]
        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Vencido")]
        public bool Expirated { get; set; } = false;

    }
    public class TodoAdminViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime ExpirationDate { get; set; }
        public string Email { get; set; }

    }
}
