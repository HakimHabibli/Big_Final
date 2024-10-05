using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Patient;
using MediatR;

namespace EHospital.Application.Features.Queries.Patient.GetById
{
    public class PatientGetByIdQueryHandler : IRequestHandler<PatientGetByIdQueryRequest, PatientGetByIdQueryResponse>
    {
        private readonly IPatientService _patientService;

        public PatientGetByIdQueryHandler(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task<PatientGetByIdQueryResponse> Handle(PatientGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var patient = await _patientService.GetPatientByIdAsync(request.Id); // Xəstə ID ilə oxunur

            return new PatientGetByIdQueryResponse
            {
                PatientReadDto = patient,
                StatusCode = "200" // Uğurlu oxuma əməliyyatı
            };
        }
    }
}
public class PatientGetByIdQueryRequest : IRequest<PatientGetByIdQueryResponse>
{
    public int Id { get; set; } // Sorğu üçün xəstənin ID-si
}
public class PatientGetByIdQueryResponse
{
    public PatientReadDto PatientReadDto { get; set; } // Geri qaytarılan xəstə məlumatları
    public string StatusCode { get; set; } // Sorğunun nəticəsi üçün status kodu
}