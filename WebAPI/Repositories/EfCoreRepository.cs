using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Repositories;

public abstract class EfCoreRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : class, IEntity
    where TContext : DbContext
{
    protected readonly TContext context;

    protected EfCoreRepository(TContext context)
    {
        this.context = context;
    }
    public virtual async Task<TEntity> Add(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity> Delete(Guid id)
    {
        var entity = await context.Set<TEntity>().FindAsync(id);
        if (entity == null)
        {
            return entity;
        }

        context.Set<TEntity>().Remove(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public virtual async Task<TEntity> Get(Guid id)
    {
        return await context.Set<TEntity>().FirstOrDefaultAsync(p => p.Id == id);
    }

    public virtual async Task<List<TEntity>> GetAll()
    {
        return await context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<TEntity> Update(TEntity entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return entity;
    }

}