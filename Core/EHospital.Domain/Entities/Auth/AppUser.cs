using Microsoft.AspNetCore.Identity;

namespace EHospital.Domain.Entities.Auth;

public class AppUser : IdentityUser<string>
{
    public string FullName { get; set; }
}
