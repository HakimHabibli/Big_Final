using EHospital.Application.Abstractions.Services;
using MediatR;

namespace EHospital.Application.Futures.Commands.Doctor.Create;

public class DoctorCreateHandler : IRequestHandler<DoctorCreateRequest, DoctorCreateResponse>
{
    private readonly IDoctorService _doctorService;

    public DoctorCreateHandler(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    public async Task<DoctorCreateResponse> Handle(DoctorCreateRequest request, CancellationToken cancellationToken)
    {
        DoctorCreateResponse response = new DoctorCreateResponse();

        //await _doctorService.CreateDoctorAsync(request.DoctorCreateDto);
        response.StatusCode = "201";
        //Create olunmasa responsun status kodunu deyis 
        return response;

    }
}
