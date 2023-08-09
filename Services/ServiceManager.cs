using AutoMapper;
using Entities.DataTransferObjects;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IAuthorService> _authorService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IRentService> _rentService;
        public ServiceManager(IRepositoryManager repositoryManager,ILoggerService logger, IMapper mapper, IDataShaper<BookDto> dataShaper)
        {
            _bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager,logger,mapper,dataShaper));
            _userService = new Lazy<IUserService>(() => new UserManager(repositoryManager,logger,mapper));
            _authorService = new Lazy<IAuthorService>(() => new AuthorService(repositoryManager,logger));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager,logger));
            _rentService = new Lazy<IRentService>(() => new RentService(repositoryManager,logger));
        }
        public IBookService BookService => _bookService.Value;

        public IUserService UserService => _userService.Value;

        public IAuthorService AuthorService => _authorService.Value;

        public ICategoryService CategoryService => _categoryService.Value;

        public IRentService RentService => _rentService.Value;
    }
}
