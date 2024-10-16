
using EHospital.Application.Exceptions;
using EHospital.Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EHospital.Application.Futures.Commands.AppUser.Create;

public class UserCreateRequest:IRequest<UserCreateResponse>
{
    public string NameSurname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
}

public class UserCreateResponse
{
    public bool IsSucceeded { get; set; }
    public string Messages { get; set; }
}
public class UserCreateHandler : IRequestHandler<UserCreateRequest, UserCreateResponse>
{
    readonly UserManager<Domain.Entities.Auth.AppUser> _userManager;

    public UserCreateHandler(UserManager<Domain.Entities.Auth.AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UserCreateResponse> Handle(UserCreateRequest request, CancellationToken cancellationToken)
    {
         var result = await _userManager.CreateAsync(new()
        {
             Id = Guid.NewGuid().ToString(),
            UserName = request.Username,
            Email = request.Email,
            FullName =  request.NameSurname,

        },request.Password);
        if (result.Succeeded) return new()
        {
            IsSucceeded = true,
            Messages = "User Create Succesfully"
        };
        else
        {
            throw new UserCreateFailedException();
        }
    }
}