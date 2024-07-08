using UserBlazorApp.API.Dts.Claims;

namespace UserBlazorApp.API.Dts.Role;
public class RoleResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<RoleClaimResponse> RoleClaims { get; set; } = new List<RoleClaimResponse>();
}
