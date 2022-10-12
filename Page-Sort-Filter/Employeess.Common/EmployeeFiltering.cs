using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeess.Common
{
    public class EmployeeFiltering
    {
        public DateTime? MinDateOfBirth { get; set; }
        public DateTime? MaxDateOfBirth { get; set; }

        public EmployeeFiltering(DateTime? minDateOfBirth, DateTime? maxDateOfBirth)
        {
            this.MinDateOfBirth = minDateOfBirth;
            this.MaxDateOfBirth = maxDateOfBirth;
        }
    }
}
