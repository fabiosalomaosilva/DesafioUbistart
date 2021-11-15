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

        public async Task<List<TodoViewModel>> GetAllByuser(int userId)
        {
            return (await _repository.GetAllByUserAsync(userId)).Select(s => new TodoViewModel { Description = s.Description, Expirated = s.ExpirationDate < DateTime.UtcNow }).ToList();

        }

        public async Task<List<TodoAdminViewModel>> GetAll(int? pageNumber, int? pageSize)
        {
            return (await _repository.GetAllAsync(null, pageNumber, pageSize)).Select(s => new TodoAdminViewModel
            {
                Description = s.Description,
                ExpirationDate = (DateTime)s.ExpirationDate,
                Email = s.User.Email,
                Id = s.Id
            }).ToList();
        }

        public async Task<List<TodoAdminViewModel>> GetAllExpired(string searchString, int? pageNumber, int? pageSize)
        {
            return (await _repository.GetAllAsync(searchString, pageNumber, pageSize)).Select(s => new TodoAdminViewModel
            {
                Description = s.Description,
                ExpirationDate = (DateTime)s.ExpirationDate,
                Email = s.User.Email,
                Id = s.Id
            }).ToList();
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

    }
}
