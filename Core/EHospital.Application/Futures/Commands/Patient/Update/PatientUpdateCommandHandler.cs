using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Patient;
using MediatR;

namespace EHospital.Application.Features.Commands.Patient.Create;

public class PatientUpdateCommandHandler : IRequestHandler<PatientUpdateCommandRequest, PatientUpdateCommandResponse>
{
    private readonly IPatientService _patientService;

    public PatientUpdateCommandHandler(IPatientService patientService)
    {
        _patientService = patientService;
    }

    public async Task<PatientUpdateCommandResponse> Handle(PatientUpdateCommandRequest request, CancellationToken cancellationToken)
    {
        PatientUpdateCommandResponse response = new PatientUpdateCommandResponse();

        await _patientService.UpdatePatientAsync(request.PatientUpdateDto);

        response.StatusCode = "200";

        return response;
    }
}
public class PatientUpdateCommandRequest : IRequest<PatientUpdateCommandResponse>
{
    public PatientDto PatientUpdateDto { get; set; }
}
public class PatientUpdateCommandResponse
{
    public string StatusCode { get; set; }
}
