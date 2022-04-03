using LINQTask.Data;
using System;

namespace LINQTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var consumers = DataSeeder.SeedConsumers();
            var goods = DataSeeder.SeedGoods();
            var discounts = DataSeeder.SeedDiscount();
            var prices = DataSeeder.SeedPrice();
            var purchases = DataSeeder.SeedPurchases();
        }
    }
}
