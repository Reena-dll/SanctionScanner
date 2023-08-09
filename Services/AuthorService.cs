using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Request.Author;
using Entities.DataTransferObjects.Response.Author;
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
    public class AuthorService : IAuthorService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IDataShaper<BookDto> _shaper;

        public AuthorService(IRepositoryManager repositoryManager, ILoggerService logger)
        {
            _manager = repositoryManager;
            _logger = logger;
        }

        public async Task<Author> CreateOneAuthorAsync(CreateAuthorRequestModel request)
        {
            var entity = request.Adapt<Author>();
            _manager.Author.Create(entity);
            await _manager.SaveAsync();
            return entity;
        }

        public async Task<List<GetAllAuthorResponse>> GetAllAuthor()
        {
            var authorList = _manager.Author
                .FindAll(false)
                .Where(x => !x.IsDeleted)
                .Adapt<List<GetAllAuthorResponse>>()
                .ToList();

            return authorList;
        }
    }
}
