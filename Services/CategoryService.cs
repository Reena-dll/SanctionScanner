using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Request.Category;
using Entities.DataTransferObjects.Response.Author;
using Entities.DataTransferObjects.Response.Category;
using Entities.Models;
using Mapster;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {

        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;

        public CategoryService(IRepositoryManager repositoryManager, ILoggerService logger)
        {
            _manager = repositoryManager;
            _logger = logger;
        }

        public async Task<Category> CreateOneAuthorAsync(CreateCategoryRequestModel request)
        {
            var entity = request.Adapt<Category>();
            _manager.Category.Create(entity);
            await _manager.SaveAsync();
            return entity;
        }

        public async Task<List<GetAllCategoryResponseModel>> GetAllCategories()
        {
            var categoryList = _manager.Category
               .FindAll(false)
               .Where(x => !x.IsDeleted)
               .Adapt<List<GetAllCategoryResponseModel>>()
               .ToList();

            return categoryList;
        }
    }
}
