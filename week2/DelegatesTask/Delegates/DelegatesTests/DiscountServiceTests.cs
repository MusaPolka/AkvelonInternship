using Data.Contracts;
using Data.CustomerTypes;
using Data.Entities;
using DiscountServices.Services;
using System;
using Xunit;

namespace DelegatesTests
{
    public class DiscountServiceTests
    {
        [Fact]
        public void CalculateDiscount_returnsValidAmount()
        {         
            
            Customer customer = new Customer() { CustomerType = new PermanentSmall() };
            Order order = new Order() { Amount = 250000, Customer = customer};
            DiscountService discountService = new DiscountService();

            discountService.Calculate(order);

            var expected = 237500;

            Assert.Equal(expected, order.Amount);
        }
    }
}
