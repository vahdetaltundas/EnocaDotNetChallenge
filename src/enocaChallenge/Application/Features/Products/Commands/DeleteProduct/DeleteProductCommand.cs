using Application.Features.Products.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand:IRequest<DeletedProductDto>
    {
        public int Id { get; set; }

        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeletedProductDto>
        {
            private readonly IMapper _mapper;
            private readonly IProductRepository _productRepository;

            public DeleteProductCommandHandler(IMapper mapper, IProductRepository productRepository)
            {
                _mapper = mapper;
                _productRepository = productRepository;

            }

            public async Task<DeletedProductDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                Product mappedProduct = _mapper.Map<Product>(request);
                Product deletedProduct = await _productRepository.DeleteAsync(mappedProduct);
                DeletedProductDto deletedProductDto = _mapper.Map<DeletedProductDto>(deletedProduct);
                return deletedProductDto;
            }
        }
    }
}
