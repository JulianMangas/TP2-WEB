using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TP2_WEB.Models;
namespace TP2_WEB.Data;

public class CrudService<T> where T : class, IEntidad
{
    private readonly IDbContextFactory<AppDbContext> _factory;
    public CrudService(IDbContextFactory<AppDbContext> factory) => _factory = factory;

    public async Task<List<T>> GetAllAsync(params Expression<Func<T, object?>>[] includes)
    {
        await using var db = await _factory.CreateDbContextAsync();
        IQueryable<T> query = db.Set<T>().AsNoTracking();
        foreach (var inc in includes) query = query.Include(inc);
        return await query.OrderBy(e => e.Id).ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task CreateAsync(T entity)
    {
        await using var db = await _factory.CreateDbContextAsync();
        db.Set<T>().Add(entity);
        await db.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        await using var db = await _factory.CreateDbContextAsync();
        db.Set<T>().Update(entity);
        await db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = await db.Set<T>().FindAsync(id);
        if (entity is null) return;
        db.Set<T>().Remove(entity);
        await db.SaveChangesAsync();
    }
}