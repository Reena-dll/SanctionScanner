using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager // Bütün repo'larımın bulunduğu Manager katmanı.
    {
        IBookRepository Book { get; }
        IUserRepository User { get; }
        IRoleClaimRepository RoleClaim { get; }
        IAuthorRepository Author { get; }
        ICategoryRepository Category { get; }
        IRentRepository Rent { get; }
        Task SaveAsync();
    }
}
