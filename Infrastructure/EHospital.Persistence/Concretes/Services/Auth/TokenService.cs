using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Auth;
using EHospital.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EHospital.Persistence.Concretes.Services.Auth;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<AppUser> _userManager;

    public TokenService(IConfiguration configuration, UserManager<AppUser> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
    }

    public async Task<TokenDto> CreateToken(AppUser user,int minute)
    {
        
        TokenDto token = new TokenDto();
        
        SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

        SigningCredentials signingCredentials = new(symmetricSecurityKey,SecurityAlgorithms.HmacSha256);

        var roles = await _userManager.GetRolesAsync(user);
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name,user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        token.Expiration = DateTime.UtcNow.AddMinutes(minute);

        JwtSecurityToken jwtSecurityToken = new(
                claims:claims,
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
            );
        JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        token.Token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
        return token;
    }
}
