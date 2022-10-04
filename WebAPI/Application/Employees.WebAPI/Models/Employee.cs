using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employees.WebAPI.Models
{
    public class Employee
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee(string firstName, string lastName)
        {
            this.Id = Guid.NewGuid();
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}