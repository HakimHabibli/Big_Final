using EHospital.Domain.Common;

namespace EHospital.Application.Abstractions.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity, new()
{
    IQueryable<T> GetAll(bool asNoTracking = false, params string[] includes);
    Task<T> GetByIdAsync(int id, bool asNoTracking = false, params string[] includes);
}
