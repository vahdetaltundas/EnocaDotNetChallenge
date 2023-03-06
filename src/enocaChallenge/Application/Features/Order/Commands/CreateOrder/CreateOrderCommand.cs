using Application.Features.Order.Dtos;
using Application.Features.Order.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Company.Application.Features.Order.Constants;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.Commands.CreateOrder
{
    public static class AddOrderCommand
    {
        public record Command(CreatedOrderDto AddOrderDto) : IRequest<string>;
        public class Handler : IRequestHandler<Command, string>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;


            private readonly OrderBusinessRules _orderBusinessRules;

            public Handler(IOrderRepository orderRepository, IMapper mapper, OrderBusinessRules orderBusinessRules)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
                _orderBusinessRules = orderBusinessRules;
            }

            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                var data = _mapper.Map<Domain.Entities.Order>(request.AddOrderDto);

                await _orderBusinessRules.IsActiveRule(data.CompanyId);

                await _orderBusinessRules.DatePermission(data.CompanyId, data.Id);

                await _orderRepository.AddAsync(data);

                return OrderConstants.OrderAdded;
            }
        }
    }
}