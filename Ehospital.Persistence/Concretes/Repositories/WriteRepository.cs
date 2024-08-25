using EHospital.Application.Abstractions.Repositories;
using EHospital.Domain.Common;
using EHospital.Persistence.DAL;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Concretes.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()

{
    private readonly AppDbContext _appDbContext;

    public WriteRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public DbSet<T> Table => _appDbContext.Set<T>();

    public Task CreateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }
}
