using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Lab10.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<EBook> Enrollments { get; set; }

    }
    public class EBook
    {
        public int ID { get; set; }
        public string BookName { get; set; }
        public string Genre { get; set; }
        public int ?AuthorId { get; set; }
        public Author Author { get; set;  }

    }
 
}

    