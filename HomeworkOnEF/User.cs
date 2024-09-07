using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOnEF
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Role { get; set; }

        Book Book { get; set; } 
        List<Book> books { get; set; } = new List<Book>();  
    }
}
