using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueService
{
    /// <summary>
    /// Creating Array class that is implementing IQueue interface
    /// </summary>
    /// <typeparam name="T">Any type</typeparam>
    public class ArrayQueue<T> : IQueue<T>
    {
        T[] arrayQueue = new T[0];

        public T Dequeue()
        {
            var temp = arrayQueue[0];

            //Remove element from first index
            for (int i = 0; i < arrayQueue.Length - 1; i++)
            {
                arrayQueue[i] = arrayQueue[i + 1];
            }

            return temp;
        }

        public void Enqueue(T input)
        {
            T[] newArray = new T[arrayQueue.Length + 1];

            newArray[arrayQueue.Length] = input;

            //Add element to first index
            for (int i = 0; i < arrayQueue.Length; i++)
            {
                newArray[i] = arrayQueue[i];
            }

            arrayQueue = newArray;
        }

        public T Peek()
        {
            //return first element
            return arrayQueue[0];
        }
    }
}
