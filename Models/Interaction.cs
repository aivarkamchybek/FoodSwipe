namespace FoodSwipe.Models
{
    public class Interaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DishId { get; set; }
        public bool Liked { get; set; }
        public bool Disliked { get; set; }
    }
}
