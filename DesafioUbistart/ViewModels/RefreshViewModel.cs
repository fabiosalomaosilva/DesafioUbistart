using System.ComponentModel.DataAnnotations;

namespace DesafioUbistart.ViewModels
{
    public class RefreshViewModel
    {
        [Required(ErrorMessage = "O campo Access Token é obrigatório")]
        public string AccessToken { get; set; }

        [Required(ErrorMessage = "O campo Refresh Token é obrigatório")]
        public string RefreshToken { get; set; }
    }
}
