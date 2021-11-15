using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesafioUbistart.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(60)]
        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
