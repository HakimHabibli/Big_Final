using EHospital.Application.Dtos.Auth.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Application.Futures.Queries.AppUser.GetSerialNumberUserQuery;

public class GetUserBySerialNumberQueryRequest : IRequest<GetUserBySerialNumberQueryResponse>
{
    public string SerialNumber { get; set; }
}


public class GetUserBySerialNumberQueryResponse
{
    public GetUserDto User { get; set; }
}
public class GetUserBySerialNumberQueryHandler : IRequestHandler<GetUserBySerialNumberQueryRequest, GetUserBySerialNumberQueryResponse>
{
    private readonly UserManager<Domain.Entities.Auth.AppUser> _userManager;

    public GetUserBySerialNumberQueryHandler(UserManager<Domain.Entities.Auth.AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<GetUserBySerialNumberQueryResponse> Handle(GetUserBySerialNumberQueryRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.SerialNumber == request.SerialNumber);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        var roles = await _userManager.GetRolesAsync(user);

        var userDto = new GetUserDto
        {
            FullName = user.FullName,
            Email = user.Email,
            SerialNumber = user.SerialNumber,
            UsersRoles = roles.ToList()
        };

        return new GetUserBySerialNumberQueryResponse { User = userDto };
    }
}
