using EHospital.Application.Dtos.Entites.Hospital;

namespace EHospital.Application.Futures.Queries.Hospital.GetAllHospitals;

public class GetAllHospitalQueryResponse
{
    public IEnumerable<HospitalReadDto> HospitalReadDtos { get; set; }

}
