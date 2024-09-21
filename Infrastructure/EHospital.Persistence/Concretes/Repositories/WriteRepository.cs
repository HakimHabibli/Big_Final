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

    public async Task CreateAsync(T entity)
    {
        await Table.AddAsync(entity);
        await SaveChangesAsync();
    }
    public async Task DeleteAsync(T entity)
    {
        if (entity.Id <= 0) // Müvəqqəti dəyəri yoxlamaq
        {
            throw new InvalidOperationException("Invalid entity ID.");
        }
        Table.Remove(entity);
        await SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }


    public async Task UpdateAsync(T entity)
    {
        if (entity.Id == null)
        {
            throw new NullReferenceException("Null Referance");
        }
        Table.Update(entity);
        await SaveChangesAsync();
    }
}
