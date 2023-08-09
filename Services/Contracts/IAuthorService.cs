using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Request.Author;
using Entities.DataTransferObjects.Response.Author;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IAuthorService
    {
        Task<Author> CreateOneAuthorAsync(CreateAuthorRequestModel request);
        Task<List<GetAllAuthorResponse>> GetAllAuthor();

    }
}
