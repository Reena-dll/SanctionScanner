using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Request.Author
{
    public class CreateAuthorRequestModel
    {
        [Required(ErrorMessage = "Title is a required field.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Title is a required field.")]
        public string LastName { get; set; }
    }
}
