using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Request.Rent;
using Entities.DataTransferObjects.Response.Author;
using Entities.DataTransferObjects.Response.Rent;
using Entities.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RentService : IRentService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;


        public RentService(IRepositoryManager repositoryManager, ILoggerService logger)
        {
            _manager = repositoryManager;
            _logger = logger;
        }

        public async Task<GetRentWithBookResponseModel> GetRentWithBook(int bookId)
        {
            var rentBook = _manager.Rent
               .FindByCondition((x => x.BookId == bookId), false)
               .Where(x => !x.IsDeleted)
               .Include(u => u.User)
               .Include(b => b.Book)
               .Select(x => new GetRentWithBookResponseModel
               {
                   BookName = x.Book.Title,
                   UserName = x.User.Name + " " + x.User.LastName,
                   IssueDate = x.IssueDate.ToString("dd-MM-yyyy"),
                   ReturnDate = x.ReturnDate.ToString("dd-MM-yyyy")
               }).FirstOrDefault();
               

            return rentBook;
        }

        public async Task<Rent> RefundBook(int rentId)
        {
            var entity = _manager.Rent.FindByCondition((x => x.Id == rentId), true).FirstOrDefault();
            entity.IsDeleted = true;
            _manager.Rent.Update(entity);
            await _manager.SaveAsync();
            return entity;
        }

        public async Task<Rent> RentBook(CreateRentRequestModel request)
        {
            var entity = request.Adapt<Rent>();
            _manager.Rent.Create(entity);
            await _manager.SaveAsync();
            return entity;
        }
    }
}
