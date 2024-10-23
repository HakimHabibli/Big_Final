namespace EHospital.Application.Abstractions.Repositories;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity, new()
{

    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task SaveChangesAsync();
}
