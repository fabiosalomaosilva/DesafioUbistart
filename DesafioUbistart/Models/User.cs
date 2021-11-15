using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesafioUbistart.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
     
        [MaxLength(255)]
        [Required(ErrorMessage = "O campo E-mail é obrigatório")]
        public string Email { get; set; }

        [MaxLength(60)]
        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        public string Password { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public ICollection<Todo> Todos { get; set; }
    }
}
