namespace Entities.RequestFeatures
{
    public class BookParameters : RequestParameters
    {
        public uint MinPrice { get; set; } // Fiyat ifadesi negatif olamayacağı için "uint" Sadece pozitif doğal sayılar
        public uint MaxPrice { get; set; } = 1000;
        public bool ValidPriceRange => MaxPrice > MinPrice;
        public string? SearchTerm { get; set; }

        public BookParameters()
        {
            OrderBy = "id"; // Default olarak Sort işlemi bu field için olacak.
        }

    }
}
