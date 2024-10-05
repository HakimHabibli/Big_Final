using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Appointment;
using MediatR;

namespace EHospital.Application.Futures.Queries.Appointment.GetAppointmentsByPatientId;

public class GetAppointmentsByPatientIdQueryRequest : IRequest<GetAppointmentsByPatientIdQueryResponse>
{
    public int PatientId { get; set; }
}

public class GetAppointmentsByPatientIdQueryResponse
{
    public IEnumerable<AppointmentReadDto> Appointments { get; set; }
}

public class GetAppointmentsByPatientIdQueryHandler : IRequestHandler<GetAppointmentsByPatientIdQueryRequest, GetAppointmentsByPatientIdQueryResponse>
{
    private readonly IAppointmentService _appointmentService;

    public GetAppointmentsByPatientIdQueryHandler(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    public async Task<GetAppointmentsByPatientIdQueryResponse> Handle(GetAppointmentsByPatientIdQueryRequest request, CancellationToken cancellationToken)
    {
        var appointments = await _appointmentService.GetAppointmentsByPatientAsync(request.PatientId);
        return new GetAppointmentsByPatientIdQueryResponse
        {
            Appointments = appointments
        };
    }
}
