using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeess.Model.Common
{
    public interface ISalary
    {
        int Id { get; set; }
        int Amount { get; set; }
    }
}
