using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderMyFood.Services.OrderApi.Model
{
    public class Order
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public int StatusId { get; set; }
        public DateTime OrderCreated { get; set; }
        public bool IsPaid { get; set; }
        public decimal Price { get; set; }
        public string Note { get; set; }
       
    }
}
