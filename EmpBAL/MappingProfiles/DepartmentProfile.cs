using AutoMapper;
using EmpBAL.Dtos;
using EmpDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpBAL.MappingProfiles
{
    public class DepartmentProfile :Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>()
                .ForMember(d => d.DepartmentName, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.DepartmentDescription, opt =>opt.MapFrom(src => src.Description))
                .ReverseMap();

           CreateMap<DepartmentDto, AddDepartmentDto>().ReverseMap();

            CreateMap<DepartmentDto, UpdateDepartmentDto>().ReverseMap();
        }
    }
}

