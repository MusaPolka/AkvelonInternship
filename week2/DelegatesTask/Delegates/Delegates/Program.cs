using Data.Contracts;
using Data.CustomerTypes;
using Data.Entities;
using DiscountServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDiscountService discountService = new DiscountService();

            List<Customer> customers = new List<Customer>
            {
                new Customer()
                {
                    Id = 1,
                    FullName = "Bilbo Baggins",
                    Address = "Shire",
                    CustomerType = new PermanentLarge(),
                },
                new Customer()
                {
                    Id = 2,
                    FullName = "Gandalf the Grey",
                    Address = "Anywhere",
                    CustomerType = new PermanentSmall(),
                },
                new Customer()
                {
                    Id = 3,
                    FullName = "Frodo Baggins",
                    Address = "Shire",
                    CustomerType = new NewClient(),
                }
            };

            List<Order> orders = new List<Order>
            {
                new Order()
                {
                    Id = 1,
                    Date = DateTime.Now,
                    Amount = 150000m,
                    CustomerId = 1,
                    Customer = customers[0]
                },
                new Order()
                {
                    Id = 2,
                    Date = DateTime.Now,
                    Amount = 10000m,
                    CustomerId = 2,
                    Customer = customers[1]
                },
                new Order()
                {
                    Id = 3,
                    Date = DateTime.Now,
                    Amount = 100000m,
                    CustomerId = 3,
                    Customer = customers[2]
                }
            };

            Console.WriteLine($"{customers[0].FullName} - {orders.SingleOrDefault(x => x.Id == customers[0].Id).Amount}");

            discountService.Calculate(orders[0]);

            Console.WriteLine($"After calculating discount {orders[0].Amount}");


        }
    }
}
