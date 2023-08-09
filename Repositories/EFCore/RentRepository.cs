using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RentRepository : RepositoryBase<Rent> , IRentRepository
    {
        public RentRepository(RepositoryContext context) : base(context)
        {

        }
    }
}
