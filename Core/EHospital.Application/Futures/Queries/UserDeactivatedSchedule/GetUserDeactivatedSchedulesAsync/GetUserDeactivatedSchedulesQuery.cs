using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.DoctorSchedules;
using MediatR;

public class GetUserDeactivatedSchedulesQueryRequest : IRequest<GetUserDeactivatedSchedulesQueryResponse>
{
    public int UserId { get; set; }
}
public class GetUserDeactivatedSchedulesQueryResponse
{
    public List<UserDeactivatedScheduleReadDto> userDeactivatedScheduleReadDtos { get; set; }
}
public class GetUserDeactivatedSchedulesQueryHandler : IRequestHandler<GetUserDeactivatedSchedulesQueryRequest, GetUserDeactivatedSchedulesQueryResponse>
{
    private readonly IUserDeactivatedScheduleService _userDeactivatedScheduleService;

    public GetUserDeactivatedSchedulesQueryHandler(IUserDeactivatedScheduleService userDeactivatedScheduleService)
    {
        _userDeactivatedScheduleService = userDeactivatedScheduleService;
    }

    public async Task<GetUserDeactivatedSchedulesQueryResponse> Handle(GetUserDeactivatedSchedulesQueryRequest request, CancellationToken cancellationToken)
    {
        var deactivatedSchedules = await _userDeactivatedScheduleService.GetUserDeactivatedSchedulesAsync(request.UserId);

        return new GetUserDeactivatedSchedulesQueryResponse
        {
            userDeactivatedScheduleReadDtos = deactivatedSchedules
        };
    }
}

