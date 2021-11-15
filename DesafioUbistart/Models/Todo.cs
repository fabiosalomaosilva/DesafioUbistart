using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesafioUbistart.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Usuário é obrigatório")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        public string Description { get; set; }
        public bool Done { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;
        public DateTime? ExpirationDate { get; set; }
        public DateTime? DateOfDone { get; set; }

    }
}
