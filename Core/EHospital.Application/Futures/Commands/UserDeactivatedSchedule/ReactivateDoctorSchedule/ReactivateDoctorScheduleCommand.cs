using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.DoctorSchedules;
using MediatR;

public class ReactivateDoctorScheduleCommand : IRequest<CommandResponse>
{
    public UserScheduleReactivateDto ReactivateDto { get; set; }

 
}
public class CommandResponse
{
    public string Message { get; set; }
    public string StatusCode { get; set; }
}
public class ReactivateDoctorScheduleCommandHandler : IRequestHandler<ReactivateDoctorScheduleCommand, CommandResponse>
{
    private readonly IUserDeactivatedScheduleService _userDeactivatedScheduleService;

    public ReactivateDoctorScheduleCommandHandler(IUserDeactivatedScheduleService userDeactivatedScheduleService)
    {
        _userDeactivatedScheduleService = userDeactivatedScheduleService;
    }

    public async Task<CommandResponse> Handle(ReactivateDoctorScheduleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            bool result = await _userDeactivatedScheduleService.ReactivateDoctorScheduleAsync(request.ReactivateDto);

            return new CommandResponse
            {
                Message = "Doctor schedule reactivated successfully.",
                StatusCode = "200"
            };
        }
        catch (KeyNotFoundException ex)
        {
            return new CommandResponse
            {
             
                Message = ex.Message,
                StatusCode = "404"
            };
        }
        catch (Exception ex)
        {
            return new CommandResponse
            {
               
                Message = "An error occurred while reactivating the doctor schedule.",
                StatusCode = "500"
            };
        }
    }
}

