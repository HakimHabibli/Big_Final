using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Patient;
using MediatR;

namespace EHospital.Application.Futures.Queries.Doctor.GetAllPatientsByDoctorId;

public class GetAllPatientsByDoctorIdQueryRequest : IRequest<GetAllPatientsByDoctorIdQueryResponse>
{
    public int DoctorId { get; set; }

    public GetAllPatientsByDoctorIdQueryRequest(int doctorId)
    {
        DoctorId = doctorId;
    }
}

public class GetAllPatientsByDoctorIdQueryResponse
{
    public IEnumerable<PatientDto> PatientDtos { get; set; }
}


public class GetAllPatientsByDoctorIdQueryHandler : IRequestHandler<GetAllPatientsByDoctorIdQueryRequest, GetAllPatientsByDoctorIdQueryResponse>
{
    private readonly IDoctorService _doctorService;

    public GetAllPatientsByDoctorIdQueryHandler(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    public async Task<GetAllPatientsByDoctorIdQueryResponse> Handle(GetAllPatientsByDoctorIdQueryRequest request, CancellationToken cancellationToken)
    {
        var patientDtos = await _doctorService.GetAllPatientsAsync(request.DoctorId);
        return new GetAllPatientsByDoctorIdQueryResponse { PatientDtos = patientDtos };
    }
}
