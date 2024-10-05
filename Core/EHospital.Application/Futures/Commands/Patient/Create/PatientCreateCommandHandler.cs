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

        await _patientService.CreatePatientAsync(request.PatientCreateDto); // Patient yaratma əmri

        response.StatusCode = "201"; // Statusun uğurla yaradıldığını bildirir

        return response;
    }
}
public class PatientCreateCommandRequest : IRequest<PatientCreateCommandResponse>
{
    public PatientDto PatientCreateDto { get; set; } // Dto burada saxlanılır
}
public class PatientCreateCommandResponse
{
    public string StatusCode { get; set; } // Status kodu üçün cavab
}
