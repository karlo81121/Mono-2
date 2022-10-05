using Employees.WebAPI.Models;
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

        static List<Employee> employees = new List<Employee>();

        // GET: api/Employee
        public HttpResponseMessage Get()
        {
            if(employees.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, employees);
        }

        // GET: api/Employee/5
        [HttpGet]
        public HttpResponseMessage FindEmployeeById(Guid id)
        {
            Employee employee = employees.FirstOrDefault(e => e.Id == id);
            if (employees.Count != 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, employee);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST: api/Employee
        public HttpResponseMessage Post([FromBody]Employee employee)
        {
            if (employee != null)
            {
                employees.Add(employee);
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully added!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        // PUT: api/Employee/5
        public HttpResponseMessage Put(Guid id, Employee employee)
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

        // DELETE: api/Employee/5
        public HttpResponseMessage Delete(Guid id)
        {
            Employee employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            employees.Remove(employee);
            return Request.CreateResponse(HttpStatusCode.OK, "Successfully deleted!");
        }
    }
}
