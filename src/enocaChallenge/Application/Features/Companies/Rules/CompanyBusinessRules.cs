using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Rules
{
    public class CompanyBusinessRules  
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyBusinessRules(ICompanyRepository companyRepository)
        {
            _companyRepository= companyRepository;
        }

        public async Task CopmanyUpdateIdCheck(int id)
        {
            //Id veri tabanında yoksa program hata verir zaten sadece denemek için yazdım
            var result= await _companyRepository.GetAllAsync(p=>p.Id==id);
            if (result!=null) throw new BusinessException("Bu id de firma yok");
        }
    }
}
