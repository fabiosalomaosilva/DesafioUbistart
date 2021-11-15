namespace DesafioUbistart.ViewModels
{
    public class TokenViewModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int clientId { get; set; }
        public string email { get; set; }
        public string expires { get; set; }
        public string refreshToken { get; set; }
    }
}
