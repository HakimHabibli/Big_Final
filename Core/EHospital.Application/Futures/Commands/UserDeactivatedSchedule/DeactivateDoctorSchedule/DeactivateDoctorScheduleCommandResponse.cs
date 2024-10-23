using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.DoctorSchedules;
using EHospital.Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Text;

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
    private readonly UserManager<AppUser> _userManager;
    private readonly IUserDeactivatedScheduleService _userDeactivatedScheduleService;
    private readonly IDoctorSchedulesService _doctorSchedulesService;
    private readonly HttpClient _httpClient;

    public DeactivateDoctorScheduleCommandHandler(
         UserManager<AppUser> userManager,
        IUserDeactivatedScheduleService userDeactivatedScheduleService,
        IDoctorSchedulesService doctorSchedulesService,
        HttpClient httpClient)
    {
        _userManager = userManager;
        _userDeactivatedScheduleService = userDeactivatedScheduleService;
        _doctorSchedulesService = doctorSchedulesService;
        _httpClient = httpClient;
    }

    public async Task<DeactivateDoctorScheduleCommandResponse> Handle(DeactivateDoctorScheduleCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            bool result = await _userDeactivatedScheduleService.DeactivateDoctorScheduleAsync(request.UserScheduleDeactivateDto);

            if (result)
            {
                var user = await _userManager.FindByIdAsync(request.UserScheduleDeactivateDto.UserId.ToString());

                if (user != null)
                {
                    var userEmail = await _userManager.GetEmailAsync(user);

                    var schedule = await _doctorSchedulesService.GetDoctorSchedulesByIdAsync(request.UserScheduleDeactivateDto.ScheduleId);

                    if (schedule != null)
                    {
                        var notification = new
                        {
                            Type = "ScheduleDeactivation",
                            Recipient = userEmail,
                            Message = $"Your schedule with Dr. {schedule.DoctorName} on {schedule.Date.ToShortDateString()} from {schedule.StartTime} to {schedule.EndTime} has been deactivated."
                        };

                        var content = new StringContent(JsonConvert.SerializeObject(notification), Encoding.UTF8, "application/json");

                        var response = await _httpClient.PostAsync("http://localhost:5004/api/Notification", content);

                        if (!response.IsSuccessStatusCode)
                        {
                            throw new Exception("Failed to send notification.");
                        }
                    }
                    else
                    {
                        throw new KeyNotFoundException("Schedule not found.");
                    }
                }
                else
                {
                    throw new KeyNotFoundException("User not found.");
                }
            }

            return new DeactivateDoctorScheduleCommandResponse
            {
                Message = "Doctor schedule deactivated and notification sent successfully.",
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
        catch (Exception ex)
        {
            throw new Exception($"An error occurred: {ex.Message}", ex);
        }
    }
}

#region MyRegion

//public class DeactivateDoctorScheduleCommandHandler : IRequestHandler<DeactivateDoctorScheduleCommandRequest, DeactivateDoctorScheduleCommandResponse>
//{
//    private readonly IUserDeactivatedScheduleService _userDeactivatedScheduleService;

//    public DeactivateDoctorScheduleCommandHandler(IUserDeactivatedScheduleService userDeactivatedScheduleService)
//    {
//        _userDeactivatedScheduleService = userDeactivatedScheduleService;
//    }

//    public async Task<DeactivateDoctorScheduleCommandResponse> Handle(DeactivateDoctorScheduleCommandRequest request, CancellationToken cancellationToken)
//    {
//        try
//        {
//            bool result = await _userDeactivatedScheduleService.DeactivateDoctorScheduleAsync(request.UserScheduleDeactivateDto);

//            return new DeactivateDoctorScheduleCommandResponse
//            {
//                Message = "Doctor schedule deactivated successfully.",
//                StatusCode = "200" 
//            };
//        }
//        catch (KeyNotFoundException ex)
//        {
//            return new DeactivateDoctorScheduleCommandResponse
//            {
//                Message = ex.Message,
//                StatusCode = "404" 
//            };
//        }
//        catch (Exception)
//        {
//            throw new Exception();
//        }
//    }
//}
#endregion
