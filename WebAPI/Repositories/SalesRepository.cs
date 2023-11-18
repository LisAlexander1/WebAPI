using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Repositories;

public class SalesRepository : EfCoreRepository<Sale, ProductsDbContext>
{
    private ProductsRepository ProductsRepository { get; }
    private ILogger<SalesRepository> Logger { get; }
    public SalesRepository(ProductsDbContext context, ProductsRepository productsRepository, ILogger<SalesRepository> logger) : base(context)
    {
        ProductsRepository = productsRepository;
        Logger = logger;
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
        Logger.LogDebug("Get Sales ----------------------------------------");
        return await base.Get(id);
    }

    public override async Task<Sale?> Add(Sale entity)
    {
        var product = await ProductsRepository.Get(entity.ProductId);
        Logger.LogDebug("Add Sales");
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