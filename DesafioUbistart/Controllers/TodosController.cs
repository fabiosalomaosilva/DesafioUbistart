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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpPost]
        public async Task<ActionResult> Post(TodoEditViewModel todoEditViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "ClientId").Value);
                    var todo = await _todoService.Add(todoEditViewModel, id);

                    return Ok(todo);
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
