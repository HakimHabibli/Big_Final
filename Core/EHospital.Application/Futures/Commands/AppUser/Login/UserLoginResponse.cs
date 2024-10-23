using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Auth;
using EHospital.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EHospital.Application.Futures.Commands.AppUser.Login;

public class UserLoginResponse 
{
    public Task<TokenDto> Token { get; set; }
    public string Message { get; set; }
    public string UserName { get; set; }
}
public class UserLoginRequest : IRequest<UserLoginResponse> 
{
    public string UserNameOrEmail { get; set; }
    public string Password { get; set; }
}
public class UserLoginHandler : IRequestHandler<UserLoginRequest, UserLoginResponse>
{
    private readonly UserManager<Domain.Entities.Auth.AppUser> _userManager;
    private readonly SignInManager<Domain.Entities.Auth.AppUser> _signInManager;
    private readonly ITokenService _tokenService;

    public UserLoginHandler(UserManager<Domain.Entities.Auth.AppUser> userManager, SignInManager<Domain.Entities.Auth.AppUser> signInManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<UserLoginResponse> Handle(UserLoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);
        if (user == null) 
        {
            user = await _userManager.FindByNameAsync(request.UserNameOrEmail);
        }
        if (user == null) throw new NotFoundUserException();

        SignInResult result =await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (result.Succeeded) 
        {
            Task<TokenDto> token = _tokenService.CreateToken(user,60);
            return new UserLoginResponse
            {
                Token = token,
                Message = "User Successfully Login",
                UserName = user.FullName
            };
        }
        throw new UnAuthorizedException(message: "User Name or Password incorrect :)");
    }
}