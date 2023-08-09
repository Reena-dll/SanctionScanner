using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DataShaper<T> : IDataShaper<T> where T : class
    {
        public PropertyInfo[] Properties { get; set; } // Herhangi bir nesne üzerinde çalışırken, o nesnenin altında ki proplar için. Çalışma zamanında almak için.

        public DataShaper()
        {
            Properties = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance); // public ve new'lenebilir propertileri alıyorum.
        }

        public IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entites, string fieldsString)
        {
            var requiredFields = GetRequiredProperties(fieldsString);
            return FetchData(entites, requiredFields);
        }

        public ExpandoObject ShapeData(T entity, string fieldsString)
        {
            var requiredProperties = GetRequiredProperties(fieldsString);
            return FetchDataForEntity(entity, requiredProperties);
        }

        private IEnumerable<PropertyInfo> GetRequiredProperties(string fieldsString)
        {
            // /books?fields=id, title " Query String de id ve title var. Hangi alanlar var ise onları almam gerekiyor, diğerlerini çıkartmam gerekiyor nesnemden.

            var requiredFields = new List<PropertyInfo>();
            if(!string.IsNullOrWhiteSpace(fieldsString))
            {
                var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries); // Virgüle bakarak hangi alanları istediklerini öğreniyorum. /books?fields=title,price  gibi                                                                                // boş olan varlıkları da kaldırdım.

                foreach (var field in fields) // Her bir alanı dönüyoruz.
                {
                    var property = Properties
                        .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));
                    if (property is null)
                        continue;
                    requiredFields.Add(property); // Gerekli olan propertileri döndük ve listemize koyduk. En sonda da onu return ediyorum.
                }
            }
            else
            {
                requiredFields = Properties.ToList(); // Zorunlu alan yok ise direkt bütün alanları dönerim.
            }

            return requiredFields;
        }

        private ExpandoObject FetchDataForEntity(T entity, IEnumerable<PropertyInfo> requiredProperties)
        {
            var shapedObject = new ExpandoObject();

            foreach (var property in requiredProperties)
            {
                var objectPropertyValue = property.GetValue(entity);
                shapedObject.TryAdd(property.Name, objectPropertyValue);
            }

            return shapedObject; // seçilen proplara bağlı olarak karşılık değerleri giriliyor.
        }

        private IEnumerable<ExpandoObject> FetchData(IEnumerable<T> entities, IEnumerable<PropertyInfo> requiredProperties)
        {
            var shapedData = new List<ExpandoObject>();

            foreach (var entity in entities)
            {
                var shapedObject = FetchDataForEntity(entity, requiredProperties);
                shapedData.Add(shapedObject); 
            }

            return shapedData;
        }
    }
}


/*
 * 1. Properties = Property tanımlarının tamamını aldık
 * 2. RequiredProperty = İhtiyaç duyulan propertyleri topladık
 * 3. Value(key-value) Fetch Data = Bu ifadelerin değerlerini key value şekliyle aldık. Her bir anahtar kelimenin karşılığını ürettik
 * 
 * 
 * ExpandoObject = Burada oluşan yeni nesne.
 */