using Application.Services.Repositories;
using Company.Application.Features.Order.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.Rules
{
    public class OrderBusinessRules
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderBusinessRules(ICompanyRepository companyRepository, IOrderRepository orderRepository)
        {
            _companyRepository = companyRepository;
            _orderRepository = orderRepository;
        }

        public async Task IsActiveRule(int companyId)
        {
            var data = await _companyRepository.GetByFilter(x => x.Id == companyId);
            if (data.IsActive is false) throw new BusinessException(OrderConstants.OrderIsNotActive);
        }

        public async Task DatePermission(int companyId, int orderId)
        {
            var company = await _companyRepository.GetByFilter(x => x.Id == companyId);
            var order = await _orderRepository.GetByFilter(x => x.Id == orderId);
            
            if (order.OrderDate < company.OrderAllowStart && order.OrderDate > company.OrderPermitEnd)
                throw new BusinessException($"{order.OrderDate} zamanında sipariş alınamaz");
        }
    }
}
