using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyProductAPI.Models;
using PartyProductAPI.Repository;
using System.Threading.Tasks;

namespace PartyProductAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel signUpModel)
        {
            var result = await _accountRepository.SignUpAsync(signUpModel);

            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] SignInModel signInModel)
        {
            var result = await _accountRepository.LogInAsync(signInModel);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }
}
