using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Repositories;

public class SalesRepository : EfCoreRepository<Sale, ProductsDbContext>
{
    private ProductsRepository ProductsRepository { get; }
    public SalesRepository(ProductsDbContext context, ProductsRepository productsRepository) : base(context)
    {
        ProductsRepository = productsRepository;
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

    public override async Task<Sale?> Get(Guid id)
    {
        await context.Products.LoadAsync();
        return await base.Get(id);
    }

    public override async Task<Sale?> Add(Sale entity)
    {
        var product = await ProductsRepository.Get(entity.ProductId);
        if (product == null)
        {
            return null;
        }
        entity.Product = product;
        return await base.Add(entity);
    }

    public override async Task<Sale> Update(Sale entity)
    {
        await context.Products.LoadAsync();
        return await base.Update(entity);
    }
    
    public async Task<List<Sale>> GetByDate(DateTime date)
    {
        await context.Products.LoadAsync();
        return await context.Sales.Where(s =>
            s.SellDateTime.Date == date.Date).ToListAsync();
    }
}