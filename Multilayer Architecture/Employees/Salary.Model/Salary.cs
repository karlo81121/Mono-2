using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary.Model
{
    public class Salary
    {
        public Guid? Id { get; set; }
        public int Amount { get; set; }

        public Salary(int amount)
        {
            this.Amount = amount;
        }
    }
}
