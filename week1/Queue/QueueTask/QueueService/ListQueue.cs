using System;
using System.Collections.Generic;

namespace QueueService
{
    /// <summary>
    /// Creating List class that is implementing IQueue interface
    /// </summary>
    /// <typeparam name="T">Any type</typeparam>
    public class ListQueue<T> : IQueue<T>
    {
        List<T> listQueue = new List<T>();

        public T Dequeue()
        {
            var temp = listQueue[0];

            //Remove element from first index
            listQueue.RemoveAt(0);

            return temp;
        }

        public void Enqueue(T num)
        {
            //Add element to first index
            listQueue.Add(num);
        }

        public T Peek()
        {
            //return first element
            return listQueue[0];
        }
    }
}
