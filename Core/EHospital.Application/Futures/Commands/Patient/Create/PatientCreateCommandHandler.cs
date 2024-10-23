using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Patient;
using MediatR;

namespace EHospital.Application.Features.Commands.Patient.Create;

public class PatientCreateCommandHandler : IRequestHandler<PatientCreateCommandRequest, PatientCreateCommandResponse>
{
    private readonly IPatientService _patientService;

    public PatientCreateCommandHandler(IPatientService patientService)
    {
        _patientService = patientService;
    }

    public async Task<PatientCreateCommandResponse> Handle(PatientCreateCommandRequest request, CancellationToken cancellationToken)
    {
        PatientCreateCommandResponse response = new PatientCreateCommandResponse();

        await _patientService.CreatePatientAsync(request.PatientCreateDto);

        response.StatusCode = "201"; 

        return response;
    }
}
public class PatientCreateCommandRequest : IRequest<PatientCreateCommandResponse>
{
    public PatientDto PatientCreateDto { get; set; } 
}
public class PatientCreateCommandResponse
{
    public string StatusCode { get; set; } 
}
