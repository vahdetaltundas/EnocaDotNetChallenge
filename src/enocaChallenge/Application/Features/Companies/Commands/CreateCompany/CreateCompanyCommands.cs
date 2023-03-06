using Application.Features.Companies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand:IRequest<CreatedCompanyDto>
    {
        public string CompanyName { get; set; }
        public bool IsActive { get; set; }
        public DateTime OrderAllowStart { get; set; }
        public DateTime OrderPermitEnd { get; set; }
        public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CreatedCompanyDto>
        {
            private readonly ICompanyRepository _companyRepository;
            private readonly IMapper _mapper;

            public CreateCompanyHandler(ICompanyRepository companyRepository, IMapper mapper)
            {
                _companyRepository = companyRepository;
                _mapper = mapper;
            }

            public async Task<CreatedCompanyDto> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
            {
                Company mapperCompany = _mapper.Map<Company>(request);
                Company createdCompany = await _companyRepository.AddAsync(mapperCompany);
                CreatedCompanyDto createdCompanyDto = _mapper.Map<CreatedCompanyDto>(createdCompany);

                return createdCompanyDto;
            }
        }
    }
}
