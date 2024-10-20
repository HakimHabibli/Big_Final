using EHospital.Application.Dtos.Auth.User;
using EHospital.Application.Futures.Queries.Appointment.GetAllAppointment;
using EHospital.Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Application.Futures.Queries.AppUser.GetAllUserQuery;

public class GetAllUserQueryRequest : IRequest<GetAllUserQueryResponse>
{ }
public class GetAllUserQueryResponse
{
    public IEnumerable<GetUserDto> Users { get; set; }

}
public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, GetAllUserQueryResponse>
{
    private readonly UserManager<Domain.Entities.Auth.AppUser> _userManager;

    public GetAllUserQueryHandler(UserManager<Domain.Entities.Auth.AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<GetAllUserQueryResponse> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
    {
        var users = await _userManager.Users.ToListAsync();

        var userDtos = new List<GetUserDto>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);  

            userDtos.Add(new GetUserDto
            {
                FullName = user.FullName,
                Email = user.Email,
                SerialNumber = user.SerialNumber,
                UsersRoles = roles.ToList() 
            });
        }

        return new GetAllUserQueryResponse { Users = userDtos };
    }
}

