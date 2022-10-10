using Employeess.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeess.Model
{
    public class Salary : ISalary
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public Salary()
        {
            this.Id = 0;
            this.Amount = 0;
        }
        public Salary(int id, int amount)
        {
            this.Id = id;
            this.Amount = amount;
        }
    }
}
