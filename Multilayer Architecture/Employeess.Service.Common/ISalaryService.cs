using Employeess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeess.Service.Common
{
    public interface ISalaryService
    {
        Task<List<Salary>> GetAllSalariesAsync();
        Task<Salary> GetSalaryByIdAsync(int id);
        Task<bool> AddNewSalaryAsync(Salary salary);
        Task<bool> DeleteSalaryByIdAsync(int id);
        Task<bool> UpdateSalaryByIdAsync(int id, Salary salary);
    }
}
