using DesafioUbistart.Models;
using System.Threading.Tasks;

namespace DesafioUbistart.Repositories
{
    public interface IUserRepository
    {
        Task<User> Get(string email, string password);
        Task<User> Save(string email, string password, int roleId);
    }
}
