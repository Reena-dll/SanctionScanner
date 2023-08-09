using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager // Bütün repolarım buradan newleniyor. 
    {

        private readonly RepositoryContext _context;
        private readonly Lazy<IBookRepository> _bookRepository;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IRoleClaimRepository> _roleClaimRepository;
        private readonly Lazy<IAuthorRepository> _authorRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<IRentRepository> _rentRepository;
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_context));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_context));
            _roleClaimRepository = new Lazy<IRoleClaimRepository>(() => new RoleClaimRepository(_context));
            _authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(_context));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_context));
            _rentRepository = new Lazy<IRentRepository>(() => new RentRepository(_context));
        }

        public IBookRepository Book => _bookRepository.Value;

        public IUserRepository User => _userRepository.Value;

        public IRoleClaimRepository RoleClaim => _roleClaimRepository.Value;

        public IAuthorRepository Author => _authorRepository.Value;

        public ICategoryRepository Category => _categoryRepository.Value;

        public IRentRepository Rent => _rentRepository.Value;

        public async Task SaveAsync()
        {

            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Database.SetCommandTimeout(TimeSpan.FromMinutes(30));

                    //yeni kayıt(lar) atılırken; recordDate şuanki tarih atılıyor
                    var addedEntities = _context.ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();

                    addedEntities.ForEach(E =>
                    {
                        E.Property(nameof(BaseEntity.CreateDate)).CurrentValue = DateTime.Now;
                    });

                    //güncelleme yapılan kayıt(lar)'da; updateDate kolonuna suanki tarih verisi atılıyor
                    var editedEntities =
                        _context.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();

                    editedEntities.ForEach(e =>
                    {
                        e.Property(nameof(BaseEntity.UpdateDate)).CurrentValue = DateTime.Now;
                    });

                    await _context.SaveChangesAsync();

                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    var hata = ex;
                    //Log Exception Handling message                      
                    dbContextTransaction.Rollback();
                }
            }

        }
    }
}
