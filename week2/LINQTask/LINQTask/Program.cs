using LINQTask.Data;
using System;
using System.Linq;

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

            var list = purchases.Join(consumers, p => p.ConsumerCode, c => c.ConsumerCode, (p, c) => new
                {
                    ConsumerCode = p.ConsumerCode,
                    YearOfBirth = c.YearOfBirth,
                    ArticleNumber = p.ArticleNumber,
                    StoreName = p.StoreName
                })
                .Join(goods, p => p.ArticleNumber, g => g.ArticleNumber, (p, g) => new
                {
                    Country = g.Country,
                    ConsumerCode = p.ConsumerCode,
                    YearOfBirth = p.YearOfBirth,
                    ArticleNumber = p.ArticleNumber,
                    StoreName = p.StoreName

                })
                .Join(prices, p => p.ArticleNumber, c => c.ArticeNumber, (p, c) => new
                {
                    Country = p.Country,
                    ConsumerCode = p.ConsumerCode,
                    YearOfBirth = p.YearOfBirth,
                    ArticleNumber = p.ArticleNumber,
                    StoreName = p.StoreName,
                    PriceAmount = c.PriceAmount
                })
                .GroupJoin(discounts, p => p.ConsumerCode, d => d.ConsumerCode, (p, Discount) => new
                {
                    Country = p.Country,
                    ConsumerCode = p.ConsumerCode,
                    YearOfBirth = p.YearOfBirth,
                    ArticleNumber = p.ArticleNumber,
                    StoreName = p.StoreName,
                    PriceAmount = p.PriceAmount,
                    Discount
                })
                .SelectMany(x => x.Discount.DefaultIfEmpty(new Data.Models.Discount { DiscountAmount = 100}),
                    (x, p) => new
                    {
                        Country = x.Country,
                        ConsumerCode = x.ConsumerCode,
                        YearOfBirth = x.YearOfBirth,
                        ArticleNumber = x.ArticleNumber,
                        StoreName = x.StoreName,
                        PriceAmount = x.PriceAmount - x.PriceAmount * p.DiscountAmount / 100
                    }
                )
                .OrderBy(x => x.YearOfBirth)
                .GroupBy(x => x.YearOfBirth)
                .First()
                .ToList();

            foreach (var item in list)
            {
                Console.WriteLine($"{item.Country} - {item.StoreName} - {item.YearOfBirth} - {item.ConsumerCode} - {item.ArticleNumber} - {item.PriceAmount}");
            }
        }
    }
}
