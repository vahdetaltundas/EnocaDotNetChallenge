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

namespace Application.Features.Companies.Commands.UpdateCompany
{
    public class UpdateOrderDateCommand:IRequest<UpdatedOrderDateDto>
    {
        public int Id { get; set; }
        public DateTime OrderAllowStart { get; set; }
        public DateTime OrderPermitEnd { get; set; }

        public class UpdateOrderDateCommandHandler : IRequestHandler<UpdateOrderDateCommand, UpdatedOrderDateDto>
        {
            private readonly ICompanyRepository _companyRepository;
            private readonly IMapper _mapper;

            public UpdateOrderDateCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
            {
                _companyRepository = companyRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedOrderDateDto> Handle(UpdateOrderDateCommand request, CancellationToken cancellationToken)
            {
                Company? company = await _companyRepository.GetAsync(b => b.Id == request.Id);
                //_languageBusinessRules.LanguageShouldExistWhenRequested(language);
                //await _languageBusinessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);
                company.OrderAllowStart = request.OrderAllowStart;
                company.OrderPermitEnd = request.OrderPermitEnd;

                Company updatedCompany = await _companyRepository.UpdateAsync(company);
                UpdatedOrderDateDto updatedOrderDateDto = _mapper.Map<UpdatedOrderDateDto>(updatedCompany);

                return updatedOrderDateDto;

            }
        }
    }
}
