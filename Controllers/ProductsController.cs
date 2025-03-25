using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Microsoft.AspNetCore.Mvc.Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    public readonly AppDbContext _context;
    public ProductController(AppDbContext context){
        _context=context;
    }   

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products =await _context.Products.ToListAsync();
        return Ok(products);
    }
    [HttpGet("id")]
    public async Task<IActionResult> GetById(int id)
    {
        var product =await _context.Products.Include(p=>p.Category).FirstOrDefaultAsync(p=>p.Id==id);
        if(product==null) return NotFound();
        return Ok(product);
    }
    
    [HttpPost]
    public async Task<IActionResult> create ([FromBody] Product product)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new {id=product.Id}, product);
    }

    [HttpPut("id")]
    public async Task<IActionResult> Update(int id, [FromBody] Product product)
    {
        if(id!=product.Id) return BadRequest("Product ID Mismatch");
        _context.Entry(product).State= EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product =await _context.Products.FindAsync(id);
        if(product==null) return NotFound();
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}