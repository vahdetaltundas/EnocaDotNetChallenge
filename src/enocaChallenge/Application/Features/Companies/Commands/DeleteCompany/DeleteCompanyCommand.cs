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

namespace Application.Features.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommand : IRequest<DeletedCompanyDto>
    {
        public int Id { get; set; }


        public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, DeletedCompanyDto>
        {
            private readonly IMapper _mapper;
            private readonly ICompanyRepository _companyRepository;

            public DeleteCompanyCommandHandler(IMapper mapper, ICompanyRepository companyRepository)
            {
                _mapper = mapper;
                _companyRepository = companyRepository;
                
            }

            public async Task<DeletedCompanyDto> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
            {
                Company mappedCompany = _mapper.Map<Company>(request);
                Company deletedCompany = await _companyRepository.DeleteAsync(mappedCompany);
                DeletedCompanyDto deletedCompanyDto = _mapper.Map<DeletedCompanyDto>(deletedCompany);
                return deletedCompanyDto;
            }
        }
    }
}
