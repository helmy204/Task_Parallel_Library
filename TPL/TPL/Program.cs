using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
    class Program
    {
        static void Main(string[] args)
        {
            ////1.
            //SameThread();

            ////2.
            //ParallelThread();

            //3.
            AsyncAwaitMethod();
        }

        

        static void SameThread()
        {
            var result = SlowOperation();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Slow operation result: {0}", result);

            Console.WriteLine("Main complete on {0}", Thread.CurrentThread.ManagedThreadId);
        }

        static void ParallelThread()
        {
            var task = Task.Factory.StartNew<int>(SlowOperation);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Slow operation result: {0}", task.Result);

            Console.WriteLine("Main complete on {0}", Thread.CurrentThread.ManagedThreadId);
        }

        static void AsyncAwaitMethod()
        {
            var task = SlowOperationAsync();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Slow operation result: {0}", task.Result);

            Console.WriteLine("Main complete on {0}", Thread.CurrentThread.ManagedThreadId);
        }

        static int SlowOperation()
        {
            Console.WriteLine("Slow operation started on {0}", Thread.CurrentThread.ManagedThreadId);

            // wait 2 seconds
            Thread.Sleep(2000);

            Console.WriteLine("Slow operation complete on {0}", Thread.CurrentThread.ManagedThreadId);

            return 42;
        }

        static async Task<int> SlowOperationAsync()
        {
            Console.WriteLine("Slow operation started on {0}", Thread.CurrentThread.ManagedThreadId);

            // wait 2 seconds
            await Task.Delay(2000);

            Console.WriteLine("Slow operation complete on {0}", Thread.CurrentThread.ManagedThreadId);

            return 42;
        }
    }
}
