namespace UserBlazorApp.API.Dts.User;
public class UserRequest
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTimeOffset? LockoutEnd { get; set; }
}