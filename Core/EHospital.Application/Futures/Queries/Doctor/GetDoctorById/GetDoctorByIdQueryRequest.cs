using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Doctor;
using MediatR;

namespace EHospital.Application.Futures.Queries.Doctor.GetDoctorById;

public class GetDoctorByIdQueryRequest : IRequest<GetDoctorByIdQueryResponse>
{
    public int DoctorId { get; set; }


}
public class GetDoctorByIdQueryResponse
{
    public DoctorReadDto DoctorReadDto { get; set; }
}

public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQueryRequest, GetDoctorByIdQueryResponse>
{
    private readonly IDoctorService _doctorService;

    public GetDoctorByIdQueryHandler(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    public async Task<GetDoctorByIdQueryResponse> Handle(GetDoctorByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var doctorReadDto = await _doctorService.GetDoctorByIdAsync(request.DoctorId);
        GetDoctorByIdQueryResponse response = new() { DoctorReadDto = doctorReadDto };

        return response;
    }
    /*
      IEnumerable<DoctorReadDto> doctorReadDtos = await _doctorService.GetAllDoctorsAsync();

        GetAllDoctorQueryResponse response = new() { DoctorReadDtos = doctorReadDtos };

        return response;

     */
}