
using EHospital.Application.Abstractions.Services;

namespace EHospital.Application.Futures.Queries.Appointment.GetAppointmentById;

public class GetAppointmentByIdQueryRequest : IRequest<GetAppointmentByIdQueryResponse>
{
    public int AppointmentId { get; set; }
}
public class GetAppointmentByIdQueryResponse 
{
    public AppointmentReadDto appointmentReadDto { get; set; }
}
public class GetAppointmentByIdQueryHandle : IRequestHandler<GetAppointmentByIdQueryRequest, GetAppointmentByIdQueryResponse>
{
    private readonly IAppointmentService _appointmentService;

    public GetAppointmentByIdQueryHandle(IAppointmentService appointmentService)
    {
        this._appointmentService = appointmentService;
    }

    public async Task<GetAppointmentByIdQueryResponse> Handle(GetAppointmentByIdQueryRequest request, CancellationToken cancellationToken)
    {
       var appointment =  await _appointmentService.GetByIdAppointmentAsync(request.AppointmentId);
        return new()
        {
            appointmentReadDto = appointment
        };
    }
}
