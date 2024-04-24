using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Application.IServices;
using Test.Domain.ViewModel;

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

        [HttpPost]
        public JsonResult Register(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _service.Register(viewModel);
                return new JsonResult(Ok());
            }
            return new JsonResult(NotFound());
        }

    
    }
}
