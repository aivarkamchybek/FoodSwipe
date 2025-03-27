using FoodSwipe.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FoodSwipe.DATA
{
    public class FoodSwipeDbContext : DbContext
    {
        public FoodSwipeDbContext(DbContextOptions<FoodSwipeDbContext> options) : base(options) { }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Interaction> Interactions { get; set; }
    }
}
