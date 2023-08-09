using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Request.Author;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,User")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/author")]
    public class AuthorsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public AuthorsController(IServiceManager manager)
        {
            _manager = manager;
        }


        [HttpPost]
        public async Task<IActionResult> CreateOneBook([FromBody] CreateAuthorRequestModel request)
        {

            var author = await _manager.AuthorService.CreateOneAuthorAsync(request);

            return StatusCode(201, author);

        }


        [HttpGet]
        public async Task<IActionResult> GetAllAuthor()
        {

            var authorList = await _manager.AuthorService
                .GetAllAuthor();


            return Ok(authorList);
        }
    }
}
