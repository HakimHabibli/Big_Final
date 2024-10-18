using Microsoft.AspNetCore.Identity;

namespace EHospital.Domain.Entities.Auth;

public class AppUser : IdentityUser<int>
{
    public string FullName { get; set; }
    public string SerialNumber { get; set; }
}
