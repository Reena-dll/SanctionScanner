using Entities.DataTransferObjects.Request.Author;
using Entities.DataTransferObjects.Request.Category;
using Entities.DataTransferObjects.Response.Author;
using Entities.DataTransferObjects.Response.Category;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        Task<Category> CreateOneAuthorAsync(CreateCategoryRequestModel request);
        Task<List<GetAllCategoryResponseModel>> GetAllCategories();
    }
}
