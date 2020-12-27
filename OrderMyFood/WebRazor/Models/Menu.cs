namespace OrderMyFood.Web.WebRazor.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        
        public string MenuName { get; set; }
       
        public decimal Price { get; set; }

        public string RestaurantName { get; set; }

    }
}
