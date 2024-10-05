using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Patient;
using MediatR;

namespace EHospital.Application.Features.Queries.Patient.GetAll;

public class PatientGetAllQueryHandler : IRequestHandler<PatientGetAllQueryRequest, PatientGetAllQueryResponse>
{
    private readonly IPatientService _patientService;

    public PatientGetAllQueryHandler(IPatientService patientService)
    {
        _patientService = patientService;
    }

    public async Task<PatientGetAllQueryResponse> Handle(PatientGetAllQueryRequest request, CancellationToken cancellationToken)
    {
        var patients = await _patientService.GetAllPatients();

        return new PatientGetAllQueryResponse
        {
            Patients = patients,
            StatusCode = "200"
        };
    }
}
public class PatientGetAllQueryRequest : IRequest<PatientGetAllQueryResponse>
{
}
public class PatientGetAllQueryResponse
{
    public List<PatientReadDto> Patients { get; set; }
    public string StatusCode { get; set; }
}