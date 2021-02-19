using System;
using System.ComponentModel.DataAnnotations;

namespace OrderMyFood.Services.OrderApi.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public String UserName { get; set; }

        public String PhoneNumber { get; set; }

        public String Address { get; set; }

        public decimal Amount { get; set; }
    }
}
