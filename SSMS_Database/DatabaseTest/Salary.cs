using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employees.WebAPI.Models
{
    public class Salary
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public Salary(int id, int amount)
        {
            this.Id = id;
            this.Amount = amount;
        }
    }
}