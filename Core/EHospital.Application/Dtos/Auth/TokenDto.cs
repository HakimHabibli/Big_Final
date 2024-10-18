namespace EHospital.Application.Dtos.Auth;

public class TokenDto
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }    
}
