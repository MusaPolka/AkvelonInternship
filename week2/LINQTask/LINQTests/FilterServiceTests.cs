using LINQTask;
using System;
using Xunit;

namespace LINQTests
{
    public class FilterServiceTests
    {
        [Theory]
        [InlineData(2000, "Kazakhstan", "Magnum", 1, 3400, 0)]
        public void FilterOut_shouldInputCorrectFirstPurchase(int yearOfBirth, string country,
            string storeName, int consumerCode, int totalPrice, int index)
        {
            FilterService filterService = new FilterService();
            var list = filterService.FilterOut();
            var actualYearOfBirth = list[index].YearOfBirth;
            var actualCountry = list[index].Country;
            var actualStoreName = list[index].StoreName;
            var actualConsumerCode = list[index].ConsumerCode;
            var actualTotalPrice = list[index].PriceAmount;

            var expectedYearOfBirth = yearOfBirth;
            var expectedCountry = country;
            var expectedStoreName = storeName;
            var expectedConsumerCode = consumerCode;
            var expectedTotalPrice = totalPrice;

            Assert.Equal(expectedYearOfBirth, actualYearOfBirth);
            Assert.Equal(expectedCountry, actualCountry);
            Assert.Equal(expectedStoreName, actualStoreName);
            Assert.Equal(expectedConsumerCode, actualConsumerCode);
            Assert.Equal(expectedTotalPrice, actualTotalPrice);
        }

        [Theory]
        [InlineData(2000, "Russia", "FixPrice", 1, 850, 1)]
        public void FilterOut_shouldInputCorrectSecondPurchase(int yearOfBirth, string country,
            string storeName, int consumerCode, int totalPrice, int index)
        {
            FilterService filterService = new FilterService();
            var list = filterService.FilterOut();
            var actualYearOfBirth = list[index].YearOfBirth;
            var actualCountry = list[index].Country;
            var actualStoreName = list[index].StoreName;
            var actualConsumerCode = list[index].ConsumerCode;
            var actualTotalPrice = list[index].PriceAmount;

            var expectedYearOfBirth = yearOfBirth;
            var expectedCountry = country;
            var expectedStoreName = storeName;
            var expectedConsumerCode = consumerCode;
            var expectedTotalPrice = totalPrice;

            Assert.Equal(expectedYearOfBirth, actualYearOfBirth);
            Assert.Equal(expectedCountry, actualCountry);
            Assert.Equal(expectedStoreName, actualStoreName);
            Assert.Equal(expectedConsumerCode, actualConsumerCode);
            Assert.Equal(expectedTotalPrice, actualTotalPrice);
        }

        [Theory]
        [InlineData(2000, "Russia", "Green", 1, 850, 2)]
        public void FilterOut_shouldInputCorrectThordPurchase(int yearOfBirth, string country,
            string storeName, int consumerCode, int totalPrice, int index)
        {
            FilterService filterService = new FilterService();
            var list = filterService.FilterOut();
            var actualYearOfBirth = list[index].YearOfBirth;
            var actualCountry = list[index].Country;
            var actualStoreName = list[index].StoreName;
            var actualConsumerCode = list[index].ConsumerCode;
            var actualTotalPrice = list[index].PriceAmount;

            var expectedYearOfBirth = yearOfBirth;
            var expectedCountry = country;
            var expectedStoreName = storeName;
            var expectedConsumerCode = consumerCode;
            var expectedTotalPrice = totalPrice;

            Assert.Equal(expectedYearOfBirth, actualYearOfBirth);
            Assert.Equal(expectedCountry, actualCountry);
            Assert.Equal(expectedStoreName, actualStoreName);
            Assert.Equal(expectedConsumerCode, actualConsumerCode);
            Assert.Equal(expectedTotalPrice, actualTotalPrice);
        }

        [Theory]
        [InlineData(1998, "Ukrain", "Green", 4, 2850, 3)]
        public void FilterOut_shouldInputCorrectFourthPurchase(int yearOfBirth, string country,
            string storeName, int consumerCode, int totalPrice, int index)
        {
            FilterService filterService = new FilterService();
            var list = filterService.FilterOut();
            var actualYearOfBirth = list[index].YearOfBirth;
            var actualCountry = list[index].Country;
            var actualStoreName = list[index].StoreName;
            var actualConsumerCode = list[index].ConsumerCode;
            var actualTotalPrice = list[index].PriceAmount;

            var expectedYearOfBirth = yearOfBirth;
            var expectedCountry = country;
            var expectedStoreName = storeName;
            var expectedConsumerCode = consumerCode;
            var expectedTotalPrice = totalPrice;

            Assert.Equal(expectedYearOfBirth, actualYearOfBirth);
            Assert.Equal(expectedCountry, actualCountry);
            Assert.Equal(expectedStoreName, actualStoreName);
            Assert.Equal(expectedConsumerCode, actualConsumerCode);
            Assert.Equal(expectedTotalPrice, actualTotalPrice);
        }

    }
}
