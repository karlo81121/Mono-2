using Employeess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeess.Service.Common
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<bool> AddNewEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeByIdAsync(int id);
        Task<bool> UpdateEmployeeByIdAsync(int id, Employee employee);
    }
}
