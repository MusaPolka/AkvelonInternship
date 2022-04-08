using LINQTask;
using System;
using Xunit;

namespace LINQTests
{
    public class FilterServiceTests
    {
        [Theory]
        [InlineData(2000)]
        public void FilterOut_shouldInputHighestYearOfBirth(int yearOfBirth)
        {
            FilterService filterService = new FilterService();
            filterService.FilterOut();

            var expected = yearOfBirth;
        }
    }
}
