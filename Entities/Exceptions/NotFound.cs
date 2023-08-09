
namespace Entities.Exceptions
{
    public abstract class NotFoundException : Exception //new'leme yapılması mümkün olmayacak!!!
    {// Notfound için genel bir sınıf
        protected NotFoundException(string message) : base(message)
        {

        }
    }
}
