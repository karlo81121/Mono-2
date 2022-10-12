using Employeess.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeess.Model
{
    public class SalaryRest : ISalaryRest
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public SalaryRest()
        {
            this.Id = 0;
            this.Amount = 0;
        }

        public SalaryRest(int id, int amount)
        {
            this.Id = id;
            this.Amount = amount;
        }
    }
}
