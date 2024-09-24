using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Doctor;
using MediatR;

namespace EHospital.Application.Futures.Queries.Doctor.GetAllDoctors;

public class GetAllDoctorQueryResponse
{
    public IEnumerable<DoctorReadDto> DoctorReadDtos { get; set; }
}
public class GetAllDoctorQueryHandler : IRequestHandler<GetAllDoctorQueryRequest, GetAllDoctorQueryResponse>
{
    private readonly IDoctorService _doctorService;

    public GetAllDoctorQueryHandler(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    public async Task<GetAllDoctorQueryResponse> Handle(GetAllDoctorQueryRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<DoctorReadDto> doctorReadDtos = await _doctorService.GetAllDoctorsAsync();

        GetAllDoctorQueryResponse response = new() { DoctorReadDtos = doctorReadDtos };

        return response;

    }
}
