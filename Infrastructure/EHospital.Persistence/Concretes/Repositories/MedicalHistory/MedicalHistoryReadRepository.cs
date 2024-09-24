﻿using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;

namespace EHospital.Application.Concretes.Repositories;

public class MedicalHistoryReadRepository : ReadRepository<MedicalHistory>, IMedicalHistoryReadRepository
{
    public MedicalHistoryReadRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}