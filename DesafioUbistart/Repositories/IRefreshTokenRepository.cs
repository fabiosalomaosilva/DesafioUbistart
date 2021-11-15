using DesafioUbistart.Models;
using System.Threading.Tasks;

namespace DesafioUbistart.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<string> GetByEmail(string email);
        Task<bool> ExistsToken(string token);
        Task Save(RefreshToken token);
        Task Delete(string token);
    }
}
