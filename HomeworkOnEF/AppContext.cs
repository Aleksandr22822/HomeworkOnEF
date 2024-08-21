using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOnEF
{
    internal class AppContext:DbContext
    {
        public DbSet<User> Users { get; set; }
       

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = LAPTOR-6P6N7DLB; Database = EF; Trusted_Connection = true; TrustServerCertificate = true;");
        }
    }
}
