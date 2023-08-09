using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract record BookDtoForManipulation // Data Transfer Object -- Modele göre data nesnesi oluşturma. Bu bölümde ekstra olarak Attribute kullanarak nesne içerisinde fieldlara validation yaptık.
    {
        [Required(ErrorMessage = "Title is a required field.")]
        [MinLength(2, ErrorMessage = "Title must consist of at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "Title must consist of at maximum 50 characters.")]
        public string Title { get; init; }

        [Required(ErrorMessage = "Title is a required field.")]
        [Range(10,1000)]
        public decimal Price { get; init; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }

    }
}
