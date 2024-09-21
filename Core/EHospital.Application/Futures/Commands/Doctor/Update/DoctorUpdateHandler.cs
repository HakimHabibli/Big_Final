using EHospital.Application.Abstractions.Services;
using MediatR;

namespace EHospital.Application.Futures.Commands.Doctor.Update;

public class DoctorUpdateHandler : IRequestHandler<DoctorUpdateRequest, DoctorUpdateResponse>
{
    private readonly IDoctorService _doctorService;

    public DoctorUpdateHandler(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    public async Task<DoctorUpdateResponse> Handle(DoctorUpdateRequest request, CancellationToken cancellationToken)
    {
        DoctorUpdateResponse response = new DoctorUpdateResponse();
        await _doctorService.UpdateDoctorAsync(request.DoctorUpdateDto);
        response.StatusCode = "204";

        return response;
    }


}
