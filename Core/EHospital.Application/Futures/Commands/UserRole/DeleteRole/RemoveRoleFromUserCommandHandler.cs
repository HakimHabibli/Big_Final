using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EHospital.Application.Futures.Commands.UserRole.DeleteRole;
public class RemoveRoleFromUserCommandRequest : IRequest<RemoveRoleFromUserCommandResponse>
{
    public string UserId { get; set; }
    public string Role { get; set; }
}

public class RemoveRoleFromUserCommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
}

public class RemoveRoleFromUserCommandHandler : IRequestHandler<RemoveRoleFromUserCommandRequest, RemoveRoleFromUserCommandResponse>
{
    private readonly UserManager<Domain.Entities.Auth.AppUser> _userManager;

    public RemoveRoleFromUserCommandHandler(UserManager<Domain.Entities.Auth.AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<RemoveRoleFromUserCommandResponse> Handle(RemoveRoleFromUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null)
        {
            return new RemoveRoleFromUserCommandResponse
            {
                Success = false,
                Message = "İstifadəçi tapılmadı."
            };
        }

        var result = await _userManager.RemoveFromRoleAsync(user, request.Role);
        if (result.Succeeded)
        {
            return new RemoveRoleFromUserCommandResponse
            {
                Success = true,
                Message = "Rol istifadəçidən uğurla çıxarıldı."
            };
        }
        else
        {
            return new RemoveRoleFromUserCommandResponse
            {
                Success = false,
                Message = string.Join(", ", result.Errors.Select(e => e.Description))
            };
        }
    }
}
