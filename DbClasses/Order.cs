using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace IT_Gadget.DbClasses
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
        bool IsDelivered { get; set; }
    }
}
