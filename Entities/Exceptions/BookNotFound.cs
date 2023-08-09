namespace Entities.Exceptions
{
    public sealed class BookNotFoundException : NotFoundException // Herhangi bir şekilde kalıtım yapılması mümkün değil !!!
    {
        public BookNotFoundException(int id) : base($"The book with id : {id} could not found.")
        {

        }
    }
}
