using Application.Features.Companies.Commands.CreateCompany;
using Application.Features.Companies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Queries.GetListCompany
{
    public class GetListCompanyQuery
    {
        public record Query : IRequest<List<CompanyListDto>>;

        public class Handler : IRequestHandler<Query, List<CompanyListDto>>
        {

            private readonly ICompanyRepository _companyRepository;
            private readonly IMapper _mapper;

            public Handler(ICompanyRepository companyRepository, IMapper mapper)
            {
                _companyRepository = companyRepository;
                _mapper = mapper;
            }
            public async Task<List<CompanyListDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var data = await _companyRepository.GetAllAsync();

                return _mapper.Map<List<CompanyListDto>>(data);
            }
        }
    }
}
