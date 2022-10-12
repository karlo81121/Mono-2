using Employeess.Common;
using Employeess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeess.Repository.Common
{
    public interface ISalaryRepository
    {
        Task<List<Salary>> GetAllSalariesAsync(Paging paging, Sorting sorting, SalaryFiltering filtering);
        Task<Salary> GetSalaryByIdAsync(int id);
        Task<bool> AddNewSalaryAsync(Salary salary);
        Task<bool> DeleteSalaryByIdAsync(int id);
        Task<bool> UpdateSalaryByIdAsync(int id, Salary salary);
    }
}
