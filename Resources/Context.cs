using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using IT_Gadget.DbClasses;
using IT_Gadget.Data;
using IT_Gadget.Resources;
#nullable disable
namespace IT_Gadget.Resources
{
    internal class Context : DbContext
    {
        //----------------------------- DataBase Connection -------------------------------//

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=I0250307\SQLEXPRESS;Database=IT_Gadget;Trusted_Connection=True;");
        }
    }
}
