using DesafioUbistart.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioUbistart.Repositories
{
    public interface ITodoRepository
    {
        Task<Todo> Add(Todo todo);
        Task<Todo> ConcludeAsync(int todoId);
        Task DeleteAsync(int todoId);
        Task<Todo> EditAsync(Todo todo, int todoId);
        Task<bool> TodoIsDoneAsync(int todoId);
        Task<bool> TodoIsExistsAsync(int todoId);
        Task<Todo> Get(int todoId);
        Task<List<Todo>> GetAllByUserAsync(int userId);
        IQueryable<Todo> GetAll();
        IQueryable<Todo> GetAllExpired();
    }
}