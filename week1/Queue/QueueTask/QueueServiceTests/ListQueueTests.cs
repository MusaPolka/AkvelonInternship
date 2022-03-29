using QueueService;
using System;
using Xunit;

namespace QueueServiceTests
{
    public class ListQueueTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-5)]
        [InlineData(int.MaxValue)]
        public void Enqueue_int_ShouldAddNumber(int input)
        {
            ListQueue<int> listQueue = new ListQueue<int>();

            listQueue.Enqueue(input);

            Assert.True(listQueue.Peek() == input);
        }

        [Fact]
        public void Dequeue_int_ShouldDeleteAndReturnNumber()
        {
            ListQueue<int> listQueue = new ListQueue<int>();

            listQueue.Enqueue(1);
            listQueue.Enqueue(2);

            listQueue.Dequeue();

            var expected = 2;

            Assert.Equal(expected, listQueue.Peek());
        }

        [Fact]
        public void Peek_ShouldReturnFirstElement()
        {
            ListQueue<int> listQueue = new ListQueue<int>();

            listQueue.Enqueue(1);
            listQueue.Enqueue(2);

            var expected = 1;

            Assert.Equal(expected, listQueue.Peek());
        }
    }
}
