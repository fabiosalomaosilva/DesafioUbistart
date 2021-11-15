using DesafioUbistart.Models;
using DesafioUbistart.Services;
using DesafioUbistart.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioUbistart.Controllers
{
    [Authorize(Roles = RoleTypes.All)]
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "ClientId").Value);
                var listaTodos = await _todoService.GetAllByUser(userId);

                return Ok(listaTodos);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(TodoEditViewModel todoEditViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "ClientId").Value);
                    var todo = await _todoService.Add(todoEditViewModel, userId);

                    return Ok(todo);
                }
                return BadRequest("Dados do Todo não foram informados.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TodoEditViewModel todoEditViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!await _todoService.IsExistsAsync(id)) return BadRequest("Tarefa não existe no banco de dados");
                    if (await _todoService.IsDoneAsync(id)) return BadRequest("Tarefa não pode ser modificada. Tarefa já concluída.");
                    var userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "ClientId").Value);
                    var todo = await _todoService.Edit(todoEditViewModel, id, userId);

                    return Ok(todo);
                }
                return BadRequest("Dados do Todo não foram informados.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(TodoDoneViewModel todoDoneViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!todoDoneViewModel.TaskCompleted)
                    {
                        return BadRequest("Tarefa não concluída. Dados enviados de forma errada.");
                    }
                    await _todoService.ConcludeTodo(todoDoneViewModel.TodoId);

                    return Ok("Tarefa concluída com sucesso!");
                }
                return BadRequest("Dados do Todo não foram informados.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "ClientId").Value);
                    var deleted = await _todoService.Delete(id, userId);

                    if (deleted)
                    {
                        return Ok("Tarefa excluída com sucesso!");
                    }
                    else
                    {
                        return BadRequest("Tarefa não pertence ao usuário.");
                    }
                }
                return BadRequest("Dados do Todo não foram informados.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}
