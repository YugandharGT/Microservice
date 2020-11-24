using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFood.RestaurantSearchApi.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    public class RestaurantDomainException : Exception
    {
        public RestaurantDomainException()
        { }

        public RestaurantDomainException(string message)
            : base(message)
        { }

        public RestaurantDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
