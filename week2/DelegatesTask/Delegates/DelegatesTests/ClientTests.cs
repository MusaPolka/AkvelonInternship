using Data.Contracts;
using Data.CustomerTypes;
using System;
using Xunit;

namespace DelegatesTests
{
    public class ClientTests
    {
        [Theory]
        [InlineData(200000, 170000)]
        [InlineData(100000, 90000)]
        [InlineData(0, 0)]
        public void PermanentLarge_ShouldReturnTrue(decimal amount, decimal expected)
        {
            ICustomerType customer = new PermanentLarge();

            var actual = customer.Calculate(amount);

            Assert.True(expected == actual(amount));
        }


        [Theory]
        [InlineData(10000, 9500)]
        [InlineData(100000, 95000)]
        [InlineData(0, 0)]
        public void PermanentSmall_ShouldReturnTrue(decimal amount, decimal expected)
        {
            ICustomerType customer = new PermanentSmall();

            var actual = customer.Calculate(amount);

            Assert.True(expected == actual(amount));
        }


        [Theory]
        [InlineData(25000, 25000)]
        [InlineData(10000, 10000)]
        [InlineData(0, 0)]
        public void NewClient_ShouldReturnTrue(decimal amount, decimal expected)
        {
            ICustomerType customer = new NewClient();

            var actual = customer.Calculate(amount);

            Assert.True(expected == actual(amount));
        }
    }
}
