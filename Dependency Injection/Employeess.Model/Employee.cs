using Employeess.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeess.Model
{
    public class Employee : IEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }

        public Employee()
        {
            this.Id = 0;
            this.FirstName = "";
            this.LastName = "";
            this.BirthDate = new DateTime();
            this.Gender = "";
            this.HireDate = new DateTime();
        }

        public Employee(int id, string firstName, string lastName, DateTime birthDate, string gender, DateTime hireDate)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.Gender = gender;
            this.HireDate = hireDate;
        }
    }
}
