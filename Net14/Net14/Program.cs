using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Net14
{
    class Program
    {
        public static object syncObj = new object();

        public static void Main(string[] args)
        {
            
            var listTasks = new List<Task>();
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            for (int i = 0; i < 10; i++)
            {
                var task = new Task<int>(() => Func1(i + 10, token));
                task.Start();

                listTasks.Add(task);
            }

            Task.WaitAll(listTasks[0], listTasks[1]);

            tokenSource.Cancel();
        }

        public static int Func1(int maxNumber, CancellationToken cancellation)
        {
            var summ = 0;
            for (int i = 0; i < maxNumber; i++)
            {
                summ += i;

                if (cancellation.IsCancellationRequested)
                {
                    throw new Exception("They froce me die");
                }
            }

            return summ;
        }
    }
}
