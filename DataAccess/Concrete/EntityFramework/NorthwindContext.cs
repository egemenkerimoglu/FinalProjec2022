using Entities.Concrete;
using Microsoft.EntityFrameworkCore;  // DbContext
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    // Context : DB tanloları ile proje classlarını bağlamak
    // DbContext' den kalıtım al
    public class NorthwindContext:DbContext
    {
        // override : projen hangi db ile ilişkisi var
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=Yes");
        }

        // Hangi Class hangi tabloya denk geliyor ayarla [Products]
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
