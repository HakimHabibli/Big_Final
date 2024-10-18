using Microsoft.AspNetCore.Identity;

namespace EHospital.Domain.Entities.Auth;

public class AppRole : IdentityRole<int> 
{
    public AppRole() : base() { }

    public AppRole(string roleName) : base(roleName) { }
}
