using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public sealed class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneBook(Book book) => Create(book);


        public void DeleteOneBook(Book book) => Delete(book);

        public async Task<PagedList<Book>> GetAllBooksAsync(BookParameters bookParameters, bool trackChanges)
        {
            var books = await FindAll(trackChanges)
              .Where(x => !x.IsDeleted)
              .FilterBooks(bookParameters.MinPrice, bookParameters.MaxPrice)
              .Search(bookParameters.SearchTerm)
              .Sort(bookParameters.OrderBy)
              .Include(x => x.Author)
              .Include(x => x.Category)
              .ToListAsync();

            return PagedList<Book>.ToPagedList(books, bookParameters.PageNumber, bookParameters.PageSize);

        }


        public async Task<Book> GetOneBookByIdAsync(int id, bool trackChanges) =>
           await FindByCondition(b => b.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void UpdateOneBook(Book book) => Update(book);

        public void UpdateRentField(int id)
        {
            var entity = FindByCondition(b => b.Id.Equals(id), false).SingleOrDefault();

            if (entity.Rented)
            {
                entity.Rented = false;
            }
            else
            {
                entity.Rented= true;
            }

            Update(entity);

        }
    }
}
