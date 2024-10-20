namespace EHospital.Application.Dtos.Auth.User;

public class GetUserDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string SerialNumber { get; set; }
    public IEnumerable<string> UsersRoles { get; set; }

}
