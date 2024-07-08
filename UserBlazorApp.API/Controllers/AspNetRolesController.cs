using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserBlazorApp.API.Dts.Claims;
using UserBlazorApp.API.Dts.Role;
using UserBlazorApp.API.Dts.User;
using UserBlazorApp.API.Service;
using UsersBlazorApp.API.Context;
using UsersBlazorApp.Data.Interfacez;
using UsersBlazorApp.Data.Models;

namespace UserBlazorApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspNetRolesController(IAPIService<AspNetRoles> roleService) : ControllerBase
    {

        // GET: api/AspNetRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetRoles>>> GetAspNetRoles()
        {
            var roles = await roleService.GetAll();

            var roleRespose = roles.Select(r => new RoleResponse
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
            }).ToList();
            return Ok(roles);
        }

        // GET: api/AspNetRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetRoles>> GetAspNetRoles(int id)
        {
            var aspNetRoles = await _context.AspNetRoles.FindAsync(id);

            if (aspNetRoles == null)
            {
                return NotFound();
            }

            return aspNetRoles;
        }

        // PUT: api/AspNetRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetRoles(int id, AspNetRoles aspNetRoles)
        {
            if (id != aspNetRoles.Id)
            {
                return BadRequest();
            }

            _context.Entry(aspNetRoles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetRolesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AspNetRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AspNetRoles>> PostAspNetRoles(AspNetRoles aspNetRoles)
        {
            _context.AspNetRoles.Add(aspNetRoles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAspNetRoles", new { id = aspNetRoles.Id }, aspNetRoles);
        }

        // DELETE: api/AspNetRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAspNetRoles(int id)
        {
            var aspNetRoles = await _context.AspNetRoles.FindAsync(id);
            if (aspNetRoles == null)
            {
                return NotFound();
            }

            _context.AspNetRoles.Remove(aspNetRoles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AspNetRolesExists(int id)
        {
            return _context.AspNetRoles.Any(e => e.Id == id);
        }
    }
}
