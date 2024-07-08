namespace UserBlazorApp.API.Dts.Claims;
public class RoleClaimRequest
{
    public int RoleId { get; set; }
    public string? ClaimType { get; set; }
    public string? ClaimValue { get; set; }
}
