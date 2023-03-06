using Application.Features.Companies.Dtos;
using Application.Features.Companies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Commands.UpdateCompany
{
    public class UpdateIsActiveCommand : IRequest<UpdatedIsActiveDto>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        
        public class UpdateIsActiveCommandHandler : IRequestHandler<UpdateIsActiveCommand, UpdatedIsActiveDto>
        {
            private readonly ICompanyRepository _companyRepository;
            private readonly IMapper _mapper;
            private readonly CompanyBusinessRules _companyBusinessRules;
            public UpdateIsActiveCommandHandler(ICompanyRepository companyRepository, IMapper mapper,CompanyBusinessRules companyBusinessRules)
            {
                _companyRepository = companyRepository;
                _mapper = mapper;
                _companyBusinessRules = companyBusinessRules;
            }

            public async Task<UpdatedIsActiveDto> Handle(UpdateIsActiveCommand request, CancellationToken cancellationToken)
            {
                Company? company = await _companyRepository.GetAsync(b => b.Id == request.Id);
                // İş Kuralları
                company.IsActive = request.IsActive;

                Company updatedCompany = await _companyRepository.UpdateAsync(company);
                UpdatedIsActiveDto updatedIsActiveDto = _mapper.Map<UpdatedIsActiveDto>(updatedCompany);
                
                return updatedIsActiveDto;

            }
        }
    }
}
