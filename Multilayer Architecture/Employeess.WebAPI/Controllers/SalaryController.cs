﻿using Employeess.Model;
using Employeess.Model.Common;
using Employeess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Employeess.WebAPI.Controllers
{
    public class SalaryController : ApiController
    {
        SalaryService salaryService = new SalaryService();

        // GET: api/Salary
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllSalariesAsync()
        {
            List<Salary> salaries = new List<Salary>();
            salaries = await salaryService.GetAllSalariesAsync();
            List<SalaryRest> salariesRest = MapToREST(salaries);

            if (salaries.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Salary not found!");
            }
            return Request.CreateResponse(HttpStatusCode.OK, salariesRest);
        }

        // GET: api/Salary/5
        [HttpGet]
        public async Task<HttpResponseMessage> GetSalaryByIdAsync(int id)
        {
            Salary salary = await salaryService.GetSalaryByIdAsync(id);
            List<SalaryRest> salaryRest = MapToREST(new List<Salary> { salary });

            if (salary != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, salaryRest[0]);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Salary not found!");
            }
        }

        // POST: api/Salary
        [HttpPost]
        public async Task<HttpResponseMessage> AddNewSalaryAsync([FromBody] SalaryRest salaryRest)
        {
            List<Salary> salary = MapToDomain(new List<SalaryRest> { salaryRest });

            if (await salaryService.AddNewSalaryAsync(salary[0]) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully added!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Salary not found!");
            }
        }

        // PUT: api/Salary/5
        [HttpPut]
        public async Task<HttpResponseMessage> UpdateSalaryByIdAsync([FromBody] int id, Salary salary)
        {
            if (await salaryService.UpdateSalaryByIdAsync(id, salary) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Updated successfully!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Salary not found!");
            }
        }

        // DELETE: api/Salary/5
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteSalaryByIdAsync(int id)
        {
            if (await salaryService.DeleteSalaryByIdAsync(id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully deleted!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, "Nothing to delete!");
            }
        }

        private List<Salary> MapToDomain(List<SalaryRest> salaryRest)
        {
            List<Salary> salary = new List<Salary>();
            foreach (SalaryRest sR in salaryRest)
            {
                Salary s = new Salary(sR.Id, sR.Amount);
                salary.Add(s);
            }

            return salary;
        }

        private List<SalaryRest> MapToREST(List<Salary> salary)
        {
            List<SalaryRest> salaryRest = new List<SalaryRest>();
            foreach (Salary s in salary)
            {
                SalaryRest sR = new SalaryRest(s.Id, s.Amount);
                salaryRest.Add(sR);
            }

            return salaryRest;
        }
    }
}
