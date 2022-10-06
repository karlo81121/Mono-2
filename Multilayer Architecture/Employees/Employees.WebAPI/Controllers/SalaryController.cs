using Salary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Employees.WebAPI.Controllers
{
    public class SalaryController : ApiController
    {
        /*
        static List<Salary.Model.Salary> salaries = new List<Salary.Model.Salary>();

        // GET: api/Employee
        [HttpGet]
        public HttpResponseMessage findAllSalaries()
        {
            if (salaries.Count == 0)
            {
                return null;
            }
            return Request.CreateResponse(HttpStatusCode.OK, salaries);
        }

        // GET: api/Employee/5
        [HttpGet]
        public HttpResponseMessage FindEmployeeById(Guid id)
        {
            Salary.Model.Salary salary = salaries.FirstOrDefault(e => e.Id == id);
            if (salaries.Count != 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, salary);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST: api/Employee
        public HttpResponseMessage Post([FromBody] Salary.Model.Salary salary)
        {
            if (salary != null)
            {
                salaries.Add(salary);
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully added!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        // PUT: api/Employee/5
        public HttpResponseMessage Put(Guid id, Salary.Model.Salary salary)
        {
            if (salary == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            int index = salaries.FindIndex(e => e.Id == id);
            if (index == -1)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            salaries.RemoveAt(index);
            salaries.Add(salary);
            return Request.CreateResponse(HttpStatusCode.OK, "Successfully updated!");
        }

        // DELETE: api/Employee/5
        public HttpResponseMessage Delete(Guid id)
        {
            Salary salary = salaries.FirstOrDefault(e => e.Id == id);
            if (salary == null)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            salaries.Remove(salary);
            return Request.CreateResponse(HttpStatusCode.OK, "Successfully deleted!");
        }
        */
    }
}
