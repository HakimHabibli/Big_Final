using EHospital.Application.Abstractions.Repositories;
using EHospital.Domain.Common;
using EHospital.Persistence.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EHospital.Concretes.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
{
    protected readonly AppDbContext _appDbContext;

    public ReadRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;

    }
    public DbSet<T> Table => _appDbContext.Set<T>();

    public async Task<IQueryable<T>> GetAllAsync(bool asNoTracking = false, params string[] includes)
    {
        IQueryable<T> query = Table;

        if (asNoTracking)
            query = query.AsNoTracking();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await Task.FromResult(query);
    }

    public async Task<T> GetByIdAsync(int id, params string[] includes)
    {
        IQueryable<T> query = Table;



        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false, params string[] includes)
    {
        IQueryable<T> query = Table.Where(predicate);

        if (asNoTracking)
            query = query.AsNoTracking();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.ToListAsync();
    }

}
