using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeess.Common
{
    public class SalaryFiltering
    {
        public int Amount { get; set; }

        public SalaryFiltering(int amount)
        {
            this.Amount = amount;
        }
    }
}
