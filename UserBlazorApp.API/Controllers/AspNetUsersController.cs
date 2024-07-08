using Microsoft.AspNetCore.Mvc;
using UserBlazorApp.API.Dts.Claims;
using UserBlazorApp.API.Dts.Role;
using UserBlazorApp.API.Dts.User;
using UsersBlazorApp.Data.Interfacez;
using UsersBlazorApp.Data.Models;

namespace UserBlazorApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AspNetUsersController(IAPIService<AspNetUsers> userService) : ControllerBase
{

    // GET: api/AspNetUsers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AspNetUsers>>> GetAspNetUsers()
    {
        var usuarios = await userService.GetAll();

        var userRespose = usuarios.Select(u => new UserResponse
        {
            Id = u.Id,
            Name = u.UserName,
            Email = u.Email,
            PasswordHash = u.PasswordHash,
            PhoneNumber = u.PhoneNumber,
            LockoutEnd = u.LockoutEnd,
            Role = u.Role.Select(r => new RoleResponse
            {
                Id = r.Id,
                Name = r.Name,
                RoleClaims = r.AspNetRoleClaims.Select(c => new RoleClaimResponse
                {
                    Id = c.Id,
                    RoleId = c.RoleId,
                    ClaimType = c.ClaimType,
                    ClaimValue = c.ClaimValue
                }).ToList()
            }).ToList()
        }).ToList();
        return Ok(userRespose);
    }

    // GET: api/AspNetUsers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> GetAspNetUsers(int id)
    {
        var user = await userService.Get(id);
        if (user == null)
        {
            return NotFound();
        }
        var userResponse = new UserResponse
        {
            Id = user.Id,
            Name = user.UserName,
            Email = user.Email,
            PasswordHash = user.PasswordHash,
            PhoneNumber = user.PhoneNumber,
            LockoutEnd = user.LockoutEnd,
            Role = user.Role.Select(r => new RoleResponse
            {
                Id = r.Id,
                Name = r.Name
            }).ToList()
        };
        return userResponse;
    }

    // PUT: api/AspNetUsers/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAspNetUsers(int id, UserRequest userRequest)
    {
        var user = await userService.Get(id);
        if (user == null)
        {
            return NotFound();
        }
        user.UserName = userRequest.Name;
        user.Email = userRequest.Email;
        user.PasswordHash = userRequest.PasswordHash;
        user.PhoneNumber = userRequest.PhoneNumber;
        user.LockoutEnd = userRequest.LockoutEnd;
        var modificar = await userService.Update(user);
        if (modificar == false)
            return NotFound();

        return Ok();
    }

    // POST: api/AspNetUsers
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<UserResponse>> PostAspNetUsers(UserRequest userRequest)
    {
        var user = new AspNetUsers
        {
            UserName = userRequest.Name,
            Email = userRequest.Email,
            PasswordHash = userRequest.PasswordHash,
            PhoneNumber = userRequest.PhoneNumber,
            LockoutEnd = DateTime.Now
        };
        var createUser = await userService.Add(user);
        var userResponse = new UserResponse
        {
            Id = createUser.Id,
            Name = createUser.UserName,
            Email = createUser.Email,
            PasswordHash = createUser.PasswordHash,
            PhoneNumber = createUser.PhoneNumber,
            LockoutEnd = createUser.LockoutEnd,
            Role = createUser.Role.Select(r => new RoleResponse
            {
                Id = r.Id,
                Name = r.Name
            }).ToList()
        };
        return Ok(userResponse);
    }

    // DELETE: api/AspNetUsers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAspNetUsers(int id)
    {
        var user = await userService.Get(id);
        if (user == null)
        {
            return NotFound();
        }
        await userService.Delete(id);
        return NoContent();
    }
}
