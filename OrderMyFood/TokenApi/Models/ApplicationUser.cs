using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OrderMyFood.TokenApi.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    /// <summary>
    /// First step of identity
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }
        public ApplicationUser(string emailId)
        {
        }
        [Column("Email_Id")]
        public string EmailId { get; set; }
        
        public string Password { get; set; }
    }
}
