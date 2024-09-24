﻿
using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;

namespace EHospital.Application.Concretes.Repositories;

public class AllergyReadRepository : ReadRepository<Allergy>, IAllergyReadRepository
{
    public AllergyReadRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}