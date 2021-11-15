using System.ComponentModel.DataAnnotations;

namespace DesafioUbistart.Models
{
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        [Required(ErrorMessage = "O Token é obrigatório")]
        public string Token { get; set; }

        [MaxLength(255)]
        [Required(ErrorMessage = "O Email é obrigatório")]
        public string Email { get; set; }
    }
}
