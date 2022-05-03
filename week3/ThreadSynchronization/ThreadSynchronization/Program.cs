using System;
using System.Linq;
using System.Threading;

namespace ThreadSynchronization
{
    internal class Program
    {
        static ManualResetEvent manualResetEvent = new ManualResetEvent(false);
        static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            bool isNotExecuting;
            Mutex mutex = new Mutex(true,
                AppDomain.CurrentDomain.SetupInformation.TargetFrameworkName,
                out isNotExecuting);

            if (isNotExecuting)
            {
                mutex.ReleaseMutex();
                GC.KeepAlive(mutex);
            }
            else
            {
                Console.WriteLine("Only one instance of this program can be executed");
                return;
            }

            Thread firstThread = new Thread(() => Loop());
            firstThread.Name = "1";
            firstThread.Start();

            Thread.Sleep(1000);

            Thread secondThread = new Thread(() => Loop());
            secondThread.Name = "2";
            secondThread.Start();

            Thread.Sleep(1000);

            Thread thirdThread = new Thread(() => WaitForManual());
            thirdThread.Name = "3";
            thirdThread.Start();

            Thread.Sleep(1000);

            Thread fourthThread = new Thread(() => WaitForManual());
            fourthThread.Name = "4";
            fourthThread.Start();

            Thread.Sleep(1000);

            Thread fifthThread = new Thread(() => WaitForAuto());
            fifthThread.Name = "5";
            fifthThread.Start();

            Thread.Sleep(1000);

            Thread sixthThread = new Thread(() => WaitForAuto());
            sixthThread.Name = "6";
            sixthThread.Start();


            Thread.Sleep(3000);

            Console.WriteLine($"Thread 1 reset signal");
            manualResetEvent.Reset();

            Thread.Sleep(1000);

            Console.WriteLine($"Thread 2 set signal");
            autoResetEvent.Set();
        }

        static void Loop()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.Name} started");

            if (Thread.CurrentThread.Name == "1")
            {
                Thread.Sleep(7000);
                Console.WriteLine($"Thread {Thread.CurrentThread.Name} set signal");
                manualResetEvent.Set();

            }
            if (Thread.CurrentThread.Name == "2")
            {
                Thread.Sleep(5000);
                Console.WriteLine($"Thread {Thread.CurrentThread.Name} set signal");
                autoResetEvent.Set();
            }

        }

        static void WaitForManual()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.Name} is waiting for a manual signal from Thread 1");

            if (manualResetEvent.WaitOne())
            {
                if (Thread.CurrentThread.Name == "4")
                {
                    Thread.Sleep(10);
                }

                Console.WriteLine($"Thread {Thread.CurrentThread.Name} received a manual signal, continue working");
            }
        }

        static void WaitForAuto()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.Name} is waiting for an auto signal from Thread 2");

            if (autoResetEvent.WaitOne())
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.Name} received an auto signal, continue working");
            }
        }
    }
}