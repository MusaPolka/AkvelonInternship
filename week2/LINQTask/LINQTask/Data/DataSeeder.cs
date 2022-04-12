using LINQTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTask.Data
{
    public class DataSeeder
    {
        public static List<Consumer> SeedConsumers()
        {
            var consumers = new List<Consumer>
            {
                new Consumer(){ConsumerCode = 1, Address = "Address1", YearOfBirth = 2000},
                new Consumer(){ConsumerCode = 2, Address = "Address2", YearOfBirth = 1999},
                new Consumer(){ConsumerCode = 3, Address = "Address3", YearOfBirth = 1998},
                new Consumer(){ConsumerCode = 4, Address = "Address4", YearOfBirth = 1998}
            };

            return consumers;
        }

        public static List<Good> SeedGoods()
        {
            var goods = new List<Good>
            {
                new Good(){ArticleNumber = "AB123-1234", Category = "Fruits", Country = "Russia"},
                new Good(){ArticleNumber = "CD456-7891", Category = "Beverages", Country = "Kazakhstan"},
                new Good(){ArticleNumber = "EF789-1234", Category = "Snacks", Country = "Ukrain"}
            };

            return goods;
        }

        public static List<Discount> SeedDiscount()
        {
            var discounts = new List<Discount>
            {
                new Discount(){ConsumerCode = 1, DiscountAmount = 15, StoreName = "FixPrice"},
                new Discount(){ConsumerCode = 2, DiscountAmount = 10, StoreName = "Magnum"},
                new Discount(){ConsumerCode = 4, DiscountAmount = 5, StoreName = "Green"}
            };

            return discounts;
        }

        public static List<Price> SeedPrice()
        {
            var prices = new List<Price>
            {
                new Price(){ArticeNumber = "AB123-1234", StoreName = "FixPrice", PriceAmount = 1000},
                new Price(){ArticeNumber = "CD456-7891", StoreName = "Magnum", PriceAmount = 2000},
                new Price(){ArticeNumber = "EF789-1234", StoreName = "Green", PriceAmount = 3000}
            };

            return prices;
        }

        public static List<Purchase> SeedPurchases()
        {
            var purchases = new List<Purchase>
            {
                new Purchase(){ConsumerCode = 1, ArticleNumber = "AB123-1234", StoreName = "FixPrice"},
                new Purchase(){ConsumerCode = 2, ArticleNumber = "CD456-7891", StoreName = "Magnum"},
                new Purchase(){ConsumerCode = 4, ArticleNumber = "EF789-1234", StoreName = "Green"},
                new Purchase(){ConsumerCode = 4, ArticleNumber = "AB123-1234", StoreName = "Green"},
                new Purchase(){ConsumerCode = 1, ArticleNumber = "AB123-1234", StoreName = "Green"},
                new Purchase(){ConsumerCode = 1, ArticleNumber = "CD456-7891", StoreName = "Magnum"},
                new Purchase(){ConsumerCode = 1, ArticleNumber = "CD456-7891", StoreName = "Magnum"}
            };

            return purchases;
        }
    }
}
