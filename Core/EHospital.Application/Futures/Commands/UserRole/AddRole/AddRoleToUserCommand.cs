
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EHospital.Application.Futures.Commands.UserRole.AddRole;
public class AddRoleToUserCommandRequest : IRequest<AddRoleToUserCommandResponse>
{
    public int UserId { get; set; }
    public string NewRole { get; set; }
}

public class AddRoleToUserCommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
}

public class AddRoleToUserCommandHandler : IRequestHandler<AddRoleToUserCommandRequest, AddRoleToUserCommandResponse>
{
    private readonly UserManager<Domain.Entities.Auth.AppUser> _userManager;

    public AddRoleToUserCommandHandler(UserManager<Domain.Entities.Auth.AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<AddRoleToUserCommandResponse> Handle(AddRoleToUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId.ToString());
        if (user == null)
        {
            return new AddRoleToUserCommandResponse
            {
                Success = false,
                Message = "İstifadəçi tapılmadı."
            };
        }

        var result = await _userManager.AddToRoleAsync(user, request.NewRole);
        if (result.Succeeded)
        {
            return new AddRoleToUserCommandResponse
            {
                Success = true,
                Message = "Rol istifadəçiyə uğurla əlavə olundu."
            };
        }
        else
        {
            return new AddRoleToUserCommandResponse
            {
                Success = false,
                Message = string.Join(", ", result.Errors.Select(e => e.Description))
            };
        }
    }
}