using UserBlazorApp.API.Dts.Claims;

namespace UserBlazorApp.API.Dts.Role;
public class RoleRequest
{
    public string? Name { get; set; }
    public ICollection<RoleClaimRequest> RoleClaimsReq { get; set; } = new List<RoleClaimRequest>();
}