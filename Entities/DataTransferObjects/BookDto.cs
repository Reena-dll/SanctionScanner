namespace Entities.DataTransferObjects
{

    public record BookDto // Data Transfer Object -- Modele göre data nesnesi oluşturma.
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool Rented { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
    }
    
}
