using EHospital.Application.Abstractions.Repositories;
using EHospital.Domain.Common;
using EHospital.Persistence.DAL;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Concretes.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
{
    private readonly AppDbContext _appDbContext;

    public ReadRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public DbSet<T> Table => _appDbContext.Set<T>();
    public IQueryable<T> GetAll(bool asNoTracking = false, params string[] includes)
    {
        var queryable = Table.AsQueryable();
        if (asNoTracking)
        {
            queryable = queryable.AsNoTracking();
        }
        foreach (var include in includes)
        {
            queryable = queryable.Include(include);
        }
        return queryable;
    }


    public async Task<T> GetByIdAsync(int id, bool asNoTracking = false, params string[] includes)
    {

        var queryable = Table.AsQueryable();


        if (asNoTracking)
        {
            queryable = queryable.AsNoTracking();
        }


        foreach (string include in includes)
        {
            queryable = queryable.Include(include);
        }


        var entity = await queryable.FirstOrDefaultAsync(e => e.Id == id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"Entity with ID {id} not found.");
        }
        return entity;
    }
}
