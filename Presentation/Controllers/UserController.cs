using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {

        private readonly IServiceManager _manager;

        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }



        [HttpGet("GetUserListForLogin")]
        public async Task<IActionResult> GetUserListForLogin()
        {
            var result = await _manager.UserService.GetUserListForLogin();

            if (result.HasError)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Data);
        }
        [HttpGet("GetAllUserList")]
        public async Task<IActionResult> GetAllUserList()
        {
            var result = await _manager.UserService.GetAllUserList();

            if (result.HasError)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Data);
        }
    }
}
