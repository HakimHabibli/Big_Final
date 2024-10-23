

namespace EHospital.Application.Abstractions.Services;

public interface ITokenService
{
    Task<TokenDto> CreateToken(AppUser user,int minute);
}
    