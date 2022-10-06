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
        public HttpResponseMessage findAllEmployees()
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
        /*
        public HttpResponseMessage Put(Guid id, Employee.Model.Employee employee)
        {
            if (employee == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            int index = employees.FindIndex(e => e.Id == id);
            if (index == -1)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            employees.RemoveAt(index);
            employees.Add(employee);
            return Request.CreateResponse(HttpStatusCode.OK, "Successfully updated!");
        }
        */

        // DELETE: api/Employee/5
        public HttpResponseMessage Delete(int id)
        {
            if (employeeService.DeleteEmployeeById(id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, "Nothing to delete!");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Successfully deleted!");
        }
    }
}
