using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IT_Gadget;
#nullable disable
namespace IT_Gadget.DbClasses
{
    internal class Category
    {
        public enum Categories
        {
            Printer,
            Display,
            Keyboard,
            Motherboard,
            Webcam,
        }
    }
}
