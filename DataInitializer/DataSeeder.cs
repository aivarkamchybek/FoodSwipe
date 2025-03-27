using FoodSwipe.DATA;
using FoodSwipe.Models;
using Microsoft.EntityFrameworkCore;

public static class DataSeeder
{
    public static void Seed(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<FoodSwipeDbContext>();

            // Apply pending migrations
            context.Database.Migrate();

            // Check if there are already dishes in the database
            if (!context.Dishes.Any())
            {
                context.Dishes.AddRange(new List<Dish>
                {
                    new Dish { Name = "Salad", Category = "Healthy", ImageUrl = "/assets/salad.jpg" },
                    new Dish { Name = "Pizza", Category = "Fast Food", ImageUrl = "/assets/pizza.jpg" },
                    new Dish { Name = "Burger", Category = "Fast Food", ImageUrl = "/assets/burger.jpg" }
                });

                context.SaveChanges();
            }
        }
    }
}
