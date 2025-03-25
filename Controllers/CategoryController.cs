using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/Category")]
[ApiController]
public class CategoryController:ControllerBase
{
    private readonly AppDbContext _context;
    public CategoryController(AppDbContext context)
    {
        _context=context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories= await _context.Categories.ToListAsync();
        return Ok(categories);
    }
    [HttpGet("id")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c=>c.Id==id);
        if(category==null) return NotFound();
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> create([FromBody] Category category)
    {
        _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }
[HttpPut("id")]
public async Task<IActionResult> UpdateCategory(int id, Category category)
{
    
    if (id != category.Id)
    {
        return BadRequest("Category ID mismatch.");
    }

    var existingCategory = await _context.Categories.FindAsync(id);
    if (existingCategory == null)
    {
        return NotFound("Category not found.");
    }

    // Update only specific properties
    existingCategory.cateName = category.cateName;

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
       
            throw;
       
    }

    return NoContent();
}


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var category =await _context.Categories.FindAsync(id);
        if(category==null) return NotFound();
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}