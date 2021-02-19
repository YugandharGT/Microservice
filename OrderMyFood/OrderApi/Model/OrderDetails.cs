using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderMyFood.Services.OrderApi.Model
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public int MenuId { get; set; }
        public int Quantity { get; set; }
    }
}
