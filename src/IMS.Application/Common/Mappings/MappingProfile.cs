using AutoMapper;
using IMS.Application.Companies.Commands.AddEditCompany;
using IMS.Application.Companies.DTOs;
using IMS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, AddEditCompanyCommand>();
        }
    }
}
