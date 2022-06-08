using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace IT_Gadget.DbClasses
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeFirstlName { get; set; }
        public string EmployeeLastlName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Role { get; set; }
        public string EmployeeLoginId { get; set; }
        public List<Order> Orders { get; set; }
    }
}
