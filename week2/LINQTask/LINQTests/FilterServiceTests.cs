using LINQTask;
using System;
using Xunit;

namespace LINQTests
{
    public class FilterServiceTests
    {
        [Fact]
        public void FilterOut_shouldInputHighestYearOfBirth()
        {
            FilterService filterService = new FilterService();
            var list = filterService.FilterOut();
            var actual = list[0].YearOfBirth;

            var expected = 2000;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FilterOut_shouldInputCorrectCountry()
        {
            FilterService filterService = new FilterService();
            var list = filterService.FilterOut();
            var actual = list[0].Country;

            var expected = "Kazakhstan";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FilterOut_shouldInputCorrectStore()
        {
            FilterService filterService = new FilterService();
            var list = filterService.FilterOut();
            var actual = list[0].StoreName;

            var expected = "Magnum";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FilterOut_shouldInputCorrectConsumerCode()
        {
            FilterService filterService = new FilterService();
            var list = filterService.FilterOut();
            var actual = list[0].ConsumerCode;

            var expected = 1;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FilterOut_shouldInputCorrectArticleNumber()
        {
            FilterService filterService = new FilterService();
            var list = filterService.FilterOut();
            var actual = list[0].ArticleNumber;

            var expected = "CD456-7891";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FilterOut_shouldInputCorrectPrice()
        {
            FilterService filterService = new FilterService();
            var list = filterService.FilterOut();
            var actual = list[0].PriceAmount;

            var expected = 1700;

            Assert.Equal(expected, actual);
        }
    }
}
