using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public bool Rented { get; set; } = false;
        public Category Category { get; set; }
        public Author Author { get; set; }

        public virtual List<Rent> RentList { get; set; }
    }
}
