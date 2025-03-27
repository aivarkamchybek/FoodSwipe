using FoodSwipe.DATA;
using FoodSwipe.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodSwipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly FoodSwipeDbContext _context;

        public UsersController(FoodSwipeDbContext context)
        {
            _context = context;
        }

        // Register a new user
        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUser([FromBody] User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
    }

}
