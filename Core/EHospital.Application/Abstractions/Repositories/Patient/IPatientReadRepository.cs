﻿public interface IPatientReadRepository : IReadRepository<Patient>
{

    Task<IEnumerable<Patient>> GetPatientsByHospitalIdAsync(int hospitalId);

    Task<Patient> GetBySerialNumberAsync(string serialNumber, bool asNoTracking = false,params string[] includes);

}
