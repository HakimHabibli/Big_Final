namespace EHospital.Application.Abstractions.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity, new()
{
    Task<IQueryable<T>> GetAllAsync(bool asNoTracking = false, params string[] includes);
    Task<T> GetByIdAsync(int id, params string[] includes);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false, params string[] includes);
}