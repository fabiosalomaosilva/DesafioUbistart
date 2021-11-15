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
    public class AdminTodosController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public AdminTodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }


        [HttpGet]
        public async Task<ActionResult> GetVencidos([FromQuery] bool todosExpired, [FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            try
            {
                PaginatedList<TodoAdminViewModel> listaTodos = null;
                if (todosExpired)
                {
                    listaTodos = await _todoService.GetAllExpired(pageNumber, pageNumber);
                }
                else
                {
                    listaTodos = await _todoService.GetAll(pageNumber, pageNumber);

                }

                return Ok(listaTodos);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }

}
