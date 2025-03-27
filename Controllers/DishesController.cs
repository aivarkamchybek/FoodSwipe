using FoodSwipe.DATA;
using FoodSwipe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodSwipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly FoodSwipeDbContext _context;

        public DishesController(FoodSwipeDbContext context)
        {
            _context = context;
        }

        // Get all dishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dish>>> GetDishes()
        {
            return await _context.Dishes.ToListAsync();
        }

        // Post a swipe interaction (like or dislike)
        [HttpPost("interact")]
        public async Task<ActionResult> PostInteraction([FromBody] Interaction interaction)
        {
            _context.Interactions.Add(interaction);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Get dishes for a user based on their swipes (you can add machine learning logic here)
        [HttpGet("user/{userId}/recommendations")]
        public async Task<ActionResult<IEnumerable<Dish>>> GetRecommendations(int userId)
        {
            // Example: Get dishes that the user has not interacted with yet.
            var userInteractions = await _context.Interactions
                .Where(i => i.UserId == userId)
                .Select(i => i.DishId)
                .ToListAsync();

            var recommendedDishes = await _context.Dishes
                .Where(d => !userInteractions.Contains(d.Id))
                .Take(10) // Limit the number of recommendations
                .ToListAsync();

            return recommendedDishes;
        }
    }
}