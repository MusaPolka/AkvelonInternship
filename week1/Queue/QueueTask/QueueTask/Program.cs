using QueueService;
using System;

namespace QueueTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListQueue<int> listQueue = new ListQueue<int>();
            ArrayQueue<string> arrayQueue = new ArrayQueue<string>();

            CreateListQueue(listQueue);
            Console.WriteLine();
            CreateArrayQueue(arrayQueue);
        }

        //This method creates ListQueue that contains some data
        static void CreateListQueue(ListQueue<int> listQueue)
        {
            listQueue.Enqueue(1);
            listQueue.Enqueue(2);
            listQueue.Enqueue(3);

            Console.WriteLine($"ListQueue before dequeue: {listQueue.Peek()}");

            Console.WriteLine($"Dequeue element: {listQueue.Dequeue()}");

            Console.WriteLine($"ListQueue after dequeue: {listQueue.Peek()}");
        }

        //This method creates ArrayQueue that contains some data
        static void CreateArrayQueue(ArrayQueue<string> arrayQueue)
        {
            arrayQueue.Enqueue("John");
            arrayQueue.Enqueue("Mary");
            arrayQueue.Enqueue("Bob");

            Console.WriteLine($"ArrayQueue before dequeue: {arrayQueue.Peek()}");

            Console.WriteLine($"Dequeue element: {arrayQueue.Dequeue()}");

            Console.WriteLine($"ArrayQueue after dequeue: {arrayQueue.Peek()}");
        }
    }
}
