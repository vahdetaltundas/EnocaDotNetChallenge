using Application.Features.Companies.Commands.CreateCompany;
using Application.Features.Companies.Commands.DeleteCompany;
using Application.Features.Companies.Commands.UpdateCompany;
using Application.Features.Companies.Dtos;
using Application.Features.Companies.Queries.GetListCompany;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Company, CreatedCompanyDto>().ReverseMap();
            CreateMap<Company, CreateCompanyCommand>().ReverseMap();

            CreateMap<Company, DeletedCompanyDto>().ReverseMap();
            CreateMap<Company, DeleteCompanyCommand>().ReverseMap();

            CreateMap<Company, UpdateIsActiveCommand>().ReverseMap();
            CreateMap<UpdatedIsActiveDto, Company>().ReverseMap();

            CreateMap<Company, UpdateOrderDateCommand>().ReverseMap();
            CreateMap<UpdatedOrderDateDto, Company>().ReverseMap();

            CreateMap<Company, CompanyListDto>().ReverseMap();
            CreateMap<Company, GetListCompanyQuery>().ReverseMap();
        }
    }
}
