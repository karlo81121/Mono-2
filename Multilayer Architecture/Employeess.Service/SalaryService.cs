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
    public class SalaryService : ISalaryService
    {
        SalaryRepository salaryRepository = new SalaryRepository();
        public async Task<List<Salary>> GetAllSalariesAsync()
        {
            List<Salary> salaries = new List<Salary>();
            salaries = await salaryRepository.GetAllSalariesAsync();
            return salaries;
        }

        public async Task<Salary> GetSalaryByIdAsync(int id)
        {
            Salary salary = new Salary();
            salary = await salaryRepository.GetSalaryByIdAsync(id);
            return salary;
        }
        public async Task<bool> AddNewSalaryAsync(Salary salary)
        {
            if (await salaryRepository.AddNewSalaryAsync(salary) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteSalaryByIdAsync(int id)
        {
            if (await salaryRepository.DeleteSalaryByIdAsync(id) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateSalaryByIdAsync(int id, Salary salary)
        {
            if (await salaryRepository.UpdateSalaryByIdAsync(id, salary) == true)
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
