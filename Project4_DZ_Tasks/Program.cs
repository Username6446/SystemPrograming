using System;
using System.Text;
using System.Threading.Channels;

namespace Project4_DZ_Tasks
{
    internal class Program
    {
        static void PrintTime()
        {
            Console.WriteLine($"Task1 : {DateTime.Now}");
        }
        static void PrintSimple(int start = 2, int end = 1000)
        {
            Console.WriteLine("Прості числа від 0 до 1000:");

            for (int i = start; i <= end; i++) 
            {
                bool isPrime = true;
                for (int j = 2; j <= i / 2; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    Console.Write($"{i} ");
                }
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            #region Ex1
            Task task1 = new Task(PrintTime);
            task1.Start();
            Task task2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Task2 : {DateTime.Now}");
            });
            Task task3 = Task.Run(() =>
            {
                Console.WriteLine($"Task3 : {DateTime.Now}");
            });

            //Console.ReadKey();
            #endregion

            #region Ex2-3
            Console.Clear();
            Task task4 = new Task(() => PrintSimple(1,100));
            task4.Start();
            task4.Wait();
            //Console.ReadKey();
            #endregion

            #region Ex4
            Console.Clear();
            int[] arr = { 1, 2, 3, 4, 5 };
            Task[] tasks = new Task[4]
            {
                new Task(() => Console.WriteLine($"Min : {arr.Min()}")),
                new Task(() => Console.WriteLine($"Max : {arr.Max()}")),
                new Task(() => Console.WriteLine($"Average : {arr.Average()}")),
                new Task(() => Console.WriteLine($"Sum : {arr.Sum()}")),
            };
            foreach (var task in tasks)
            {
                task.Start();
            }
            Task.WaitAll(tasks);
            //Console.ReadKey();

            #endregion

            #region Ex5
            Console.Clear();
            int[] array = { 1, 1, 2, 2, 3, 4, 5, 5, 5 };

            Task task5 = Task.Run(() => 
            {
                var distinct = array.Distinct().ToArray();
                Console.WriteLine("Distinct");
            });

            Task continueTask = task5
                .ContinueWith(t => 
                {
                    Array.Sort(array);
                    Console.WriteLine("Sort.");
                })
                .ContinueWith(t => 
                {
                    int index = Array.BinarySearch(array, 1);
                    Console.WriteLine($"BinarySearch element on index: {index}");
                
                });

            continueTask.Wait();

            Console.WriteLine("End");
            Console.ReadKey();
            #endregion

        }
    }
}
