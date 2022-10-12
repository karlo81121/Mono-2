using Employeess.Common;
using Employeess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeess.Repository.Common
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployeesAsync(Paging paging, Sorting sorting, EmployeeFiltering filtering);
        Task<Employee> GetByIdAsync(int id);
        Task<bool> AddNewEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeByIdAsync(int id);
        Task<bool> UpdateEmployeeByIdAsync(int id, Employee employee);
    }
}
