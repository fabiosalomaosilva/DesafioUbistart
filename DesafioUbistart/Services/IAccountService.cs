using DesafioUbistart.ViewModels;
using System.Threading.Tasks;

namespace DesafioUbistart.Services
{
    public interface IAccountService
    {
        Task<UserViewModel> Register(RegisterViewModel registerViewModel);
        Task<UserViewModel> SignAsync(LoginViewModel loginViewModel);
    }
}