using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace IT_Gadget.DbClasses
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierFullAddress { get; set; }
        public int SupplierPhoneNumber { get; set; }
        public List<Product> Products { get; set; }
    }
}
