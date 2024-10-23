using EHospital.Application.Exceptions;
using EHospital.Domain.Entities.Auth;
using EHospital.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Application.Futures.Commands.AppUser.Create;

public class UserCreateRequest:IRequest<UserCreateResponse>
{
    public string NameSurname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
    public string SerialNumber { get; set; }
}

public class UserCreateResponse
{
    public bool IsSucceeded { get; set; }
    public string Messages { get; set; }
}

public class UserCreateHandler : IRequestHandler<UserCreateRequest, UserCreateResponse>
{
    private readonly UserManager<Domain.Entities.Auth.AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;

    public UserCreateHandler(UserManager<Domain.Entities.Auth.AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<UserCreateResponse> Handle(UserCreateRequest request, CancellationToken cancellationToken)
    {
        var existingUser = await _userManager.Users.FirstOrDefaultAsync(u => u.SerialNumber == request.SerialNumber);
        if (existingUser != null)
        {
            throw new BusinessRuleException($"User with SerialNumber '{request.SerialNumber}' already exists.");
        }

        var existingUserByEmail = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
        if (existingUserByEmail != null)
        {
            throw new BusinessRuleException($"User with Email '{request.Email}' already exists.");
        }
        var user = new Domain.Entities.Auth.AppUser
        {
            UserName = request.Username,
            Email = request.Email,
            FullName = request.NameSurname,
            SerialNumber = request.SerialNumber
        };

        var result = await _userManager.CreateAsync(user, request.Password);



        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user: user, role:RolesEnum.User.ToString());

            return new()
            {
                IsSucceeded = true,
                Messages = "User Create Succesfully"
            };
        }
        else
        {
            var errorMessages = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new UserCreateFailedException($"User creation failed: {errorMessages}");
        }
    }
}