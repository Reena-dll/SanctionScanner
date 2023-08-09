using Entities.DataTransferObjects.Request.Author;
using Entities.DataTransferObjects.Request.Category;
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
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }


        [HttpPost]
        public async Task<IActionResult> CreateOneBook([FromBody] CreateCategoryRequestModel request)
        {

            var author = await _manager.CategoryService.CreateOneAuthorAsync(request);

            return StatusCode(201, author);

        }


        [HttpGet]
        public async Task<IActionResult> GetAllAuthor()
        {

            var authorList = await _manager.CategoryService
                .GetAllCategories();


            return Ok(authorList);
        }
    }
}
