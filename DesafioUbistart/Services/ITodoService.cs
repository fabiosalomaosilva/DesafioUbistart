using DesafioUbistart.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioUbistart.Services
{
    public interface ITodoService
    {
        Task<TodoViewModel> Add(TodoEditViewModel todoVm, int userId);
        Task ConcludeTodo(int todoId);
        Task<bool> Delete(int todoId, int userId);
        Task<TodoViewModel> Edit(TodoEditViewModel todoVm, int todoId, int userId);
        Task<PaginatedList<TodoAdminViewModel>> GetAll(int pageNumber = 0, int pageSize = 15);
        Task<List<TodoViewModel>> GetAllByUser(int userId);
        Task<PaginatedList<TodoAdminViewModel>> GetAllExpired(int pageNumber = 0, int pageSize = 15);
    }
}