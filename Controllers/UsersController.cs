using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
[Microsoft.AspNetCore.Mvc.Route("api/Users")]
[ApiController]
public class UsersController:ControllerBase
{

private readonly  AppDbContext  _context;

public UsersController(AppDbContext context)
{
    _context = context;
}
[HttpGet]
public IActionResult GetUsers()
{
    return Ok(_context.Users.ToList());
}
[HttpPost]
public IActionResult CreateUser([FromBody] User user)
{
    _context.Users.Add(user);
    _context.SaveChanges();
    return Ok(user);
}

}