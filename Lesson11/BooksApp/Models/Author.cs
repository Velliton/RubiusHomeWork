using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public AuthorData? AuthorData { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public DateTime DateOfBirth { get; set; }
    }
}
