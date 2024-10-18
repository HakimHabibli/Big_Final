using EHospital.Domain.Entities.Auth;
using EHospital.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace EHospital.Persistence.Seed;

public class RoleSeeder
{
    private readonly RoleManager<AppRole> _roleManager;

    public RoleSeeder(RoleManager<AppRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task SeedRoles()
    {
        foreach (var role in Enum.GetValues(typeof(RolesEnum)).Cast<RolesEnum>())
        {
            if (!await _roleManager.RoleExistsAsync(role.ToString()))
            {

                await _roleManager.CreateAsync(new AppRole { Name = role.ToString() });
            }
        }
    }
}
