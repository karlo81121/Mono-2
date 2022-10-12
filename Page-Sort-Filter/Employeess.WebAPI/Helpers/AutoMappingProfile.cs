using AutoMapper;
using Employeess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employeess.WebAPI.Helpers
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Employee, EmployeeRest>().ReverseMap();
            CreateMap<EmployeeRest, Employee>().ReverseMap();
            CreateMap<Salary, SalaryRest>().ReverseMap();
            CreateMap<SalaryRest, Salary>().ReverseMap(); ;
        }
    }
}