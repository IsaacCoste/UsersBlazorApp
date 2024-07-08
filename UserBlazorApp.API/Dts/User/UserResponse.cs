using UserBlazorApp.API.Dts.Role;

namespace UserBlazorApp.API.Dts.User;
public class UserResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTimeOffset? LockoutEnd { get; set; }
    public ICollection<RoleResponse> Role {  get; set; } = new List<RoleResponse>();
}