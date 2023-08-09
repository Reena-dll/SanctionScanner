using Entities.DataTransferObjects.Request.Category;
using Entities.DataTransferObjects.Request.Rent;
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
    //[Authorize(Roles = "SuperAdmin,Admin,User")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/rent")]
    public class RentController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public RentController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpPost("RentBook")]
        public async Task<IActionResult> RentBook([FromBody] CreateRentRequestModel request)
        {

            var rent = await _manager.RentService.RentBook(request);
            await _manager.BookService.UpdateRentField(rent.Id);

            return StatusCode(201);

        }

        [HttpPut("{rentId:int}")]    
        public async Task<IActionResult> RefundBook([FromRoute(Name ="rentId")] int rentId)
        {

            var rent = await _manager.RentService.RefundBook(rentId);
            await _manager.BookService.UpdateRentField(rentId);

            return StatusCode(201);

        }


        [HttpGet("{bookId:int}")]
        public async Task<IActionResult> GetRentWithBook([FromRoute(Name = "bookId")] int bookId)
        {

            var rent = await _manager.RentService
                .GetRentWithBook(bookId);


            return Ok(rent);
        }
    }
}
