using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace IT_Gadget.DbClasses
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public int Category { get; set; }
        public string Description { get; set; }
        public List<Order> Orders { get; set; }
        public List<Supplier> Suppliers { get; set; }
    }
}
