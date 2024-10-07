using EHospital.Domain.Entities;

namespace EHospital.Application.Abstractions.Repositories;

public interface IHospitalReadRepository : IReadRepository<Hospital>
{
    Task<string> GetByNameAsync(string name);
}