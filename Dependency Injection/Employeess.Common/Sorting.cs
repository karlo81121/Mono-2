using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeess.Common
{
    public class Sorting
    {
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        enum Order
        {
            ASC,
            DESC
        }

        public Sorting()
        {
            this.SortBy = "ID";
            this.SortOrder = Order.DESC.ToString();
        }
    }
}
