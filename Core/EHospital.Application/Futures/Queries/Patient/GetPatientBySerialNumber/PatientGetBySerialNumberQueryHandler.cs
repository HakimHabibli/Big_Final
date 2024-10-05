using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Patient;
using MediatR;

namespace EHospital.Application.Features.Queries.Patient.GetBySerialNumber;

public class PatientGetBySerialNumberQueryHandler : IRequestHandler<PatientGetBySerialNumberQueryRequest, PatientGetBySerialNumberQueryResponse>
{
    private readonly IPatientService _patientService;

    public PatientGetBySerialNumberQueryHandler(IPatientService patientService)
    {
        _patientService = patientService;
    }

    public async Task<PatientGetBySerialNumberQueryResponse> Handle(PatientGetBySerialNumberQueryRequest request, CancellationToken cancellationToken)
    {
        var patient = await _patientService.GetPatientBySerialNumberAsync(request.SerialNumber); // Xəstə serial nömrəsi ilə oxunur

        return new PatientGetBySerialNumberQueryResponse
        {
            PatientReadDto = patient,
            StatusCode = "200" // Uğurlu oxuma əməliyyatı
        };
    }
}
public class PatientGetBySerialNumberQueryRequest : IRequest<PatientGetBySerialNumberQueryResponse>
{
    public string SerialNumber { get; set; } // Sorğu üçün xəstənin serial nömrəsi
}
public class PatientGetBySerialNumberQueryResponse
{
    public PatientReadDto PatientReadDto { get; set; } // Geri qaytarılan xəstə məlumatları
    public string StatusCode { get; set; } // Sorğunun nəticəsi üçün status kodu
}