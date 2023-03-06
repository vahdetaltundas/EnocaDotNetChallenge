using Application.Features.Products.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetListProduct
{
    public class GetListProductQuery
    {
        public record Query : IRequest<List<ProductListDto>>;

        public class Handler : IRequestHandler<Query, List<ProductListDto>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public Handler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }
            public async Task<List<ProductListDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var data = await _productRepository.GetAllAsync();

                return _mapper.Map<List<ProductListDto>>(data);
            }
        }
    }
}
