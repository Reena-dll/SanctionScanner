﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public List<Book> BookList { get; set; }
    }
}
