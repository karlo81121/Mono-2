using AutoMapper;
using Employeess.Common;
using Employeess.Model;
using Employeess.Model.Common;
using Employeess.Service;
using Employeess.Service.Common;
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
        ISalaryService salaryService;
        IMapper mapper;

        public SalaryController(ISalaryService salaryService, IMapper mapper)
        {
            this.salaryService = salaryService;
            this.mapper = mapper;
        }

        // GET: api/Salary
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllSalariesAsync(int pageNumber = 1, int pageSize = 5, string sortBy = "ID", string orderBy = "ASC", int amount=10000)
        {
            Paging paging = new Paging(pageNumber, pageSize);
            Sorting sorting = new Sorting(sortBy, orderBy);
            SalaryFiltering filtering = new SalaryFiltering(amount);

            List<Salary> salaries = await salaryService.GetAllSalariesAsync(paging, sorting, filtering);
            List<SalaryRest> salariesRest;

            if (salaries.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Salary not found!");
            }
            salariesRest = mapper.Map<List<SalaryRest>>(salaries);
            return Request.CreateResponse(HttpStatusCode.OK, salariesRest);
        }

        // GET: api/Salary/5
        [HttpGet]
        public async Task<HttpResponseMessage> GetSalaryByIdAsync(int id)
        {
            Salary salary = await salaryService.GetSalaryByIdAsync(id);
            SalaryRest salaryRest;

            if (salary == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Salary not found!");
            }
            else
            {
                salaryRest = mapper.Map<SalaryRest>(salary);
                return Request.CreateResponse(HttpStatusCode.OK, salaryRest);
            }
        }

        // POST: api/Salary
        [HttpPost]
        public async Task<HttpResponseMessage> AddNewSalaryAsync([FromBody] SalaryRest salaryRest)
        {
            Salary salary = mapper.Map<Salary>(salaryRest);

            if (await salaryService.AddNewSalaryAsync(salary))
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
        public async Task<HttpResponseMessage> UpdateSalaryByIdAsync(int id,[FromBody] SalaryRest salaryRest)
        {
            Salary salary = mapper.Map<Salary>(salaryRest);

            if (await salaryService.UpdateSalaryByIdAsync(id, salary))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Updated successfully!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Salary not found!");
            }
        }

        // DELETE: api/Salary/5
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteSalaryByIdAsync(int id)
        {
            if (await salaryService.DeleteSalaryByIdAsync(id))
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
