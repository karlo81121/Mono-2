using Employee.Model;
using Employees.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Employees.WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeesService employeeService = new EmployeesService();

        // GET: api/Employee
        [HttpGet]
        public HttpResponseMessage GetAllEmployees()
        {
            List<Employee.Model.Employee> employees = new List<Employee.Model.Employee>();
            employees = employeeService.GetAllEmployees();

            if(employees.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Employee not found!");
            }
            return Request.CreateResponse(HttpStatusCode.OK, employees);
        }

        // GET: api/Employee/5
        [HttpGet]
        public HttpResponseMessage FindEmployeeById(int id)
        {
            Employee.Model.Employee employee = employeeService.GetById(id);
            if (employee != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, employee);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Employee not found!");
            }
        }

        // POST: api/Employee
        public HttpResponseMessage Post([FromBody]Employee.Model.Employee employee)
        {
            if (employeeService.AddNewEmployee(employee) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully added!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Employee not found!");
            }
        }

        // PUT: api/Employee/5
        public HttpResponseMessage UpdateEmployeeById(int id, Employee.Model.Employee employee)
        {
            if(employeeService.UpdateEmployeeById(id, employee) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Updated successfully!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Employee not found!");
            }
        }

        // DELETE: api/Employee/5
        public HttpResponseMessage DeleteEmployeeById(int id)
        {
            if (employeeService.DeleteEmployeeById(id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully deleted!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, "Nothing to delete!");
            }
        }
    }
}
