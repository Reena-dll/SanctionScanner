using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Repositories.EFCore.Extensions
{
    public static class BookRepositoryExtensions
    {
        public static IQueryable<Book> FilterBooks(this IQueryable<Book> books, uint minPrice, uint maxPrice) // Repo'da çağırdığım extensions metot. Filtrelemeleri kontrol etmek için.
        {
            return books.Where(book => book.Price >= minPrice && book.Price <= maxPrice); // Dışarıdan gelen parametreye göre Where sorgumu yazdım.
        }

        public static IQueryable<Book> Search(this IQueryable<Book> books, string searchTerm) // Repo'da çağırdığım extensions metot. Search işlemi.
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return books;

            var lowerCaseTerm = searchTerm.Trim().ToLower(); // İfade nasıl gelirse gelsin küçültecek.

            return books.Where(book => book.Title.ToLower().Contains(lowerCaseTerm)); // Dışarıdan gelen search datasına göre Where sorgusunu yazdım.
        }

        public static IQueryable<Book> Sort(this IQueryable<Book> books, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return books.OrderBy(b => b.Id);


            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Book>(orderByQueryString);

            if (orderQuery is null)
                return books.OrderBy(b => b.Id); // eğer metottan data dönmüyor ise bize geldiği gibi datayı sadece id'e göre sort'layıp yolluyorum.

            return books.OrderBy(orderQuery); // Nihai sonucu artık OrderBy metodunun içerisine yolluyorum. KÜTÜPHANE GEREKLİ... -System.Linq.Dynamic.Core-
        }
    }
}
