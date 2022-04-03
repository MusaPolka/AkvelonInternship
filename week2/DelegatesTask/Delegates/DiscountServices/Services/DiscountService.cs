using Data.Contracts;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiscountServices.Services
{
    public class DiscountService : IDiscountService
    {
        public void Calculate(Order order)
        {
            var customer = order.Customer;

            var result = customer.CustomerType.Calculate(order.Amount);

            order.Amount = result(order.Amount);
        }
    }
}
