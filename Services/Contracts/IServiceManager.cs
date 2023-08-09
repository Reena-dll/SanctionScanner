using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IBookService BookService { get; }
        IUserService UserService { get; }
        IAuthorService AuthorService { get; }
        ICategoryService CategoryService { get; }
        IRentService RentService { get; }
    }
}
