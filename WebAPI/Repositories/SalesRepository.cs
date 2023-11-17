using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Repositories;

public class SalesRepository : EfCoreRepository<Sale, ProductsDbContext>
{
    public SalesRepository(ProductsDbContext context) : base(context)
    {
        
    }

    public override async Task<List<Sale>> GetAll()
    {
        await context.Products.LoadAsync();
        return await base.GetAll();
    }

    public override async Task<Sale> Delete(Guid id)
    {
        await context.Products.LoadAsync();
        return await base.Delete(id);
    }

    public override async Task<Sale> Get(Guid id)
    {
        await context.Products.LoadAsync();
        return await base.Get(id);
    }

    public override async Task<Sale> Update(Sale entity)
    {
        await context.Products.LoadAsync();
        return await base.Update(entity);
    }
}