using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[Route("api/Branches")]
[ApiController]
public class BranchesController :ControllerBase
{
    private readonly AppDbContext _context;
    public BranchesController(AppDbContext context)
    {
        _context= context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBranches()
    {
        try
        {
            var branches = await _context.Branch.ToListAsync();
            return Ok(branches);

        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBranchById(int id)
    {
        try
        {
            var branch= await _context.Branch.Include(b=>b.Restaurant)
                         .FirstOrDefaultAsync(b=>b.Id==id); 
            if(branch==null)
            return NotFound("Branch not found");

            return Ok(branch);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateBranch([FromBody] Branch branch)
    {   
        if(branch==null)
        return BadRequest("Branch is null");

        var restaurantExists = await _context.Restaurants.FindAsync(branch.RestaurantId);
        if(restaurantExists==null)
        return NotFound("Restaurant not found");
        try
        {
            _context.Branch.Add(branch);
            _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBranchById), new { id = branch.Id }, branch);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBranch(int id, [FromBody] Branch updatedBranch)
    {
        if(id!=updatedBranch.Id)
        return BadRequest("Branch id does not match");
        var branch = await _context.Branch.FindAsync(id);
        if(branch==null)
        return NotFound("Branch not found");
        try
        {
            branch.BranchName = updatedBranch.BranchName;
            branch.Location= updatedBranch.Location;
            branch.ManagerId= updatedBranch.ManagerId;
            await _context.SaveChangesAsync();
            return Ok("Branch updated successfully.");
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBranch(int id)
    {
            var branch = await _context.Branch.FindAsync(id);
            if(branch==null)
            return NotFound("Branch not found");
        try
        {
            _context.Branch.Remove(branch);
            await _context.SaveChangesAsync();
            return Ok("Branch deleted successfully");
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}