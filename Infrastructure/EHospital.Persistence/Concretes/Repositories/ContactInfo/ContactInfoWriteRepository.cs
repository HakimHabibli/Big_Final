using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;

namespace EHospital.Application.Concretes.Repositories;

public class ContactInfoWriteRepository : WriteRepository<ContactInfo>, IContactInfoWriteRepository
{
    public ContactInfoWriteRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
