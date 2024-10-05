using EHospital.Application.Abstractions.Services;
using MediatR;

namespace EHospital.Application.Futures.Commands.Patient.Delete;

public class PatientDeleteCommandHandler : IRequestHandler<PatientDeleteCommandRequest, PatientDeleteCommandResponse>
{
    private readonly IPatientService _patientService;

    public PatientDeleteCommandHandler(IPatientService patientService)
    {
        _patientService = patientService;
    }

    public async Task<PatientDeleteCommandResponse> Handle(PatientDeleteCommandRequest request, CancellationToken cancellationToken)
    {
        PatientDeleteCommandResponse response = new PatientDeleteCommandResponse();

        await _patientService.DeletePatientAsync(request.Id); // Xəstənin silinməsi əmri

        response.StatusCode = "200"; // Uğurlu silinmə üçün status kodu

        return response;
    }
}
public class PatientDeleteCommandRequest : IRequest<PatientDeleteCommandResponse>
{
    public int Id { get; set; } // Silinəcək xəstənin ID-si
}
public class PatientDeleteCommandResponse
{
    public string StatusCode { get; set; } // Silinmə əməliyyatının nəticəsi
}