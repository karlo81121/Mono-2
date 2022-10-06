using Employee.Model;
using Employees.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Service
{
    public class EmployeesService
    {
        EmployeesRepository employeeRepositroy = new EmployeesRepository();
        public List<Employee.Model.Employee> GetAllEmployees()
        {
            List<Employee.Model.Employee> employees = new List<Employee.Model.Employee>();
            employees = employeeRepositroy.GetAllEmployees();
            return employees;
        }

        public Employee.Model.Employee GetById(int id)
        {
            Employee.Model.Employee employee = new Employee.Model.Employee();
            employee = employeeRepositroy.GetById(id);
            return employee;
        }
        public bool AddNewEmployee(Employee.Model.Employee employee)
        {
            if(employeeRepositroy.AddNewEmployee(employee) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteEmployeeById(int id)
        {
            if(employeeRepositroy.DeleteEmployeeById(id) == true)
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
