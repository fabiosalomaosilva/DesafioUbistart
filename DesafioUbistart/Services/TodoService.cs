using DesafioUbistart.ViewModels;
using System.Threading.Tasks;
using DesafioUbistart.Repositories;
using DesafioUbistart.Models;
using System.Linq;
using System;
using System.Collections.Generic;

namespace DesafioUbistart.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TodoViewModel>> GetAllByUser(int userId)
        {
            return (await _repository.GetAllByUserAsync(userId)).Select(s => new TodoViewModel { Id = s.Id, Description = s.Description, Expirated = s.ExpirationDate < DateTime.UtcNow }).ToList();

        }

        public async Task<PaginatedList<TodoAdminViewModel>> GetAll(int pageNumber = 1, int pageSize = 15)
        {
            var listaTodos = (await _repository.GetAllExpiredAsync()).Select(s => new TodoAdminViewModel
            {
                Description = s.Description,
                ExpirationDate = (DateTime)s.ExpirationDate,
                Email = s.User.Email,
                Id = s.Id
            }).ToList();
            return PaginatedList<TodoAdminViewModel>.Create(listaTodos, pageNumber, pageSize);

        }

        public async Task<PaginatedList<TodoAdminViewModel>> GetAllExpired(int pageNumber, int pageSize)
        {
            if(pageSize == 0) pageSize = 15;

            var listaTodos = (await _repository.GetAllAsync()).Select(s => new TodoAdminViewModel
            {
                Description = s.Description,
                ExpirationDate = (DateTime)s.ExpirationDate,
                Email = s.User.Email,
                Id = s.Id
            }).ToList();
            return PaginatedList<TodoAdminViewModel>.Create(listaTodos, pageNumber, pageSize);
        }

        public async Task<TodoViewModel> Add(TodoEditViewModel todoVm, int userId)
        {
            var todo = new Todo
            {
                Description = todoVm.Description,
                ExpirationDate = todoVm.ExpirationDate,
                UserId = userId
            };

            var todoResult = await _repository.Add(todo);
            return new TodoViewModel { Id = todoResult.Id, Description = todoResult.Description, Expirated = todoResult.ExpirationDate < DateTime.UtcNow };
        }

        public async Task ConcludeTodo(int todoId)
        {

            await _repository.ConcludeAsync(todoId);
        }

        public async Task<TodoViewModel> Edit(TodoEditViewModel todoVm, int todoId, int userId)
        {
            if (!(await _repository.ExistsTodoAsync(todoId))) return null;
            var todoIten = await _repository.Get(todoId);
            if (todoIten.UserId != userId) return null;

            var todo = new Todo
            {
                Description = todoVm.Description,
                ExpirationDate = todoVm.ExpirationDate,
                Id = todoId
            };
            var todoResult = await _repository.EditAsync(todo, todoId);
            return new TodoViewModel { Id = todoResult.Id, Description = todoResult.Description, Expirated = todoResult.ExpirationDate < DateTime.UtcNow };
        }

        public async Task<bool> Delete(int todoId, int userId)
        {
            var todo = await _repository.Get(todoId);
            if (todo.UserId != userId) return false;
            await _repository.DeleteAsync(todoId);
            return true;
        }
    }
}
