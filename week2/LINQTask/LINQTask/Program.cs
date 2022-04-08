using LINQTask.Data;
using System;
using System.Linq;

namespace LINQTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
           FilterService filterService = new FilterService();
           var list = filterService.FilterOut();

            foreach (var item in list)
            {
                Console.WriteLine($"{item.Country} - {item.StoreName} - {item.YearOfBirth} - {item.ConsumerCode} - {item.ArticleNumber} - {item.PriceAmount}");
            }
        }
    }
}
