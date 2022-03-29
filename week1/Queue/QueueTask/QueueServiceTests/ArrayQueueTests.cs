using QueueService;
using System;
using Xunit;

namespace QueueServiceTests
{
    public class ArrayQueueTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-5)]
        [InlineData(int.MaxValue)]
        public void Enqueue_int_ShouldAddNumber(int input)
        {
            ArrayQueue<int> arrayQueue = new ArrayQueue<int>();

            arrayQueue.Enqueue(input);

            Assert.True(arrayQueue.Peek() == input);
        }

        [Fact]
        public void Dequeue_int_ShouldDeleteAndReturnNumber()
        {
            ArrayQueue<int> arrayQueue = new ArrayQueue<int>();

            arrayQueue.Enqueue(1);
            arrayQueue.Enqueue(2);

            arrayQueue.Dequeue();

            var expected = 2;

            Assert.Equal(expected, arrayQueue.Peek());
        }

        [Fact]
        public void Peek_ShouldReturnFirstElement()
        {
            ArrayQueue<int> arrayQueue = new ArrayQueue<int>();

            arrayQueue.Enqueue(1);
            arrayQueue.Enqueue(2);

            var expected = 1;

            Assert.Equal(expected, arrayQueue.Peek());
        }
    }
}
