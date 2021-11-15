using DesafioUbistart.Services;
using DesafioUbistart.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DesafioUbistart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IAccountService _accountService;

        public AccountController(ITokenService tokenService, IAccountService accountService)
        {
            _tokenService = tokenService;
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginViewModel loginViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userLogin = await _accountService.SignAsync(loginViewModel);
                    if (userLogin == null) return BadRequest("Usuário ou senha errados.");
                    var token = await _tokenService.GenerateTokenAsync(userLogin);
                    return Ok(token);
                }
                return BadRequest("Dados do usuário não foram informados.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterViewModel registerViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _accountService.Register(registerViewModel);
                    if (user == null) return BadRequest("O registro de usuário encontrou um erro. Tente novamente");
                    return Ok(user);
                }
                return BadRequest("Dados de cadastro deixaram de ser informados.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("refresh")]
        public async Task<ActionResult> RefreshAccess(RefreshViewModel refreshViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
                    var role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
                    var principal = _tokenService.GetClaimsPrincipal(refreshViewModel.AccessToken);
                    var refreshToken = await _tokenService.RegenerateTokenAsync(principal.Claims, refreshViewModel.RefreshToken);
                    if (refreshToken == null) return BadRequest("O token enviado não é válido.");
                    return Ok(refreshToken);
                }
                return BadRequest("Um ou dois tokens de acesso deixaram de ser informados.");

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
