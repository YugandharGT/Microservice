using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFood.Services.OrderApi.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    public class OrderDomainException : Exception
    {
        public OrderDomainException()
        { }

        public OrderDomainException(string message)
            : base(message)
        { }

        public OrderDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
