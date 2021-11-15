using DesafioUbistart.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioUbistart.Repositories
{
    public interface ITodoRepository
    {
        Task<Todo> Add(Todo todo);
        Task<Todo> ConcludeAsync(int todoId);
        Task DeleteAsync(int todoId);
        Task<Todo> EditAsync(Todo todo, int todoId);
        Task<bool> ExistsTodoAsync(int todoId);
        Task<Todo> Get(int todoId);
        Task<List<Todo>> GetAllAsync();
        Task<List<Todo>> GetAllByUserAsync(int userId);
        Task<List<Todo>> GetAllExpiredAsync();
    }
}