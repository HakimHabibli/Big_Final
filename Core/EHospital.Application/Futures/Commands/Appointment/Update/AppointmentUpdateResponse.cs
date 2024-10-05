using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Appointment;
using MediatR;

namespace EHospital.Application.Futures.Commands.Appointment.Update;

public class AppointmentUpdateResponse
{
    public string StatusCode { get; set; }
}

public class AppointmentUpdateRequest : IRequest<AppointmentUpdateResponse>
{
    public AppointmentUpdateDto AppointmentUpdateDto { get; set; }

}

public class AppointmentUpdateHandler : IRequestHandler<AppointmentUpdateRequest, AppointmentUpdateResponse>
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentUpdateHandler(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    public async Task<AppointmentUpdateResponse> Handle(AppointmentUpdateRequest request, CancellationToken cancellationToken)
    {
        var response = new AppointmentUpdateResponse();
        await _appointmentService.UpdateAppointmentAsync(request.AppointmentUpdateDto);
        response.StatusCode = "200";
        return response;
    }
}