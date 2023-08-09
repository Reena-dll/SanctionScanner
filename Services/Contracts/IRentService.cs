using Entities.DataTransferObjects.Request.Rent;
using Entities.DataTransferObjects.Response.Category;
using Entities.DataTransferObjects.Response.Rent;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IRentService
    {

        Task<GetRentWithBookResponseModel> GetRentWithBook(int bookId);
        Task<Rent> RentBook(CreateRentRequestModel request);
        Task<Rent> RefundBook(int rentId);
    }
}
