using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFood.TokenApi.Models.AccountViewModels
{
    public class ExternalRegisterViewModel
    {
        public string Email { get; set; }
        public string ReturnUrl { get; set; }
    }
}
