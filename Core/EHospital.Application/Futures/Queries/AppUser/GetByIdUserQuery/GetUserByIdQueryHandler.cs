using EHospital.Application.Dtos.Auth.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EHospital.Application.Futures.Queries.AppUser.GetByIdUserQuery;
public class GetUserByIdQueryRequest : IRequest<GetUserByIdQueryResponse>
{
    public int UserId { get; set; }
}

public class GetUserByIdQueryResponse
{
    public GetUserDto User { get; set; }
}

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
{
    private readonly UserManager<Domain.Entities.Auth.AppUser> _userManager;

    public GetUserByIdQueryHandler(UserManager<Domain.Entities.Auth.AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId.ToString());
        if (user == null)
        {
            throw new Exception("İstifadəçi tapılmadı.");
        }

        List<string> roles = (await _userManager.GetRolesAsync(user)).ToList();

        var userDto = new GetUserDto
        {
            FullName = user.FullName,
            Email = user.Email,
            SerialNumber = user.SerialNumber,
            UsersRoles = roles
        };


        return new GetUserByIdQueryResponse
        {
            User = userDto
        };
    }
}


