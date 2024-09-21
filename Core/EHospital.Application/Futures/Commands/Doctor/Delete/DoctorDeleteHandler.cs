using EHospital.Application.Abstractions.Services;
using MediatR;

namespace EHospital.Application.Futures.Commands.Doctor.Delete;

public class DoctorDeleteHandler : IRequestHandler<DoctorDeleteRequest, DoctorDeleteResponse>
{
    private readonly IDoctorService _doctorService;

    public DoctorDeleteHandler(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    public async Task<DoctorDeleteResponse> Handle(DoctorDeleteRequest request, CancellationToken cancellationToken)
    {
        DoctorDeleteResponse response = new DoctorDeleteResponse();
        await _doctorService.DeleteDoctorAsync(request.DoctorDeleteDto);
        response.StatusCode = "204";

        return response;
    }
}
