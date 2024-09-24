﻿
using EHospital.Application.Abstractions.Repositories;
using EHospital.Domain.Entities;

public interface IPatientReadRepository : IReadRepository<Patient>
{

    Task<IEnumerable<Patient>> GetPatientsByHospitalIdAsync(int hospitalId);

}