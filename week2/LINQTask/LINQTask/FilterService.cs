using LINQTask.Data;
using LINQTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTask
{
    public class FilterService
    {
        List<Consumer> consumers = DataSeeder.SeedConsumers();
        List<Good> goods = DataSeeder.SeedGoods();
        List<Discount> discounts = DataSeeder.SeedDiscount();
        List<Price> prices = DataSeeder.SeedPrice();
        List<Purchase> purchases = DataSeeder.SeedPurchases();

        public List<ReturnList> FilterOut()
        {
            List<ReturnList> returnList = new List<ReturnList>();

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
                .SelectMany(x => x.Discount.DefaultIfEmpty(new Data.Models.Discount { DiscountAmount = 100 }),
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
                .GroupBy(x => new { x.Country, x.StoreName })
                .Select(c => c.ToList()
                .FindAll(x => x.YearOfBirth == c.Max(y => y.YearOfBirth)))
                .SelectMany(x => x)
                .OrderBy(x => x.Country)
                .ThenBy(x => x.StoreName)
                .ToList();

            foreach (var item in list)
            {
                returnList.Add(new ReturnList
                {
                    Country = item.Country,
                    StoreName = item.StoreName,
                    ArticleNumber = item.ArticleNumber,
                    ConsumerCode = item.ConsumerCode,
                    YearOfBirth = item.YearOfBirth,
                    PriceAmount = item.PriceAmount
                });
            }
            
            return returnList;
        }
    }
}
