using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[Route("api/Restaurant")]
[ApiController]
public class RestaurantsController : ControllerBase
{
    private readonly AppDbContext _context;

    public RestaurantsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> createRest([FromBody] Restaurant restaurant)
    {
        if (restaurant == null)
            return BadRequest("Invalid restaurant data");
        var restaurantExists = await _context.Restaurants.FindAsync(restaurant.Id);
        if (restaurantExists == null)
            BadRequest("Restaurant already exists");
        var ownerExists = await _context.Users.FindAsync(restaurant.OwnerId);
        if (ownerExists == null)
            return NotFound("Owner not found");
        try
        {
            int result = await _context.SaveChangesAsync();

        if (result > 0)
        {
            return CreatedAtAction(nameof(GetRestaurant), new { id = restaurant.Id }, restaurant);
        }
        else
        {
            return StatusCode(500, "Failed to save restaurant to database.");
        }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRestaurant(int id)
    {
        try
        {
            var restaurant = await _context.Restaurants.Include(r => r.Branches)
                                                        .FirstOrDefaultAsync(r => r.Id == id);
            if (restaurant == null)
                return NotFound("Restaurant not found");

            return Ok(restaurant);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRestaurants()
    {
        try
        {
            var restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Restaurant updatedRestaurant)
    {
        if (id != updatedRestaurant.Id)
            return BadRequest("Restaurant id does not match");

        var restaurant = await _context.Restaurants.FindAsync(id);
        if (restaurant == null)
            return NotFound("Restaurant not found");
        try
        {
            restaurant.Name = updatedRestaurant.Name;
            restaurant.address = updatedRestaurant.address;
            restaurant.contactNo = updatedRestaurant.contactNo;

            await _context.SaveChangesAsync();
            return Ok(restaurant);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRestaurant(int id)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);
        if (restaurant == null)
            return NotFound("Restaurant not found");
        try
        {
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
            return Ok("Restaurant deleted successfully");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}