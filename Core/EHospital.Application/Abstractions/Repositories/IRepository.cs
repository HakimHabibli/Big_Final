using EHospital.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Application.Abstractions.Repositories;

public interface IRepository<T> where T : BaseEntity, new()
{
    DbSet<T> Table { get; }

}
