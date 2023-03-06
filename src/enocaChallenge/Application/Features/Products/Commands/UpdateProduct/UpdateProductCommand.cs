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

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand:IRequest<UpdatedProductDto>
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdatedProductDto>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                Product? product = await _productRepository.GetAsync(b => b.Id == request.Id);
                //_languageBusinessRules.LanguageShouldExistWhenRequested(language);
                //await _languageBusinessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);
                product.CompanyId = request.CompanyId;
                product.ProductName = request.ProductName;
                product.UnitsInStock = request.UnitsInStock;
                product.UnitPrice = request.UnitPrice;

                Product updatedProduct = await _productRepository.UpdateAsync(product);
                UpdatedProductDto updatedProductDto = _mapper.Map<UpdatedProductDto>(updatedProduct);

                return updatedProductDto;

            }
        }
    }
}
