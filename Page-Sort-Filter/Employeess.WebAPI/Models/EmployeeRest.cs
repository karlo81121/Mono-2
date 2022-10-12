using Employeess.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeess.Model
{
    public class EmployeeRest : IEmployeeRest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public EmployeeRest()
        {
            this.Id = 0;
            this.FirstName = "";
            this.LastName = "";
        }

        public EmployeeRest(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
