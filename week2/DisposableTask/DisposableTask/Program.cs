using System;

namespace DisposableTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer("Musa");

            customer.Print();

            customer.Dispose();

            customer.Print();
        }
    }
}
