using Employeess.Model;
using Employeess.Model.Common;
using Employeess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Employeess.WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeService employeeService = new EmployeeService();

        // GET: api/Employee
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllEmployeesAsync()
        {
            List<Employee> employees = await employeeService.GetAllEmployeesAsync();
            List<EmployeeRest> employeeRest = new List<EmployeeRest>();

            if (employees.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Employee not found!");
            }
            employeeRest = MapToREST(employees);
            return Request.CreateResponse(HttpStatusCode.OK, employeeRest);
        }

        // GET: api/Employee/5
        [HttpGet]
        public async Task<HttpResponseMessage> FindEmployeeByIdAsync(int id)
        {
            Employee employee = await employeeService.GetByIdAsync(id);
            List<EmployeeRest> employeeRest = new List<EmployeeRest>();

            if (employee == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Employee not found!");
            }
            else
            {
                employeeRest = MapToREST(new List<Employee> { employee });
                return Request.CreateResponse(HttpStatusCode.OK, employeeRest.First());
            }
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<HttpResponseMessage> AddNewEmployeeAsync([FromBody] EmployeeRest employeeRest)
        {
            List<Employee> employee = MapToDomain(new List<EmployeeRest> { employeeRest }); 
            if (await employeeService.AddNewEmployeeAsync(employee.First()))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully added!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Employee not found!");
            }
        }

        // PUT: api/Employee/5
        [HttpPut]
        public async Task<HttpResponseMessage> UpdateEmployeeByIdAsync([FromBody] int id, EmployeeRest employeeRest)
        {
            List<Employee> employees = MapToDomain(new List<EmployeeRest> { employeeRest });

            if (await employeeService.UpdateEmployeeByIdAsync(id, employees.First()))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Updated successfully!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Employee not found!");
            }
        }

        // DELETE: api/Employee/5
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteEmployeeByIdAsync(int id)
        {
            if (await employeeService.DeleteEmployeeByIdAsync(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully deleted!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, "Nothing to delete!");
            }
        }

        private List<Employee> MapToDomain(List<EmployeeRest> employeeRest)
        {
            List<Employee> employee = new List<Employee>();
            foreach(EmployeeRest eR in employeeRest)
            {
                Employee e = new Employee(eR.Id, eR.FirstName, eR.LastName, new DateTime(), "", new DateTime());
                employee.Add(e);
            }

            return employee;
        }

        private List<EmployeeRest> MapToREST(List<Employee> employee)
        {
            List<EmployeeRest> employeeRest = new List<EmployeeRest>();
            foreach (Employee emp in employee)
            {
                EmployeeRest eR = new EmployeeRest(emp.Id, emp.FirstName, emp.LastName);
                employeeRest.Add(eR);
            }

            return employeeRest;
        }
    }
}
