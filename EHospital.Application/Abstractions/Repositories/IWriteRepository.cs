using EHospital.Domain.Common;

namespace EHospital.Application.Abstractions.Repositories;

public interface IWriteRepository<T> : IRepository<T> where T: BaseEntity, new()
{

    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveAsync(T entity);
}
