using Employeess.Model;
using Employeess.Repository;
using Employeess.Repository.Common;
using Employeess.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeess.Service
{
    public class SalaryService : ISalaryService
    {
        ISalaryRepository salaryRepository;

        public SalaryService(ISalaryRepository salaryRepository)
        {
            this.salaryRepository = salaryRepository;
        }

        public async Task<List<Salary>> GetAllSalariesAsync()
        {
            List<Salary> salaries = await salaryRepository.GetAllSalariesAsync();
            return salaries;
        }

        public async Task<Salary> GetSalaryByIdAsync(int id)
        {
            Salary salary = await salaryRepository.GetSalaryByIdAsync(id); ;
            return salary;
        }
        public async Task<bool> AddNewSalaryAsync(Salary salary)
        {
            return await salaryRepository.AddNewSalaryAsync(salary);
        }

        public async Task<bool> DeleteSalaryByIdAsync(int id)
        {
            return await salaryRepository.DeleteSalaryByIdAsync(id);
        }

        public async Task<bool> UpdateSalaryByIdAsync(int id, Salary salary)
        {
            return await salaryRepository.UpdateSalaryByIdAsync(id, salary);
        }
    }
}
