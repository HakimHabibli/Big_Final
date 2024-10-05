using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Appointment;
using MediatR;

namespace EHospital.Application.Futures.Commands.Appointment.Create;

public class AppointmentCreateResponse
{
    public string StatusCode { get; set; }
}
public class AppointmentCreateRequest : IRequest<AppointmentCreateResponse>
{
    public AppointmentCreateDto AppointmentCreateDto { get; set; }
}
public class AppointmentCreateHandler : IRequestHandler<AppointmentCreateRequest, AppointmentCreateResponse>
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentCreateHandler(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    public async Task<AppointmentCreateResponse> Handle(AppointmentCreateRequest request, CancellationToken cancellationToken)
    {
        var response = new AppointmentCreateResponse();
        await _appointmentService.CreateAppointmentAsync(request.AppointmentCreateDto);
        response.StatusCode = "200";
        return response;
    }
}
