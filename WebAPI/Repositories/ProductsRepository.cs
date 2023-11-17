using WebAPI.Models;

namespace WebAPI.Repositories;

public class ProductsRepository : EfCoreRepository<Product, ProductsDbContext>
{
    public ProductsRepository(ProductsDbContext context): base(context)
    {
        
    }
}