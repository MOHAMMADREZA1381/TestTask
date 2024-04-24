using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Test.Application.IServices;
using Test.Domain.Models.User;
using Test.Domain.ViewModel.User;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Services

        private readonly IUserService _service;
        public AccountController(IUserService service)
        {
            _service = service;
        }

        #endregion

        [HttpPost("register")]
        public async Task<JsonResult> Register([FromBody] UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.Register(viewModel);
                return new JsonResult(Ok());
            }

            return new JsonResult(BadRequest());
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var User = await _service.GetUserByEmail(viewModel.Email);
                var res = await _service.Login(viewModel);
                switch (res)
                {
                    case State.NotFound:
                        return new JsonResult(NotFound());
                        break;
                    case State.WrongPassword:
                        return new JsonResult(BadRequest());
                        break;
                 
                    case State.Successed:
                        List<Claim> claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier, User.Id.ToString()),
                            new Claim(ClaimTypes.Email, User.Email),
                        };

                        ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(principal, new AuthenticationProperties()
                        {
                            IsPersistent = true
                        });
                        return new JsonResult(Ok());
                }
            }
            return new JsonResult(BadRequest());
        }



        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }
    }
}
