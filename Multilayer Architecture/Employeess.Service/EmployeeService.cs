using Employeess.Model;
using Employeess.Repository;
using Employeess.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeess.Service
{
    public class EmployeeService : IEmployeeService
    {
        EmployeeRepository employeeRepository = new EmployeeRepository();
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            List<Employee> employees = new List<Employee>();
            employees = await employeeRepository.GetAllEmployeesAsync();
            return employees;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            Employee employee = new Employee();
            employee = await employeeRepository.GetByIdAsync(id);
            return employee;
        }
        public async Task<bool> AddNewEmployeeAsync(Employee employee)
        {
            if (await employeeRepository.AddNewEmployeeAsync(employee) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteEmployeeByIdAsync(int id)
        {
            if (await employeeRepository.DeleteEmployeeByIdAsync(id) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateEmployeeByIdAsync(int id, Employee employee)
        {
            if (await employeeRepository.UpdateEmployeeByIdAsync(id, employee) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
