using DesafioUbistart.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DesafioUbistart.Services
{
    public interface ITokenService
    {
        Task<TokenViewModel> GenerateTokenAsync(UserViewModel user);
        ClaimsPrincipal GetClaimsPrincipal(string token);
        Task<TokenViewModel> RegenerateTokenAsync(IEnumerable<Claim> claims, string refreshToken);
    }
}