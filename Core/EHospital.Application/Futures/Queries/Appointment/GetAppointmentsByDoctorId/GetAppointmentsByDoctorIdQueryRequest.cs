using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Appointment;
using MediatR;

namespace EHospital.Application.Futures.Queries.Appointment.GetAppointmentsByDoctorId;

public class GetAppointmentsByDoctorIdQueryRequest : IRequest<GetAppointmentsByDoctorIdQueryResponse>
{
    public int DoctorId { get; set; }
}

public class GetAppointmentsByDoctorIdQueryResponse
{
    public IEnumerable<AppointmentReadDto> Appointments { get; set; }
}

public class GetAppointmentsByDoctorIdQueryHandler : IRequestHandler<GetAppointmentsByDoctorIdQueryRequest, GetAppointmentsByDoctorIdQueryResponse>
{
    private readonly IAppointmentService _appointmentService;

    public GetAppointmentsByDoctorIdQueryHandler(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    public async Task<GetAppointmentsByDoctorIdQueryResponse> Handle(GetAppointmentsByDoctorIdQueryRequest request, CancellationToken cancellationToken)
    {
        var appointments = await _appointmentService.GetAppointmentsByDoctorAsync(request.DoctorId);
        return new GetAppointmentsByDoctorIdQueryResponse
        {
            Appointments = appointments
        };
    }
}