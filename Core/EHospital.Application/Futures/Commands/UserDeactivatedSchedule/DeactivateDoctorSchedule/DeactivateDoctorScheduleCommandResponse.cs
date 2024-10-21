using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.DoctorSchedules;
using EHospital.Domain.Entities;
using MediatR;

public class DeactivateDoctorScheduleCommandResponse
{
    public string StatusCode { get; set; }
    public string Message { get; set; }
}
public class DeactivateDoctorScheduleCommandRequest : IRequest<DeactivateDoctorScheduleCommandResponse>
{
    public UserScheduleDeactivateDto UserScheduleDeactivateDto { get; set; }
}

public class DeactivateDoctorScheduleCommandHandler : IRequestHandler<DeactivateDoctorScheduleCommandRequest, DeactivateDoctorScheduleCommandResponse>
{
    private readonly IUserDeactivatedScheduleService _userDeactivatedScheduleService;

    public DeactivateDoctorScheduleCommandHandler(IUserDeactivatedScheduleService userDeactivatedScheduleService)
    {
        _userDeactivatedScheduleService = userDeactivatedScheduleService;
    }

    public async Task<DeactivateDoctorScheduleCommandResponse> Handle(DeactivateDoctorScheduleCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            bool result = await _userDeactivatedScheduleService.DeactivateDoctorScheduleAsync(request.UserScheduleDeactivateDto);

            return new DeactivateDoctorScheduleCommandResponse
            {
                Message = "Doctor schedule deactivated successfully.",
                StatusCode = "200" 
            };
        }
        catch (KeyNotFoundException ex)
        {
            return new DeactivateDoctorScheduleCommandResponse
            {
                Message = ex.Message,
                StatusCode = "404" 
            };
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
}
