using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ProductRepository : EfRepositoryBase<Product, BaseDbContext>, IProductRepository
    {
        public ProductRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
