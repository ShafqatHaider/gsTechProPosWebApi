using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class RolesPermissionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public RolesPermissionsController(AppDbContext context)
    {
        _context = context;
    }

    
    [HttpGet("roles")]
    public async Task<IActionResult> GetRoles()
    {
        var roles = await _context.Roles.Include(r => r.RolePermissions)
                                         .ThenInclude(rp => rp.Permission)
                                         .ToListAsync();
        return Ok(roles);
    }

    
    [HttpGet("permissions")]
    public async Task<IActionResult> GetPermissions()
    {
        var permissions = await _context.Permissions.ToListAsync();
        return Ok(permissions);
    }

    
    [HttpPost("roles")]
    public async Task<IActionResult> CreateRole([FromBody] Role role)
    {
        if (role == null)
            return BadRequest("Invalid role data");

        _context.Roles.Add(role);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetRoles), new { id = role.Id }, role);
    }

    
    [HttpPost("permissions")]
    public async Task<IActionResult> CreatePermission([FromBody] Permission permission)
    {
        if (permission == null)
            return BadRequest("Invalid permission data");

        _context.Permissions.Add(permission);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPermissions), new { id = permission.Id }, permission);
    }

    
    [HttpPost("assign-permission")]
    public async Task<IActionResult> AssignPermissionToRole([FromBody] RolePermission rolePermission)
    {
        if (rolePermission == null)
            return BadRequest("Invalid data");

        var roleExists = await _context.Roles.FindAsync(rolePermission.RoleId);
        var permissionExists = await _context.Permissions.FindAsync(rolePermission.PermissionId);

        if (roleExists == null || permissionExists == null)
            return NotFound("Role or Permission not found");

        _context.RolePermissions.Add(rolePermission);
        await _context.SaveChangesAsync();

        return Ok("Permission assigned to role successfully");
    }

    
    [HttpGet("role-permissions/{roleId}")]
    public async Task<IActionResult> GetRolePermissions(int roleId)
    {
        var rolePermissions = await _context.RolePermissions
                                            .Where(rp => rp.RoleId == roleId)
                                            .Include(rp => rp.Permission)
                                            .ToListAsync();

        if (!rolePermissions.Any())
            return NotFound("No permissions found for this role");

        return Ok(rolePermissions);
    }

    
    [HttpDelete("roles/{id}")]
    public async Task<IActionResult> DeleteRole(int id)
    {
        var role = await _context.Roles.FindAsync(id);
        if (role == null)
            return NotFound("Role not found");

        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();

        return Ok("Role deleted successfully");
    }

    
    [HttpDelete("permissions/{id}")]
    public async Task<IActionResult> DeletePermission(int id)
    {
        var permission = await _context.Permissions.FindAsync(id);
        if (permission == null)
            return NotFound("Permission not found");

        _context.Permissions.Remove(permission);
        await _context.SaveChangesAsync();

        return Ok("Permission deleted successfully");
    }
}
