using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Extensions
{
    public static class OrderQueryBuilder
    {
        public static string CreateOrderQuery<T>(string orderByQueryString)
        {
            var orderParams = orderByQueryString.Trim().Split(',');// Boşlukları silip, her virgül gördüğümde böldüm. // books?orderBy=title,price örnek. 0. elamanında title 1. elamanında price değeri olacak
            // Temel amacı url okuyup isteği anlamak.

            var propertyInfos = typeof(T)
              .GetProperties(BindingFlags.Public | BindingFlags.Instance); // Reflection ile book classının propertilerini alıyorum.


            var orderQueryBuilder = new StringBuilder();
            // Sorgudan aldığım ifade ile properti eşleşecek mi bunu kontrol edeceğim.


            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param)) // Eğer burası boş ise diğer liste üyesine geçsin.
                    continue;

                var propertyFromQueryName = param.Split(' ')[0]; //books?orderBy=title, price desc, id asc gibi bir istek geldiğinde yukarıda zaten virgül ile bölmüştüm.
                                                                 // "title", "price desc", "id asc" 3 parçalık bir liste var elimde.
                                                                 // şimdi ise hala ifade içerisinde boşluk var ise onu da bölüyorum.
                                                                 // bu şekilde desc ve asc'i yakalamış olacağım.

                var objectProperty = propertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase)); // query ile nesnenin eşleştirmesini yaptım

                if (objectProperty is null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending"; // Burada da duruma göre SORT komutlarını yazdım.

                orderQueryBuilder.Append($"{objectProperty.Name.ToString()}  {direction},");
            }
            // title ascending, price descending, id ascending,  Foreach'dan böyle bir string yapı çıkacak. Fark edilecek olursa sonda bir virgül fazla kalıyor. Onu da aşağı da çıkartıyoruz.

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            return orderQuery;
        }
    }
}
