using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
#nullable disable
namespace IT_Gadget.DbClasses
{
    [Keyless]
    public class Role
    {
        public enum Roles
        {
            Admin,
            Warehouse,
            Sales
        }
    }
}
