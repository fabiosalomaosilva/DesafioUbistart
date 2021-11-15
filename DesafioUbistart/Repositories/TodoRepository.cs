using DesafioUbistart.Data;
using DesafioUbistart.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioUbistart.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _db;

        public TodoRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<List<Todo>> GetAllAsync(string searchString, int? pageNumber = 0, int pageSize = 15)
        {
            var listaTodos = new List<Todo>();
            if (!string.IsNullOrEmpty(searchString))
            {
                listaTodos = await _db.Todos.Include(i => i.User).AsNoTracking().Where(p => p.Description.Contains(searchString)).ToListAsync();
            }

            return await PaginatedList<Todo>.CreateAsync(listaTodos.AsQueryable().AsNoTracking(), pageNumber ?? 1, pageSize);
        }

        public async Task<bool> ExistsTodo(int todoId)
        {
            return await _db.Todos.AnyAsync(p => p.Id == todoId);
        }

        public async Task<List<Todo>> GetAllByUserAsync(int userId)
        {
            return await _db.Todos.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<Todo> Add(Todo todo)
        {
            if (string.IsNullOrEmpty(todo.Description)) return null;
            _db.Todos.Add(todo);
            await _db.SaveChangesAsync();
            return todo;
        }

        public async Task<Todo> EditAsync(Todo todo, int todoId)
        {
            if (todo.Done) return null;
            var obj = await _db.Todos.FindAsync(todoId);
            obj.LastUpdateDate = System.DateTime.UtcNow;
            _db.Entry(obj).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return todo;
        }

        public async Task<Todo> ConcludeAsync(int todoId)
        {
            var todo = await _db.Todos.FindAsync(todoId);
            if (todo.Done) return null;
            todo.Done = true;
            todo.ExpirationDate = System.DateTime.UtcNow;
            _db.Entry(todo).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return todo;
        }

        public async Task DeleteAsync(int todoId)
        {
            var obj = await _db.Todos.FindAsync(todoId);
            _db.Remove(obj);
            await _db.SaveChangesAsync();
        }
    }
}
