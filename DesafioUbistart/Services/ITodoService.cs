using DesafioUbistart.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioUbistart.Services
{
    public interface ITodoService
    {
        Task<TodoViewModel> Add(TodoEditViewModel todoVm, int userId);
        Task<List<TodoViewModel>> GetAll(int userId);
    }
}