using DesafioUbistart.ViewModels;
using System.Threading.Tasks;
using DesafioUbistart.Models;
using DesafioUbistart.Repositories;

namespace DesafioUbistart.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _repository;

        public AccountService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserViewModel> SignAsync(LoginViewModel loginViewModel)
        {
            if (string.IsNullOrEmpty(loginViewModel.Email) || string.IsNullOrEmpty(loginViewModel.Password)) return null;
            
            var user = await _repository.Get(loginViewModel.Email, loginViewModel.Password);
            if (user == null) return null;
            return new UserViewModel
            {
                ClientId = user.Id,
                Email = user.Email,
                Role = user.Role.Name
            };
        }

        public async Task<UserViewModel> Register(RegisterViewModel registerViewModel)
        {
            var user = await _repository.Save(registerViewModel.Email, registerViewModel.Password, registerViewModel.RoleId);
            return new UserViewModel { ClientId = user.Id, Email = user.Email, Role = "Client" };
        }
                
    }
}
