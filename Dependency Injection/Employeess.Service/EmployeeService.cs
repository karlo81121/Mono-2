using Employeess.Common;
using Employeess.Model;
using Employeess.Repository;
using Employeess.Repository.Common;
using Employeess.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Employeess.Service
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepositroy)
        {
            this.employeeRepository = employeeRepositroy;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync([FromUri] Paging paging)
        {
            List<Employee> employees = await employeeRepository.GetAllEmployeesAsync(paging);
            return employees;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            Employee employee = await employeeRepository.GetByIdAsync(id);
            return employee;
        }
        public async Task<bool> AddNewEmployeeAsync(Employee employee)
        {
            return await employeeRepository.AddNewEmployeeAsync(employee);
        }

        public async Task<bool> DeleteEmployeeByIdAsync(int id)
        {
            return await employeeRepository.DeleteEmployeeByIdAsync(id);
        }

        public async Task<bool> UpdateEmployeeByIdAsync(int id, Employee employee)
        {
            return await employeeRepository.UpdateEmployeeByIdAsync(id, employee);
        }
    }
}
