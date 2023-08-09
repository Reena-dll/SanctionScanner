using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IDataShaper<T>
    {
        IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entites, string fieldsString);
        ExpandoObject ShapeData(T entity, string fieldsString); // Biri liste birisi tek bir obje olarak 2 adet imza.
    }
}
