using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Rent : BaseEntity
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public DateTime ReturnDate { get; set; }

        public Book Book { get; set; }
        public User User { get; set; }
    }
}
