using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Appointment;
using MediatR;

namespace EHospital.Application.Futures.Commands.Appointment.Delete;

public class AppointmentDeleteResponse
{
    public string StatusCode { get; set; }
}

public class AppointmentDeleteRequest : IRequest<AppointmentDeleteResponse>
{
    public AppointmentDeleteDto AppointmentDeleteDto { get; set; }
}
public class AppointmentDeleteHandler : IRequestHandler<AppointmentDeleteRequest, AppointmentDeleteResponse>
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentDeleteHandler(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    public async Task<AppointmentDeleteResponse> Handle(AppointmentDeleteRequest request, CancellationToken cancellationToken)
    {
        var response = new AppointmentDeleteResponse();
        await _appointmentService.DeleteAppointmentAsync(request.AppointmentDeleteDto);
        response.StatusCode = "204";
        return response;
    }
}




