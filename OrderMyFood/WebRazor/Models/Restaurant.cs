namespace OrderMyFood.Web.WebRazor.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
        public int Distance { get; set; }
        public string Cuisine { get; set; }
        public decimal Budget { get; set; }
        public short Ratings { get; set; }

    }
}
