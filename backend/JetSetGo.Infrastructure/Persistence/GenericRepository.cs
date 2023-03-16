using JetSetGo.Application.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JetSetGo.Infrastructure.Persistence;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly DbSet<T>  DbSet;
    protected readonly DbContext dbContext;

    protected GenericRepository(JetSetGoContext dbContext)
    {
        DbSet = dbContext.Set<T>();
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<T> CreateAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public Task DeleteAsync(T entity)
    {
        DbSet.Remove(entity);
        return Task.CompletedTask;
    }
    public async Task DeleteByIdAsync(Guid guid)
    {
        var entity = await GetByIdAsync(guid);
        if (entity == null)
        {
            return;
        }
        DbSet.Remove(entity);
        
    }

    public Task UpdateAsync(T entity)
    {
        var entityUpdate = DbSet.Update(entity);
        return Task.FromResult(entityUpdate);
    }
}