using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeess.Common
{
    public class Filtering
    {
        public DateTime MinDateOfBirth { get; set; }
        public DateTime MaxDateOfBirth { get; set; }

        public Filtering()
        {
            this.MinDateOfBirth = new DateTime(1900,01,01,00,00,00);
            this.MaxDateOfBirth = new DateTime(2022,01,01,00,00,00);
        }
    }
}
